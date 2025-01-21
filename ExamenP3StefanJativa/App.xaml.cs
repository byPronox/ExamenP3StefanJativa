using ExamenP3StefanJativa.Services;
using System.IO;

namespace ExamenP3StefanJativa
{
    public partial class App : Application
    {
        private static DatabaseService _database;

        public static DatabaseService Database
        {
            get
            {
                if (_database == null)
                {
                    
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "buscadorpeliculas.db3");
                    _database = new DatabaseService(dbPath);
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell(); 
        }
    }
}
