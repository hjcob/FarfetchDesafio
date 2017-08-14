using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using StackExchange.Redis;

namespace Farfetch.Data
{
    public static class RedisManager
    {
        public static bool BlockService(string servicePath)
        {
            var service = MockDictionaryServices.GetIdServiceByPath(servicePath);
            return SaveData(service);
        }

        public static bool UnblockService(string servicePath)
        {
            var service = MockDictionaryServices.GetIdServiceByPath(servicePath);
            return DeleteData(service);
        }

        public static void BlockAllServices()
        {
            var services = MockDictionaryServices.GetServices();
            foreach (var service in services)
            {
                var item = MockDictionaryServices.GetIdServiceByPath(service.Value);
                SaveData(item);
            }
        }

        public static void UnblockAllServices()
        {
            var services = MockDictionaryServices.GetServices();
            foreach (var service in services)
            {
                var item = MockDictionaryServices.GetIdServiceByPath(service.Value);
                DeleteData(item);
            }
        }

        public static bool ServiceIsBlocked(string servicePath)
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase(1);
            var service = MockDictionaryServices.GetIdServiceByPath(servicePath);

            if (string.IsNullOrEmpty(service.Key))
                return false;

            var returnValue = !cache.StringGet(service.Key).IsNull;
            return returnValue;
        }


        #region Private Methods
        private static bool SaveData(KeyValuePair<string, string> service)
        {
            return RedisConnectorHelper.Connection.GetDatabase(1).StringSet(service.Key, service.Value);
        }

        private static bool DeleteData(KeyValuePair<string, string> service)
        {
            return RedisConnectorHelper.Connection.GetDatabase(1).KeyDelete(service.Key);
        }
        #endregion

    }


    public static class MockDictionaryServices
    {
        public static Dictionary<string, string> GetServices()
        {
            var services = new Dictionary<string, string>()
            {
                { "c852dc45-aa10-463b-9dcd-528fd370bb1e", "v1/MultiplyValueBy10"},
                { "5951a717-0fad-45e8-9aed-b7447d85dadb", "v1/MultiplyValueBy7"},
                { "f10520b2-f3c4-444c-b332-8952fc587d27", "v1/DivisionValueBy10"},
                { "79a67ab5-e6e2-45c7-8043-41fea63e983d", "v1/DivisionValueBy7"},
                { "984d4c15-f4e3-47d4-b950-629635472a61", "v2/StringLenght"}
            };

            return services;
        }

        public static KeyValuePair<string, string> GetIdServiceByPath(string path)
        {
            var services = GetServices();
            var id = (from item in services where path.Contains(item.Value) select  item).FirstOrDefault();
            return id;
        }
    }
}
