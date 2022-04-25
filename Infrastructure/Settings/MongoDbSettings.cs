﻿namespace development.Infrastructure.Repositories
{
    public class MongoDbSettings
    {
        public string? DatabaseName { get; set; }
        public string? ConnectionString { get; set; }
        public string? CollectionName { get; set; }
    }
}