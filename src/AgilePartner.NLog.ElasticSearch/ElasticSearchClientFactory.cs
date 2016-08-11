using Nest;
using System;

namespace AgilePartner.NLog.ElasticSearch
{
    internal static class ElasticSearchClientFactory
    {
        public static ElasticClient Create(string uri, string index)
        {
            Uri elasticUri = null;

            if (!UriHelper.TryCreateUri(uri, out elasticUri))
            {
                throw new ArgumentException($"'{uri}' is not a valid uri", "uri");
            }

            var settings = new ConnectionSettings(elasticUri);
            settings.DefaultIndex(index);

            return new ElasticClient(settings);
        }
    }
}