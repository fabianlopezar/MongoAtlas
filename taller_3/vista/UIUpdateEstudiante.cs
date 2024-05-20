using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using taller_3.modelo;
using taller_3.controller;

namespace taller_3.vista
{

    public partial class UIUpdateEstudiante : Form
    {
        List<Estudiante> listaEStudiantes;
        string idestudianteOriginal;
        string selectedDateString;

        public UIUpdateEstudiante()
        {
            InitializeComponent();
        }

        private async void SelectEstudiantes(object sender, EventArgs e)
        {
            await TraerListaEstudiantesAsync();
        }
        public async Task TraerListaEstudiantesAsync()
        {
            ControllerEstudiante objController = new ControllerEstudiante();
            listaEStudiantes = await objController.SelectEstudiantesMongoAsync();

            for (int i = 0; i < listaEStudiantes.Count; i++)
            {
                string idEstudiante = listaEStudiantes[i].idEstudiante;
                comboBox1.Items.Add(idEstudiante);
            }

        }

        private void SelectItem(object sender, EventArgs e)
        {
            idestudianteOriginal = comboBox1.GetItemText(comboBox1.SelectedItem);
            MostrarAtributos();
        }
        public void MostrarAtributos()
        {
            string nombre1 = "";
            string nombre2 = "";
            string apellido1 = "";
            string apellido2 = "";
            string codigo = "";
            string fechaIngreso = "";
            string carrera = "";

            DateTime selectedDate = monthCalendar1.SelectionStart;
            //selectedDateString = selectedDate.ToString("yy-MM-dd");
            Console.WriteLine("Fecha seleccionada: " + selectedDateString);

            for (int i = 0; i < listaEStudiantes.Count; i++)
            {
                if (idestudianteOriginal.Equals(listaEStudiantes[i].idEstudiante))
                {
                    nombre1 = listaEStudiantes[i].nombre1;
                    nombre2 = listaEStudiantes[i].nombre2;
                    apellido1 = listaEStudiantes[i].apellido1;
                    apellido2 = listaEStudiantes[i].apellido2;
                    codigo = listaEStudiantes[i].codigo;
                    DateTime.TryParse(listaEStudiantes[i].fechaIngreso, out  selectedDate);
                    carrera = listaEStudiantes[i].carrera;
                }
            }
            textBox1.Text = nombre1;
            textBox2.Text = nombre2;
            textBox3.Text = apellido1;
            textBox4.Text = apellido2;
            textBox5.Text = codigo;
            monthCalendar1.SelectionStart = selectedDate;
            //textBox6.Text = fechaIngreso;
            textBox7.Text = carrera;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await UpdateEstudianteAsync();
        }
        public async Task UpdateEstudianteAsync()
        {
            string nombre1 = textBox1.Text;
            string nombre2 = textBox2.Text;
            string apellido1 = textBox3.Text;
            string apellido2 = textBox4.Text;
            string codigo = textBox5.Text;
            string fechaIngreso = selectedDateString;
            string carrera = textBox7.Text;

            ControllerEstudiante objController = new ControllerEstudiante();
            string idEstudiante = "0";
            for (int i = 0; i < listaEStudiantes.Count; i++)
            {
                if (listaEStudiantes[i].idEstudiante.Equals(idestudianteOriginal))
                {
                    idEstudiante = listaEStudiantes[i].idEstudiante;
                }
            }
            Estudiante objEstudiante = new Estudiante(nombre1, nombre2, apellido1, apellido2, codigo, fechaIngreso, carrera);
            try
            {
                await objController.UpdateEstudianteAsync(idEstudiante, objEstudiante);
                MessageBox.Show("Estudiante actualizado con éxito");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error al actualizar el estudiante: {ex.Message}");
            }
        }

        private void SelectDate(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
            selectedDateString = selectedDate.ToString("yy-MM-dd");
            Console.WriteLine("Fecha seleccionada: " + selectedDateString);
        }
    }
}
