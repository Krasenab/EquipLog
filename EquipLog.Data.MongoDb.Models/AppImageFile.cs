
using MongoDB.Bson;

namespace EquipLog.Data.MongoDb.Models
{
    public class AppImageFile
    {
        public ObjectId Id { get; set; }
        public byte[] FileData { get; set; }
        public string UniqueName { get; set; }
    }
}
