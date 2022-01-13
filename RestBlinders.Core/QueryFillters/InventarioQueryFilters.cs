using System;

namespace RestBlinders.Core.QueryFillters
{
    public class InventarioQueryFilters
    {
        public int? refCodigo { get; set; }
        public int? tallaCodigo { get; set; }
        public int? colorCodigo { get; set; }
        public int? cantidad { get; set; }
        public DateTime? date { get; set; }

        public int pageSize { get; set; }
        public int pageNumber { get; set; }
    }
}
