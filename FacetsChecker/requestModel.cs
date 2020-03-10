using System;
using System.Collections.Generic;
using System.Text;

namespace FacetsChecker
{
    public class RequestModel
    {
        public string sessionId { get; set; }
        public Paging paging { get; set; }
        public Facet[] facets { get; set; }
        public string journeyType { get; set; }
        public bool comboFares { get; set; }
        public Customerinfo customerInfo { get; set; }
        public string outBoundFareOptionId { get; set; }
        public string fareOptionId { get; set; }
    }

    public class Paging
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public string orderBy { get; set; }
    }

    public class Customerinfo
    {
        public string id { get; set; }
        public int availablePointBalance { get; set; }
    }

    public class Facet
    {
        public string name { get; set; }
        public string type { get; set; }
        public Range[] ranges { get; set; }
    }

    public class Range
    {
        public string from { get; set; }
        public string to { get; set; }
    }

}
