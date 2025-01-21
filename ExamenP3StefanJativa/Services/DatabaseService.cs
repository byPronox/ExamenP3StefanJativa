
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using ExamenP3StefanJativa.Models;

namespace BuscadorPaisesApp.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Pelicula>().Wait(); 
        }

        
        public Task<List<Pelicula>> ObtenerPeliculasAsync()
        {
            return _database.Table<Pelicula>().ToListAsync();
        }

        
        public Task<int> InsertarPeliculaAsync(Pelicula pelicula)
        {
            return _database.InsertAsync(pelicula);
        }
    }
}