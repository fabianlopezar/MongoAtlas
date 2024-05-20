using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taller_3.modelo;

namespace taller_3.controller
{
    class ControllerEstudiante
    {
      
        internal async Task<List<Estudiante>> SelectEstudiantesMongoAsync()
        {            
            ConnectDBMysql objConnect = new ConnectDBMysql();
            List<Estudiante> listaEstudiantes = await objConnect.ConsultaEstudiantesAsync();

            return listaEstudiantes;
        }
        internal async Task InsertEstudianteAsync(Estudiante objEstudiante)
        {
            ConnectDBMysql objConnect = new ConnectDBMysql();
            await objConnect.InsertEstudianteAsync(objEstudiante);
        }
        internal async Task UpdateEstudianteAsync(string id, Estudiante estudianteUpdate)
        {
            ConnectDBMysql objController = new ConnectDBMysql();
            await objController.UpdateEstudianteAsync(id, estudianteUpdate);
        }
        #region MySql
        /* internal List<Estudiante> SelectEstudiantes()
         {
             List<Estudiante> listaEstudiantes = null;
             ConnectDBMysql objConnect = new ConnectDBMysql();
             string sql = "select * from estudiante;";
             listaEstudiantes = objConnect.SelectEstudiante(sql);
             return listaEstudiantes;
         }*/
        #endregion
    }
}
