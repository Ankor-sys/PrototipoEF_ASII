using CapaControlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmPolizaContable : Form
    {
        ctlPolizasContables con = new ctlPolizasContables();

        string totalSaldoDebe;
        string totalSaldoHaber;
        string idTotal;
        string fechaHoy;
        public frmPolizaContable()
        {
            InitializeComponent();
            textBox1.Text = incrementarId();
            groupBox1.Enabled = true;
            textBox4.Text = "0";
        }

        public string incrementarId()
        {
            string id;
            id = con.incrementarId();

            int aux = int.Parse(id);
            aux++;

            id = aux.ToString();


            return id;
        }

        private void frmPolizaContable_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet3.polizadetalle' Puede moverla o quitarla según sea necesario.
            this.polizadetalleTableAdapter.Fill(this.dataSet3.polizadetalle);
            // TODO: esta línea de código carga datos en la tabla 'dataSet2.cuenta' Puede moverla o quitarla según sea necesario.
            this.cuentaTableAdapter.Fill(this.dataSet2.cuenta);
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.polizadetalle' Puede moverla o quitarla según sea necesario.
            // this.polizadetalleTableAdapter.Fill(this.dataSet1.polizadetalle);

        }

        public void actualizardatagriew(string tabla1, DataGridView dtg1, string idEncabezado)
        {
            DataTable dt = con.llenarDataGrid(tabla1, idEncabezado);
            dtg1.DataSource = dt;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                insertarEncabezado();
                groupBox1.Enabled = false;
                textBox1.Enabled = false;
                MessageBox.Show("Encabezado Guardado");
            }
            catch ( Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            
        }

        public string insertarEncabezado()
        {
            string id = "";
            //string idEncabezado = incrementarId();
            fechaHoy = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            con.insertarEncabezado(textBox1.Text, fechaHoy, "1");
            id = buscarId();

            return id;
        }

        public string buscarId()
        {
            string id = "";

            id = con.incrementarId();

            return id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    con.insertarDetalle(textBox1.Text, fechaHoy, textBox4.Text, textBox3.Text, "1", textBox2.Text);
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    con.insertarDetalle(textBox1.Text, fechaHoy, textBox4.Text, textBox3.Text, "2", textBox2.Text);
                }
                MessageBox.Show("Detalle Guardado");
                //actualizardatagriew("polizadetalle", dataGridView1, textBox1.Text);
                this.polizadetalleTableAdapter.Fill(this.dataSet3.polizadetalle);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            
        }

        public void insertarDetalleDebe(string id)
        {
            fechaHoy = dateTimePicker1.Value.ToString("yyyy-MM-dd");




            //MessageBox.Show(totalSaldoDebe);
            con.insertarDetalle(textBox1.Text, fechaHoy, "1", totalSaldoDebe, "1", textBox2.Text);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                textBox4.Text = comboBox1.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex+ "");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox4.Text = "0";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox5.Text = comboBox2.SelectedIndex.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmEnlaceContableReporte form1 = new frmEnlaceContableReporte();
            form1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Ayudas/AyudasPoliza.chm", "AYUDA-POLIZA-CONTABLE.html");
        }
    }
}
