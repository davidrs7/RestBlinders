using System;

namespace RestBlinders.Core.QueryFillters
{
    public class ReferenciaQueryFilter
    { 
        public string REF_DESCRIPCION { get; set; } 
        public DateTime? CREATED_AT { get; set; }
        public DateTime? UPDATE_AT { get; set; } 
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
    }
}
