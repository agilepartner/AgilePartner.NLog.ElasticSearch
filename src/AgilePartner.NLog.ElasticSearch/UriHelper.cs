using System;
namespace AgilePartner.NLog.ElasticSearch
{
    internal class UriHelper
    {
        private const string _httpScheme = "http";
        private const string _httpsScheme = "https";
        
        public static bool TryCreateUri(string uri, out Uri resultUri)
        {
            resultUri = null;

            return Uri.TryCreate(uri, UriKind.Absolute, out resultUri) 
                && (resultUri.Scheme.ToLower() == _httpScheme || resultUri.Scheme.ToLower() == _httpsScheme);
        }
    }
}