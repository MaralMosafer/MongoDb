using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb_Project.Entities
{
    public class Product
    {
        [BsonId] //مپ میشه به آیدی مونگو
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public int Price { get; set; }
    }
}
