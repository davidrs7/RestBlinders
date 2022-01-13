using System;
using System.Collections.Generic;
 

namespace RestBlinders.Core.Entities
{
    public partial class InvTipiden
    {
        public InvTipiden()
        {
            InvVendedores = new HashSet<InvVendedore>();
        }

        public int TipidenCodigo { get; set; }
        public string TipidenDesctipcion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<InvVendedore> InvVendedores { get; set; }
    }
}
