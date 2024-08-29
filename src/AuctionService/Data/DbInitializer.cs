using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<AuctionDbContext>());
    }

    private static void SeedData(AuctionDbContext context)
    {
        context.Database.Migrate();

        if (context.Auctions.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        var auctions = new List<Auction>()
        {
            // 1 Ford GT
            new() {
                Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Item = new Item
                {
                    Make = "Ford",
                    Model = "GT",
                    Color = "White",
                    Mileage = 50000,
                    Year = 2020,
                    ImageUrl = "https://images.unsplash.com/photo-1626383494011-a97f8a940a05?w=1280"
                }
            },
            // 2 Bugatti Veyron
            new() {
                Id = Guid.Parse("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"),
                Status = Status.Live,
                ReservePrice = 90000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(60),
                Item = new Item
                {
                    Make = "Bugatti",
                    Model = "Veyron",
                    Color = "Black",
                    Mileage = 15035,
                    Year = 2018,
                    ImageUrl = "https://images.unsplash.com/photo-1596809011210-34f77e175150?w=1280"
                }
            },
            // 3 Ford mustang
            new() {
                Id = Guid.Parse("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"),
                Status = Status.Live,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(4),
                Item = new Item
                {
                    Make = "Ford",
                    Model = "Mustang",
                    Color = "Blue",
                    Mileage = 65125,
                    Year = 2023,
                    ImageUrl = "https://images.unsplash.com/photo-1709769320382-5c8bbb8c4933?w=1280"
                }
            },
            // 4 Mercedes SLK
            new() {
                Id = Guid.Parse("155225c1-4448-4066-9886-6786536e05ea"),
                Status = Status.ReserveNotMet,
                ReservePrice = 50000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(-10),
                Item = new Item
                {
                    Make = "Mercedes",
                    Model = "SLK",
                    Color = "Black",
                    Mileage = 15001,
                    Year = 2020,
                    ImageUrl = "https://images.unsplash.com/photo-1688812656796-f4c3334e84b0?w=1280"
                }
            },
            // 5 BMW X1
            new() {
                Id = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(30),
                Item = new Item
                {
                    Make = "BMW",
                    Model = "X1",
                    Color = "Black",
                    Mileage = 90000,
                    Year = 2017,
                    ImageUrl = "https://images.unsplash.com/photo-1523983388277-336a66bf9bcd?w=1280"
                }
            },
            // 6 Ferrari spider
            new() {
                Id = Guid.Parse("dc1e4071-d19d-459b-b848-b5c3cd3d151f"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(45),
                Item = new Item
                {
                    Make = "Ferrari",
                    Model = "Spider",
                    Color = "Red",
                    Mileage = 50000,
                    Year = 2015,
                    ImageUrl = "https://images.unsplash.com/photo-1524710800377-5cdd93fa491a?w=1280"
                }
            },
            // 7 Ferrari F-430
            new() {
                Id = Guid.Parse("47111973-d176-4feb-848d-0ea22641c31a"),
                Status = Status.Live,
                ReservePrice = 150000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(13),
                Item = new Item
                {
                    Make = "Ferrari",
                    Model = "F-430",
                    Color = "Red",
                    Mileage = 5000,
                    Year = 2022,
                    ImageUrl = "https://images.unsplash.com/photo-1583121274602-3e2820c69888?w=1280"
                }
            },
            // 8 Audi R8
            new() {
                Id = Guid.Parse("6a5011a1-fe1f-47df-9a32-b5346b289391"),
                Status = Status.Live,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(19),
                Item = new Item
                {
                    Make = "Audi",
                    Model = "R8",
                    Color = "Silver",
                    Mileage = 10050,
                    Year = 2021,
                    ImageUrl = "https://images.unsplash.com/photo-1603584173870-7f23fdae1b7a?w=1280"
                }
            },
            // 9 Audi TT
            new() {
                Id = Guid.Parse("40490065-dac7-46b6-acc4-df507e0d6570"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(20),
                Item = new Item
                {
                    Make = "Audi",
                    Model = "TT",
                    Color = "White",
                    Mileage = 25400,
                    Year = 2020,
                    ImageUrl = "https://images.unsplash.com/photo-1617195920791-e42b4d1e559a?w=1280"
                }
            },
            // 10 Ford Model T
            new() {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b9b"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(48),
                Item = new Item
                {
                    Make = "Ford",
                    Model = "Model T",
                    Color = "Green",
                    Mileage = 150150,
                    Year = 1938,
                    ImageUrl = "https://images.unsplash.com/photo-1563137391-0030ae24bc35?w=1280"
                }
            },
            // 
            new() {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b91"),
                Status = Status.Live,
                ReservePrice = 10000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(12),
                Item = new Item
                {
                    Make = "Aston Martin",
                    Model = "Convertible",
                    Color = "White",
                    Mileage = 150,
                    Year = 2016,
                    ImageUrl = "https://images.unsplash.com/photo-1469285994282-454ceb49e63c?&w=1280"
                }
            },
            new() {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b92"),
                Status = Status.Live,
                ReservePrice = 1000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(18),
                Item = new Item
                {
                    Make = "Volkswagen",
                    Model = "Beetle",
                    Color = "White",
                    Mileage = 23100,
                    Year = 2003,
                    ImageUrl = "https://images.unsplash.com/photo-1490985830292-06e0fe60d725?w=1280"
                }
            },
            new() {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b93"),
                Status = Status.Live,
                ReservePrice = 12000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(18),
                Item = new Item
                {
                    Make = "Porche",
                    Model = "911 Carrera",
                    Color = "Yellow",
                    Mileage = 11111,
                    Year = 2016,
                    ImageUrl = "https://images.unsplash.com/photo-1662123312343-db45a3324981?w=1280"
                }
            },
            new() {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b94"),
                Status = Status.Live,
                ReservePrice = 60000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(7),
                Item = new Item
                {
                    Make = "Toyota",
                    Model = "Hydrogen concept",
                    Color = "White",
                    Mileage = 11111,
                    Year = 2019,
                    ImageUrl = "https://images.unsplash.com/photo-1555550252-fc3187f10240?&w=1280"
                }
            },
            new() {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b95"),
                Status = Status.Live,
                ReservePrice = 12000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(11),
                Item = new Item
                {
                    Make = "Toyota",
                    Model = "Camry",
                    Color = "Blue",
                    Mileage = 2100,
                    Year = 2020,
                    ImageUrl = "https://images.unsplash.com/photo-1588440983028-d53e24fa96cc?w=1280"
                }
            },
            new() {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b96"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(22),
                Item = new Item
                {
                    Make = "Honda",
                    Model = "Civic Type R",
                    Color = "Red",
                    Mileage = 100000,
                    Year = 2022,
                    ImageUrl = "https://images.unsplash.com/photo-1681392352631-354ed229191f?w=1280"
                }
            },
            new() {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b97"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(15),
                Item = new Item
                {
                    Make = "MiniCooper",
                    Model = "Cabriolette",
                    Color = "Black",
                    Mileage = 51000,
                    Year = 2018,
                    ImageUrl = "https://images.unsplash.com/photo-1623703985638-d4530c062523?&w=1280"
                }
            },
            new() {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b98"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(14),
                Item = new Item
                {
                    Make = "Bugatti",
                    Model = "Veyron",
                    Color = "Green",
                    Mileage = 42000,
                    Year = 2014,
                    ImageUrl = "https://images.unsplash.com/photo-1662240879431-79a572af18f7?&w=1280"
                }
            }
        };

        context.AddRange(auctions);
        context.SaveChanges();
    }
}
