using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace CustomCache
{
    public class CustomCacheProvider
    {
        private readonly List<KeyValuePair<string, object>> _pairs;

        public CustomCacheProvider()
        {
            _pairs = new List<KeyValuePair<string, object>>();
        }

        public void Add(string key, object something)
        {
            if (_pairs.All(p => p.Key != key))
            {
                _pairs.Add(new KeyValuePair<string, object>(key, something));
            }
            else
            {
                throw new Exception("Clé déjà présente");
            }
        }

        public int Count()
        {
            return _pairs.Count;
        }

        public T GetObject<T>(string data)
        {
            return (T) _pairs.FirstOrDefault(p => p.Key == data).Value;
        }
    }
}