using System;
using System.Collections.Generic;
 

namespace RestBlinders.Core.Entities
{
    public partial class InvTalla
    {
        public int TallaCodigo { get; set; }
        public string TallaDescripcion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
