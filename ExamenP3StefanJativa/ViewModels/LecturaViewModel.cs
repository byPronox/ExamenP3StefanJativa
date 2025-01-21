using CommunityToolkit.Mvvm.ComponentModel;
using ExamenP3StefanJativa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenP3StefanJativa.Services;

namespace ExamenP3StefanJativa.ViewModels
{
    public partial class LecturaViewModel : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        [ObservableProperty]
        private ObservableCollection<Pelicula> peliculas;

        public LecturaViewModel()
        {
            _databaseService = App.Database;
            CargarPeliculas();
        }

        public async Task CargarPeliculas()
        {
            var listaPeliculas = await _databaseService.ObtenerPelicualsAsync();
            Peliculas = new ObservableCollection<Pelicula>();

            foreach (var pelicula in listaPeliculas)
            {
                Peliculas.Add(new Pelicula
                {
                    TituloPelicula = pelicula.TituloPelicula,
                    Genero = pelicula.Genero,
                    ActorPrincal = pelicula.ActorPrincal,
                    Awards = pelicula.Awards,
                    Webside = pelicula.Webside,
                    Descripcion = $"Titulo: {pelicula.TituloPelicula}, Genero: {pelicula.Genero}, Actor Principal: {pelicula.ActorPrincal}, Awards: {pelicula.Awards}, Webside: {pelicula.Webside}"
                });
            }
        }

        public async Task ActualizarPeliculas()
        {
            await CargarPeliculas();
        }
    }
}
