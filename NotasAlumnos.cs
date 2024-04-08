using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio8
{
    internal class NotasAlumnos
    {
        string nombres;
        List<int> notas;

        public string Nombres { get => nombres; set => nombres = value; }
        public List<int> Notas { get => notas; set => notas = value; }
    }
}
