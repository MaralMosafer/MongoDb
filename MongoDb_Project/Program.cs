using MongoDb_Project.Entities;
using MongoDb_Project.Repositories;

ProductRepository product = new();

product.Add(new Product
{
    Category = "لپ تاپ",
    Description = "این لپ تاپ خیلی خفنه بچه ها پس باید گیتموفالو کنید:|",
    Name = "ایسوس فلان فلان",
    Price = 40000000,
});

var getProducts = product.GetList();
foreach (var prd in getProducts)
{
    Console.WriteLine($"Id:{prd.Id} Name:{prd.Name} ");
}

Console.ReadKey();