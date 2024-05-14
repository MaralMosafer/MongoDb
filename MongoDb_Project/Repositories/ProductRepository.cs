using MongoDB.Bson;
using MongoDB.Driver;
using MongoDb_Project.Entities;

namespace MongoDb_Project.Repositories
{
    public class ProductRepository
    {
        private readonly IMongoDatabase _db;
        //تایپ داکیومنت توی برنامه چیه
        private readonly IMongoCollection<Product> _productCollection;

        public ProductRepository()
        {
            //میتونه متصل شه به دیتابیس
            var client = new MongoClient();

            //دیتابیس
            _db = client.GetDatabase("MongoStore");

            //کالکشن-جداول
            _productCollection = _db.GetCollection<Product>("Product");
        }

        #region Insert
        public void Add(Product product)
        {
            _productCollection.InsertOne(product);
        }
        #endregion

        #region List
        public List<Product> GetList()
        {
            return _productCollection.Find(new BsonDocument()).ToList();
        }
        #endregion

        #region Search By Id
        public Product FinddBy(Guid Id)
        {
            //Equal
            //فیلد آیدی برابر باشه با آیدی که دریافت کردم
            var filter = Builders<Product>.Filter.Eq("Id", Id);
            return _productCollection.Find(filter).FirstOrDefault();
        }
        #endregion

        #region Update
        public void Edit(Guid Id, Product product)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, Id);

            var updatedProduct = Builders<Product>.Update
                .Set(p => p.Name, product.Name)
                .Set(p => p.Description, product.Description)
                .Set(p => p.Category, product.Category)
                .Set(p => p.Price, product.Price);

            var result = _productCollection.UpdateOne(filter, updatedProduct);

            if (result.MatchedCount == 1 && result.ModifiedCount == 1)
                Console.WriteLine("Updated:)");
        }
        #endregion
    }
}
