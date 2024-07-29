using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x => 
{
    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("nt", false));

    x.UsingRabbitMq((context, cfg) => 
    {
        cfg.Host(builder.Configuration["RabbitMQ:Host"], "/", host =>
        {
            host.Username(builder.Configuration.GetValue("RabbitMQ:Username", "guest"));
            host.Password(builder.Configuration.GetValue("RabbitMQ:Password", "guest"));
        });
        
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

app.Run();
