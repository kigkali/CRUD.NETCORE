using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class GestoresBd
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Lanzamiento { get; set; }
        public string Desarrollador { get; set; }
    }
}
