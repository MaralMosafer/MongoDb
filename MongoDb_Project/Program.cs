using MongoDb_Project.Entities;
using MongoDb_Project.Repositories;

ProductRepository productRepository = new();
//اینجا ایدی خودتون رو وارد کنید
var product = productRepository.FinddBy(Guid.Parse("Enter Your guid!"));

#region Add
productRepository.Add(new Product
{
    Category = "لپ تاپ",
    Description = "این لپ تاپ خیلی خفنه بچه ها پس باید گیتموفالو کنید:|",
    Name = "ایسوس فلان فلان",
    Price = 40000000,
});
#endregion

#region List
var getProducts = productRepository.GetList();
foreach (var prd in getProducts)
{
    Console.WriteLine($"Id:{prd.Id} Name:{prd.Name} ");
}
#endregion

#region Edit
if (product is not null)
{
    Console.WriteLine("Founded");
    product.Name = "نام جدید";
    product.Price = 10;
    product.Description = "توضیحات جدید";
    product.Category = "دسته بندی جدید";

    productRepository.Edit(product.Id, product);
}
#endregion

#region Delete
productRepository.Delete(product.Id);
#endregion

Console.ReadKey();