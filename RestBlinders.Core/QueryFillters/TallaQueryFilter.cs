using System;

namespace RestBlinders.Core.QueryFillters
{
    public class TallaQueryFilter
    { 
        public string TALLA_DESCRIPCION { get; set; } 
        public DateTime? CREATED_AT { get; set; }
        public DateTime? UPDATE_AT { get; set; } 
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
    }
}
