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
using MongoDB.Driver;


namespace taller_3.vista
{
    public partial class UIInsertEstudiante : Form
    {
        string selectedDateString;
        public UIInsertEstudiante()
        {
            InitializeComponent();
        }

        private void UIInsertEstudiante_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await EnviarEstudiante();
        }
        private async Task EnviarEstudiante()
        {
            string nombre1 = textBox1.Text;
            string nombre2 = textBox2.Text;
            string apellido1 = textBox3.Text;
            string apellido2 = textBox4.Text;
            string codigo = textBox5.Text;
            string fechaIngreso = selectedDateString;
            string carrera = textBox7.Text;

            Estudiante objEstudiante = new Estudiante { nombre1 = nombre1, nombre2 = nombre2, apellido1 = apellido1, apellido2 = apellido2, codigo = codigo, fechaIngreso = fechaIngreso, carrera = carrera };
            ConnectDBMysql objConnect = new ConnectDBMysql();
            try
            {
                await objConnect.InsertEstudianteAsync(objEstudiante);
                MessageBox.Show("Estudiante ingresado con éxito");
            }
            catch (Exception ex)
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
