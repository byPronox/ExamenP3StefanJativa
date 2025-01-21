using SQLite;

namespace ExamenP3StefanJativa.Models
{
    public class Pelicula
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TituloPelicula { get; set; }
        public string Genero { get; set; }
        public string ActorPrincal { get; set; }
        public string Awards { get; set; }
        public string Webside { get; set; }
        public string Descripcion { get; set; }
    }
}
