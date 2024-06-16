using System.Net;
using MassTransit;
using Polly;
using Polly.Extensions.Http;
using SearchService.Consumers;
using SearchService.Data;
using SearchService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient<AuctionSvcHttpClient>().AddPolicyHandler(GetPolicy());
builder.Services.AddMassTransit(x => 
{
    x.AddConsumersFromNamespaceContaining<AuctionCreatedConsumer>();

    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("search", false));

    x.UsingRabbitMq((context, cfg) => 
    {
        cfg.ReceiveEndpoint("search-auction-created", e =>
        {
            e.UseMessageRetry(r => r.Interval(3, 5));

            e.ConfigureConsumer<AuctionCreatedConsumer>(context);
        });
        
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

// add hack for the resend sync (async in here) request again (3 seconds) if data is not accepted 
// (Auction Service is down or not available)
app.Lifetime.ApplicationStarted.Register(async () => {
    try
    {
        await DbInitializer.InitDbAsync(app);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
});

app.Run();

// add hack for the resend sync (async in here) request again (3 seconds) if data is not accepted 
// (Auction Service is down or not available)
static IAsyncPolicy<HttpResponseMessage> GetPolicy() 
    => HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
        .WaitAndRetryForeverAsync(_ => TimeSpan.FromSeconds(3));
