using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio8
{
    public partial class Form1 : Form
    {
        // solo guarda la nota
        List<int> notasTemporales = new List<int>();
        // va guardado la nota y el nombre 
        List<NotasAlumnos> listanotas = new List<NotasAlumnos>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // obtengo la nota del textbox y convierto en entero
            int nota = Convert.ToInt32(textBox2.Text);
            // lo mando a guardar la nota
            MessageBox.Show("Nota guardada");
            notasTemporales.Add(nota);
            textBox2.Text = "";

        }

        private void Grabar()
        {
            //Suponiendo que la List llamada lista ya contiene datos

            //Se serializa (convierte) la lista en formato Json y se guarda en una variable de tipo string
            string json = JsonConvert.SerializeObject(listanotas);

            //El nombre del archivo
            string archivo = "Datos.json";

            //Se escribe la variable que contiene el json al archivo en un solo paso
            //con WriteAllText se escribe todo de un solo
            System.IO.File.WriteAllText(archivo, json);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // guarda a un alumno con sus notas
            NotasAlumnos notasAlumnos = new NotasAlumnos();
            notasAlumnos.Nombres = textBox1.Text;
            notasAlumnos.Notas = notasTemporales.GetRange(0,notasTemporales.Count);
            //.GetRange(0,notasTemporales.Count); no vincula las dos listas y le sacamos una copia a los valores
            // Guarda a ese alumno en el listado de notas de alumnos 
            listanotas.Add(notasAlumnos);
            Grabar();
            MessageBox.Show("Datos Guardados");
            // Borrar las notas temporales para el proximo alumno 
            notasTemporales.Clear();
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
