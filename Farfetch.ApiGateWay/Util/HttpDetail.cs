using System;
using System.Collections.Generic;

namespace Farfetch.ApiGateWay.Core.Util
{
    public sealed class HttpDetail
    {
        public HttpDetail()
        {
            TrackingId = Guid.NewGuid();
            CallDateTime = DateTime.UtcNow;
        }
        
        public Guid TrackingId { get; private set; }

        public string CallerIdentity { get; set; }
        
        public DateTime CallDateTime { get; set; }

        public string Verb { get; set; }

        public Uri RequestUri { get; set; }

        public IDictionary<String, String[]> RequestHeaders { get; set; }

        public long RequestLength { get; set; }

        public string Request { get; set; }

        public int StatusCode { get; set; }

        public string ReasonPhrase { get; set; }

        public IDictionary<String, String[]> ResponseHeaders { get; set; }
        
        public long ResponseLength { get; set; }
        
        public string Response { get; set; }
        public TimeSpan CallDuration { get; set; }
    }
}
