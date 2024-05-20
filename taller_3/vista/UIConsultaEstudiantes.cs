using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using taller_3.controller;
using taller_3.modelo;

namespace taller_3.vista
{
    public partial class UIConsultaEstudiantes : Form
    {
        List<Estudiante> listaEstudiantes;
        public UIConsultaEstudiantes()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void UIConsultaEstudiantes_Load(object sender, EventArgs e)
        {
            await LoadEstudiantesAsync();
        }

        private async Task LoadEstudiantesAsync()
        {
            ControllerEstudiante objController = new ControllerEstudiante();
            listaEstudiantes = await objController.SelectEstudiantesMongoAsync();

            DataTable tabla = new DataTable();
            tabla.Columns.Add("Id", typeof(string));
            tabla.Columns.Add("nombre1", typeof(string));
            tabla.Columns.Add("nombre2", typeof(string));
            tabla.Columns.Add("apellido1", typeof(string));
            tabla.Columns.Add("apellido2", typeof(string));
            tabla.Columns.Add("codigo", typeof(string));
            tabla.Columns.Add("fechaIngreso", typeof(string));
            tabla.Columns.Add("carrera", typeof(string));

            foreach (var elem in listaEstudiantes)
            {
                DataRow fila = tabla.NewRow();
                fila["Id"] = elem.idEstudiante;
                fila["nombre1"] = elem.nombre1;
                fila["nombre2"] = elem.nombre2;
                fila["apellido1"] = elem.apellido1;
                fila["apellido2"] = elem.apellido2;
                fila["codigo"] = elem.codigo;
                fila["fechaIngreso"] = elem.fechaIngreso;
                fila["carrera"] = elem.carrera;
                tabla.Rows.Add(fila);
            }

            dataGridView1.DataSource = tabla;
        }

    }
}
