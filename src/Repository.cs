using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minify.Interfaces;
using Minify.Model;

namespace Minify
{
    public class Repository : IRepository
    {
        private static List<MinifyData> collection = new List<MinifyData>();
        private TokenGenerator tokengenerator = new TokenGenerator();
        
        public void Add(MinifyData minifyData)
        {
            minifyData._id = tokengenerator.Generate();
            collection.Add(minifyData);
        }

        public IEnumerable<MinifyData> Get()
        {
            return collection;
        }

        public Task<MinifyData> Get(string key)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string key)
        {
            var filtered = collection.Single(k => k._id == key);
            collection.Remove(filtered);
        }
    }
}