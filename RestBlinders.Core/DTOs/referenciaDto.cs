using System;
using System.Collections.Generic;
using System.Text;

namespace RestBlinders.Core.DTOs
{
    public class referenciaDto
    {
        public int RefCodigo { get; set; }
        public string regDescripcion { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updateAt { get; set; }
    }
}
