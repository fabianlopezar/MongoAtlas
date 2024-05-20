using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MongoDB.Driver;
using taller_3;

namespace taller_3.modelo
{

    class ConnectDBMysql
    {
        public MySqlConnection connManager;
        string server = "127.0.0.1;";
        string database = "taller_3;";
        string user = "root;";
        string pass = "maxwell55A@;";
        //variables mongo
        string connectionString = "mongodb+srv://fabianestebanlopez:w0gL53byZIqqlWUf@cluster0.atizgdw.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        string databaseName = "universidad";
        string collectionName = "Estudiante";


        //------------------------------------------- Connect Mongo ------------------------------------------------------------------
        public async Task<List<Estudiante>> ConsultaEstudiantesAsync()
        {
            List<Estudiante> listaEstudiantes = new List<Estudiante>();
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<Estudiante>(collectionName);

            var estudiantes = await collection.Find(_ => true).ToListAsync();
            foreach (var elem in estudiantes)
            {
                Console.WriteLine($"Nombre: {elem.nombre1} {elem.nombre2} Apellido: {elem.apellido1} {elem.apellido2}");
                string idEstudiante = elem.idEstudiante;
                string nombre1 = elem.nombre1;
                string nombre2 = elem.nombre2;
                string apellido1 = elem.apellido1;
                string apellido2 = elem.apellido2;
                string codigo = elem.codigo;
                string fechaIngreso = elem.fechaIngreso;
                string carrera = elem.carrera;
                Estudiante objEstudiante = new Estudiante(idEstudiante, nombre1, nombre2, apellido1, apellido2, codigo, fechaIngreso, carrera);
                listaEstudiantes.Add(objEstudiante);
            }
            return listaEstudiantes;
        }
        public async Task InsertEstudianteAsync(Estudiante objEstudiante)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<Estudiante>(collectionName);
            
            await collection.InsertOneAsync(objEstudiante);
        }
        public async Task UpdateEstudianteAsync(string idEstudiante, Estudiante updatedEstudiante)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<Estudiante>(collectionName);

            // Crear un filtro para encontrar el estudiante por id
            var filter = Builders<Estudiante>.Filter.Eq(e => e.idEstudiante, idEstudiante);
            // Crear la definición de actualización con los nuevos valores del estudiante
            var update = Builders<Estudiante>.Update
                .Set(e => e.nombre1, updatedEstudiante.nombre1)
                .Set(e => e.nombre2, updatedEstudiante.nombre2)
                .Set(e => e.apellido1, updatedEstudiante.apellido1)
                .Set(e => e.apellido2, updatedEstudiante.apellido2)
                .Set(e => e.codigo, updatedEstudiante.codigo)
                .Set(e => e.fechaIngreso, updatedEstudiante.fechaIngreso)
                .Set(e => e.carrera, updatedEstudiante.carrera);
            // Ejecutar la actualización en la colección de estudiantes
            await collection.UpdateOneAsync(filter, update);
        }

        //------------------------------------------- Fin Connect Mongo ------------------------------------------------------------------
        #region MySql Connection
        public MySqlConnection DataSource()
        {
            connManager = new MySqlConnection
                ($"server={server} database={database} Uid={user} password={pass}");
            return connManager;
        }

        internal List<Estudiante> SelectEstudiante(string sql)
        {
            List<Estudiante> listaEstudiantes = new List<Estudiante>();

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, DataSource());
                ConnectOpened();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string idEstudiante = reader.GetInt32(0).ToString();
                        string nombre1 = reader.GetString(1);
                        string nombre2 = reader.GetString(2);
                        string apellido1 = reader.GetString(3);
                        string apellido2 = reader.GetString(4);
                        string codigo = reader.GetString(5);
                        string fechaIngreso = reader.GetDateTime(6).ToString("yyyy-MM-dd HH:mm:ss");
                        string carrera = reader.GetString(7);

                        Estudiante objEstudiante = new Estudiante(idEstudiante, nombre1, nombre2, apellido1, apellido2, codigo, fechaIngreso, carrera);
                        listaEstudiantes.Add(objEstudiante);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROOOOOOR " + e.Message);
                ConnectClosed();
            }
            finally
            {
                ConnectClosed();
            }

            return listaEstudiantes;
        }

        /*internal bool ExecuteQueryImage(string sql, string imagenC)
        {

            bool result = false;
            FileStream fs;
            BinaryReader br;
            try
            {
                byte[] ImageData;
                fs = new FileStream(imagenC, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                ImageData = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();

                MySqlCommand cmd = new MySqlCommand(sql, DataSource());
                //ConnectOpened();
                cmd = new MySqlCommand(sql, DataSource());
                cmd.Parameters.Add("@fotoCostumer", MySqlDbType.LongBlob);
                cmd.Parameters["@fotoCostumer"].Value = ImageData;

                ConnectOpened();
                int RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    result = true;

                }

            }
            catch (Exception w)
            {
                Console.WriteLine("ERROOOOOOR " + w.Message);

                ConnectClosed();
            }
            finally
            {
                ConnectClosed();
            }
            return result;

        }*/

        public bool ExecuteQuery(string sql)
        {
            bool result = false;

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, DataSource());
                ConnectOpened();

                cmd.ExecuteNonQuery();
                result = true;
                //ConnectClosed();
            }
            catch (Exception w)
            {
                Console.WriteLine("ERROOOOOOR " + w.Message);

                ConnectClosed();
            }
            finally
            {
                ConnectClosed();
            }
            return result;
        }

        public void ConnectOpened()
        {
            //DataSource();
            connManager.Open();
        }
        public void ConnectClosed()
        {
            DataSource();
            connManager.Close();
        }
        #endregion Fin MySql 
    }
}
