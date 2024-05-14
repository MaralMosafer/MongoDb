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
    }
}
