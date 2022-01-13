using System;
using System.Collections.Generic;
using System.Text;

namespace RestBlinders.Core.DTOs
{
   public class inventarioDto
    {
        public int InventarioCodigo { get; set; }
        public int refCodigo { get; set; }
        public string refDesc { get; set; }
        public int tallaCodigo { get; set; }
        public string tallaDesc { get; set; }
        public int colorCodigo { get; set; }
        public string colorDesc { get; set; }
        public int cantidad { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updateAt { get; set; }
    }
}
