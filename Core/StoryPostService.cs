
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Shared;
using MongoDB.Driver.Builders;

namespace StoryPicker.Core
{
    public class StoryPostService
    {
        public MongoHelper<StoryPost> _storyPostHelper = new MongoHelper<StoryPost>();
        public void createStoryPost(StoryPost storyPost)
        {
            storyPost.Comments = new List<Comment>();
            _storyPostHelper.Collection.Save(storyPost);
        }

        public IList<StoryPost> getStoryPosts()
        {
            return _storyPostHelper.Collection.FindAll().ToList();
        }

        public IList<String> getStoryPostTitles()
        {
            
            var cursor = _storyPostHelper.Collection.FindAll();
            cursor.SetFields(Fields.Include("Title"));
            IList<String> str = new List<String>();
            foreach(var storyPost in cursor)
            {
                str.Add(storyPost.Title);
            }
            return str;
        }
    }
}