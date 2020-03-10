using System;
using System.Collections.Generic;
using System.Text;

namespace FacetsChecker
{

    public class ESDataModel
    {
        public Respons[] responses { get; set; }
    }

    public class Respons
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public _Shards _shards { get; set; }
        public Hits hits { get; set; }
        public Aggregations aggregations { get; set; }
        public int status { get; set; }
    }

    public class _Shards
    {
        public int total { get; set; }
        public int successful { get; set; }
        public int skipped { get; set; }
        public int failed { get; set; }
    }

    public class Hits
    {
        public int total { get; set; }
        public object max_score { get; set; }
        public Hit[] hits { get; set; }
    }

    public class Hit
    {
        public string _index { get; set; }
        public string _type { get; set; }
        public string _id { get; set; }
        public int _version { get; set; }
        public object _score { get; set; }
        public _Source _source { get; set; }
        public Fields fields { get; set; }
        public Highlight highlight { get; set; }
        public long[] sort { get; set; }
    }

    public class _Source
    {
        public string id { get; set; }
        public DateTime log_time { get; set; }
        public int pid { get; set; }
        public string machine { get; set; }
        public object app_domain { get; set; }
        public string type { get; set; }
        public object msg { get; set; }
        public string app_name { get; set; }
        public string tid { get; set; }
        public string cid { get; set; }
        public string sid { get; set; }
        public string app_txid { get; set; }
        public string log_sink { get; set; }
        public string url { get; set; }
        public string api { get; set; }
        public string verb { get; set; }
        public string status { get; set; }
        public float time_taken_ms { get; set; }
        public string txid { get; set; }
        public string request { get; set; }
        public string response { get; set; }
        public object client_ip { get; set; }
        public Json_Rq_Headers json_rq_headers { get; set; }
        public Json_Rs_Headers json_rs_headers { get; set; }
        public int http_status_code { get; set; }
        public string http_method { get; set; }
        public string session_id { get; set; }
        public string cnxagencyTenantId { get; set; }
        public string cnxclientTenantId { get; set; }
        public DateTime time_stamp { get; set; }
    }

    public class Json_Rq_Headers
    {
        public string Pragma { get; set; }
        public string ContentType { get; set; }
        public string Accept { get; set; }
        public string AcceptEncoding { get; set; }
        public string AcceptLanguage { get; set; }
        public string Host { get; set; }
        public string ContentLength { get; set; }
        public string XForwardedFor { get; set; }
        public string XForwardedProto { get; set; }
        public string XForwardedPort { get; set; }
        public string XAmznTraceId { get; set; }
        public string cnxcorrelationId { get; set; }
        public string cnxenvironmenttoken { get; set; }
        public string cnxtenantId { get; set; }
        public string XdynaTrace { get; set; }
    }

    public class Json_Rs_Headers
    {
        public string ContentType { get; set; }
        public string cnxcorrelationId { get; set; }
        public string transactionId { get; set; }
        public string stackId { get; set; }
    }

    public class Fields
    {
        public DateTime[] time_stamp { get; set; }
        public DateTime[] log_time { get; set; }
    }

    public class Highlight
    {
        public string[] app_name { get; set; }
        public string[] verb { get; set; }
        public string[] api { get; set; }
    }

    public class Aggregations
    {
        public _2 _2 { get; set; }
    }

    public class _2
    {
        public Bucket[] buckets { get; set; }
    }

    public class Bucket
    {
        public DateTime key_as_string { get; set; }
        public long key { get; set; }
        public int doc_count { get; set; }
    }

}
