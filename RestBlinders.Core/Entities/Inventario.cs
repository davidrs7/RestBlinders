using System;
using System.Collections.Generic;
using System.Text;

namespace RestBlinders.Core.Entities
{
   public class Inventario
    {
       public int INVENTARIO_CODIGO { get; set; }
       public string REF_CODIGO { get; set; }
        public string TALLA_CODIGO  { get; set; }
        public string COLOR_CODIGO  { get; set; }
        public int CANTIDAD  { get; set; }
        public DateTime CREATED_AT  { get; set; }
        public DateTime UPDATE_AT { get; set; }
    }
}
