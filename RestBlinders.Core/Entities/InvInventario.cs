using System;
using System.Collections.Generic;



namespace RestBlinders.Core.Entities
{
    public partial class InvInventario
    {
 
        public int InventarioCodigo { get; set; }
        public int RefCodigo { get; set; }
        public int TallaCodigo { get; set; }
        public int ColorCodigo { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual InvColore ColorCodigoNavigation { get; set; }
        public virtual InvReferencia RefCodigoNavigation { get; set; }
        public virtual InvTalla TallaCodigoNavigation { get; set; }
    }
}
