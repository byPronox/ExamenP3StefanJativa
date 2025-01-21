using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ExamenP3StefanJativa.Models
{
    internal class Pelicula
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TituloPelicula { get; set; }
        public string Genero { get; set; }
        public string ActorPrincal { get; set; }
        public string Awards { get; set; }
        public string Webside { get; set; }
        public string Usuario { get; set; } = "SJativa";
        public string Descripcion { get; set; }
    }
}
