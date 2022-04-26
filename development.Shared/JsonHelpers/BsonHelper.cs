using MongoDB.Bson.Serialization;
using Newtonsoft.Json;

namespace development.Shared.JsonHelpers
{
    public static class BsonHelper
    {
        public static D BsonSerializereHelper<T, D>(T @object)
        {
            string jsonData;
            jsonData = JsonConvert.SerializeObject(@object);
            D document = BsonSerializer.Deserialize<D>(jsonData);
            return document;
        }
    }
}
