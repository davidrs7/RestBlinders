using System;
using System.Collections.Generic;
 

namespace RestBlinders.Core.Entities
{
    public partial class InvVendedore
    {
        public int VendedorCodigo { get; set; }
        public string VendedorNombres { get; set; }
        public string VendedorApellidos { get; set; }
        public string VendedorTelefono { get; set; }
        public int VendedorTipiden { get; set; }
        public string VendedorIdentificacion { get; set; }
        public string VendedorDireccion { get; set; }
        public int VendedorActivo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual InvTipiden VendedorTipidenNavigation { get; set; }
    }
}
