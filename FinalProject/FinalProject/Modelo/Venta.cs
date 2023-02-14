using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Modelo
{
    internal class Venta
    {
        public long Id { get; set; }

        public string Comentarios { get; set; }

        public long IdUsuario { get; set; }

        public Venta(long id, string comentarios, long idUsuario)
        {
            Id = id;
            Comentarios = comentarios;
            IdUsuario = idUsuario;
        }

        public Venta() { }


    }
}
