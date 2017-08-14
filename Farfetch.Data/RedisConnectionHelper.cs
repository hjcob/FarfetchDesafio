using System;
using System.Configuration;
using StackExchange.Redis;

namespace Farfetch.Data
{
    public class RedisConnectorHelper
    {
        static RedisConnectorHelper()
        {
            var cacheConnection =
                "pub-redis-11088.eu-central-1-1.1.ec2.redislabs.com:11088,abortConnect=false,ssl=false,password=@ika641!";
            RedisConnectorHelper._lazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(cacheConnection));
        }

        private static Lazy<ConnectionMultiplexer> _lazyConnection;

        public static ConnectionMultiplexer Connection => _lazyConnection.Value;
    }
}
