using System;
using System.Collections.Generic;
 

namespace RestBlinders.Core.Entities
{
    public partial class InvColore
    {
        public int ColorCodigo { get; set; }
        public string ColorDescripcion { get; set; }
        public string ColorCodigoHtml { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
