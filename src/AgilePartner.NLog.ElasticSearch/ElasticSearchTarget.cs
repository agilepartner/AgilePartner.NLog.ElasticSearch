using Nest;
using NLog;
using NLog.Common;
using NLog.Config;
using NLog.Targets;
using System;
using System.Threading.Tasks;

namespace AgilePartner.NLog.ElasticSearch
{
    [Target("ElasticSearch")]
    internal class ElasticSearchTarget : TargetWithLayout
    {
        private ElasticClient _elasticClient;

        [RequiredParameter]
        public string Uri { get; set; }

        [RequiredParameter]
        public string Index { get; set; }

        [RequiredParameter]
        public string DocumentType { get; set; }
        
        protected override void InitializeTarget()
        {
            base.InitializeTarget();
            _elasticClient = ElasticSearchClientFactory.Create(Uri, Index);
        }

        protected async override void Write(AsyncLogEventInfo logEvent)
        {
            try
            {
                var document = ToDocument(logEvent.LogEvent);
                var response = await _elasticClient.IndexAsync(document, i => i.Type(DocumentType));

                if (!response.IsValid)
                {
                    InternalLogger.Error($"ElasticSearch logger : failed to index \n{response.OriginalException?.Message}");
                }
            }
            catch (Exception exception)
            {
                InternalLogger.Error(exception, $"ElasticSearch logger thrown an exception");
            }
        }

        private Document ToDocument(LogEventInfo logEvent)
        {
            Document document = new Document
            {
                Message = Layout.Render(logEvent),
                Level = logEvent.Level.ToString(),
                Timestamp = logEvent.TimeStamp,
            };

            return document;
        }
    }
}