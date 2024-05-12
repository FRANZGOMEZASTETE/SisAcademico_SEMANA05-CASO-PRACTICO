using SisAcademico.Entities;
using SisAcademico.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisAcademico.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EstudianteNegocio objNegocio = new EstudianteNegocio();
        Estudiante objEstudiante = new Estudiante();

        void Limpiar()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
        }

        bool validar(string p1, string p2, string p3)
        { 
            if (p1.Length == 0 || p2.Length == 0 || p3.Length == 0)
                return false;
            else 
                return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == string.Empty) {
                dataGridView1.DataSource = objNegocio.ListarEstudiantes();
            }
            else
            {
                dataGridView1.DataSource = objNegocio.ListarEstudiantesxNombre(txtNombre.Text);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNumDoc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[4].Value is true)
            {
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (validar(txtNumDoc.Text, txtNombre.Text, txtEmail.Text) == true)
            {
                objEstudiante.Num_doc = txtNumDoc.Text;
                objEstudiante.Nombres = txtNombre.Text;
                objEstudiante.Email = txtEmail.Text;
               
                try
                {
                    objNegocio.Agregar(objEstudiante);
                    MessageBox.Show("Se ha registrado un Nuevo Estudiante");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los datos");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (validar(txtNumDoc.Text, txtNombre.Text, txtEmail.Text) == true)
            {

                objEstudiante = objNegocio.Buscar(Convert.ToInt32(txtCodigo.Text));
                objEstudiante.Num_doc = txtNumDoc.Text;
                objEstudiante.Nombres = txtNombre.Text;
                objEstudiante.Email = txtEmail.Text;
            
                try
                {
                    objNegocio.Actualizar(objEstudiante);
                    MessageBox.Show("Se ha actualizado la Categoria");
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else {
                MessageBox.Show("Primero seleccione el registro que quieres Actualizar");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
