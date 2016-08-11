using NLog;
using System;

namespace AgilePartner.NLog.ElasticSearch
{
    internal class Document
    {
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }
}
