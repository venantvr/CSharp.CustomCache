using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Web;
using CustomCache;
using MSTestExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void should_associate_key_value_objects_in_a_list_and_restore_back_objects_afterwards()
        {
            var data_1 = new { name = "data_1", value = 1.0M };
            var data_2 = new { name = "data_2", value = @"hello" };

            var cache = new CustomCacheProvider();

            cache.Add(data_1.name, data_1.value);
            cache.Add(data_2.name, data_2.value);

            Assert.IsTrue(cache.Count() == 2);
            Assert.IsTrue(cache.GetObject<Decimal>("data_1") == 1.0M);
            Assert.IsTrue(cache.GetObject<string>("data_2") == @"hello");
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int GetLastError();

        [TestMethod]
        [ExpectedException(typeof (Exception), @"Clé déjà présente")]
        public void should_associate_key_value_objects_in_a_list_and_keys_must_be_unique_and_throw_an_exception_on_insert_if_not_1()
        {
            var data_1 = new { name = "data_1", value = 1.0M };
            var data_2 = new { name = "data_2", value = @"hello" };
            var data_3 = new { name = "data_2", value = @"hello" };

            var cache = new CustomCacheProvider();

            cache.Add(data_1.name, data_1.value);
            cache.Add(data_2.name, data_2.value);
            cache.Add(data_3.name, data_3.value);
        }

        [TestMethod]
        public void should_associate_key_value_objects_in_a_list_and_keys_must_be_unique_and_throw_an_exception_on_insert_if_not_2()
        {
            var data_1 = new { name = "data_1", value = 1.0M };
            var data_2 = new { name = "data_2", value = @"hello" };
            var data_3 = new { name = "data_2", value = @"hello" };

            var cache = new CustomCacheProvider();

            cache.Add(data_1.name, data_1.value);
            cache.Add(data_2.name, data_2.value);

            ExceptionAssert.Throws(() => cache.Add(data_3.name, data_3.value));

            Assert.IsTrue(cache.Count() == 2);
            Assert.IsTrue(cache.GetObject<Decimal>("data_1") == 1.0M);
            Assert.IsTrue(cache.GetObject<string>("data_2") == @"hello");
        }

        [TestMethod]
        public void should_associate_key_value_objects_in_a_list_and_objects_must_be_unique_and_implement_cache_methods()
        {
            //public static readonly DateTime NoAbsoluteExpiration;
            //public static readonly TimeSpan NoSlidingExpiration;
            //public Cache();
            //public int Count { get; }
            //public long EffectivePercentagePhysicalMemoryLimit { get; }
            //public long EffectivePrivateBytesLimit { get; }
            //public object this[string key] { get; set; }
            //public object Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);
            //public object Get(string key);
            //public IDictionaryEnumerator GetEnumerator();
            //public void Insert(string key, object value);
            //public void Insert(string key, object value, CacheDependency dependencies);
            //public void Insert(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration);
            //public void Insert(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemUpdateCallback onUpdateCallback);
            //public void Insert(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);
            //public object Remove(string key);
        }

        //[TestMethod]
        //public void should_be_parameterized_in_config_file()
        //{

        //}

        //[TestMethod]
        //public void should_be_disposable_and_clean_key_value_list()
        //{

        //}

        //[TestMethod]
        //public void should_be_disposable_and_clean_key_value_list_and_thread_static()
        //{

        //}

        //[TestMethod]
        //public void should_always_instanciate_with_csharp_operator_and_not_with_config_file()
        //{

        //}
    }
}

// ReSharper restore InconsistentNaming