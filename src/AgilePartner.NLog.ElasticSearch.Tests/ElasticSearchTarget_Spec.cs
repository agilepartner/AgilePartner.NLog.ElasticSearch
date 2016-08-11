using AgilePartner.NLog.ElasticSearch;
using NLog;
using NLog.Config;
using System.Linq;
using System;
using Xunit;
using Nest;
using System.Threading.Tasks;

namespace AgilePartner.NLog.ElasticSearch.Tests
{
    public class ElasticSearchTarget_Spec
    {
        private readonly ILogger _logger;

        public ElasticSearchTarget_Spec()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        [Fact]
        public void Is_able_to_log_in_elastic_search()
        {
            var exception = new ArgumentException("I am an argument exception", "A parameter");
            _logger.Fatal(exception, "An exception occured");
            LogManager.Flush();
        }        
    }
}