using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace taller_3.modelo
{
    class Estudiante
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public  string idEstudiante { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string codigo { get; set; }
        public string fechaIngreso { get; set; }
        public string carrera { get; set; }

        public Estudiante()
        {
        }

        public Estudiante(string idEstudiante, string nombre1, string nombre2, string apellido1, string apellido2, string codigo, string fechaIngreso, string carrera)
        {
            this.idEstudiante = idEstudiante;
            this.nombre1 = nombre1;
            this.nombre2 = nombre2;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.codigo = codigo;
            this.fechaIngreso = fechaIngreso;
            this.carrera = carrera;
        }

        public Estudiante(string nombre1, string nombre2, string apellido1, string apellido2, string codigo, string fechaIngreso, string carrera)
        {
            this.nombre1 = nombre1;
            this.nombre2 = nombre2;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.codigo = codigo;
            this.fechaIngreso = fechaIngreso;
            this.carrera = carrera;
        }
    }
}
