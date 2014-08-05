using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Configuration;

namespace StoryPicker
{
    public class MongoHelper<T> where T:class
    {
        public MongoCollection<T> Collection { get; set; }
        public MongoHelper()
        {
            var con = new MongoConnectionStringBuilder(ConfigurationManager.ConnectionStrings["StoryPicker.Properties.Settings.MongoDB"].ConnectionString);
            var server = MongoServer.Create(con);
            var db = server.GetDatabase(con.DatabaseName);
            Collection = db.GetCollection<T>(typeof(T).Name.ToLower());
        }
    }
}