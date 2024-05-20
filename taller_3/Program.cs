using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using MongoDB.Driver;
using taller_3.modelo;
using taller_3.vista;
namespace taller_3
{
    internal static class Program
    {

        [STAThread]
        static async Task Main()
        {

            
            /*string connectionString = "mongodb+srv://fabianestebanlopez:w0gL53byZIqqlWUf@cluster0.atizgdw.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            string databaseName = "universidad";
            string collectionName = "Estudiante";

            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<Estudiante>(collectionName);*/

            //Estudiante objE = new Estudiante { nombre1 = "Geraldine", nombre2 = "alejandra", apellido1 = "flores", apellido2 = "villaroel", codigo = "15", fechaIngreso = "2-11-2012", carrera = "comunicacion" };
            
            //await collection.InsertOneAsync(objE);

            //var estudiantes = await collection.Find(_ => true).ToListAsync();
            /*foreach (var estudiante in estudiantes)
            {
                Console.WriteLine($"Nombre: {estudiante.nombre1} {estudiante.nombre2} Apellido: {estudiante.apellido1} {estudiante.apellido2}");
            }*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new UIConsultaEstudiantes());
            //Application.Run(new UIInsertEstudiante());
         //   Application.Run(new UIUpdateEstudiante());
            Application.Run(new Principal());
        }
    }
}
