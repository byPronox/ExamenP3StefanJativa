using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BuscadorPaisesApp.Models;
using BuscadorPaisesApp.Services;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ExamenP3StefanJativa.Models;


namespace ExamenP3StefanJativa.ViewModels
{
    public partial class BuscadorViewModel : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        [ObservableProperty]
        private string tituloPelicula;

        [ObservableProperty]
        private string resultadoBusqueda;

        public BuscadorViewModel()
        {
            _databaseService = App.Database;
        }

        [RelayCommand]
        public async Task BuscarPeliculaAsync()
        {
            if (string.IsNullOrWhiteSpace(TituloPelicula))
            {
                ResultadoBusqueda = "Por favor, ingresa un nombre de una Pelicula.";
                return;
            }

            try
            {
                var httpClient = new HttpClient();
                var url = $"https://freetestapi.com/api/v1/movies?search={NombrePelicula}?fields=title,genre,actors,awards,website";

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var peliculas = JsonSerializer.Deserialize<JsonElement>(jsonResponse);

                    if (peliculas.ValueKind == JsonValueKind.Array && peliculas.GetArrayLength() > 0)
                    {
                        var pelicula = peliculas[0];

                        var tituloPelicula = pelicula.GetProperty("title").GetString();
                        var genero = pelicula.GetProperty("genre").GetString();
                        var actorPrincipal = pelicula.GetProperty("actors").GetProperty("...").GetString();
                        var awards = pelicula.GetProperty("awards").GetString();
                        var webside = pelicula.GetProperty("website").GetString();

                        var nuevaPelicula = new Pelicula
                        {
                            TituloPelicula = tituloPelicula,
                            Genero = genero,
                            ActorPrincal = actorPrincipal,
                            Awards = awards,
                            Webside = webside
                        };

                        await _databaseService.InsertarPeliculaAsync(nuevaPelicula);

                        ResultadoBusqueda = $"Pelicula: {nuevaPelicula.TituloPelicula}\nGenero: {nuevaPelicula.Genero}\nActor Principal: {nuevaPelicula.ActorPrincal}\nAwards: {nuevaPelicula.Awards}\nWebside: {nuevaPelicula.Webside}";
                    }
                    else
                    {
                        ResultadoBusqueda = "No se encontró ningúna pelicula con ese nombre.";
                    }
                }
                else
                {
                    ResultadoBusqueda = $"Error: {response.StatusCode}. No se pudo buscar la pelicula.";
                }
            }
            catch (Exception ex)
            {
                ResultadoBusqueda = $"Error: {ex.Message}. Verifica tu conexión a internet.";
            }
        }



        [RelayCommand]
        public void LimpiarCampos()
        {
            TituloPelicula = string.Empty;
            ResultadoBusqueda = string.Empty;
        }
    }
}