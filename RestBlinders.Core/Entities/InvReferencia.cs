using System;
using System.Collections.Generic;
 

namespace RestBlinders.Core.Entities
{
    public partial class InvReferencia
    {
        public int RefCodigo { get; set; }
        public string RefDescripcion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
