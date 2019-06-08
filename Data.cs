using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstronomicalCatalog
{
    public partial class Data : Form
    {
        public Data()
        {
            InitializeComponent();
        }
        
        public Star Data_Planets { get; set; }

        private void Form_Load(object sender, EventArgs e)
        {
            textBox1.Text = Data_Planets.Weight;
            textBox2.Text = Data_Planets.Colour;
            textBox3.Text = Data_Planets.Temperature;
            textBox4.Text = Data_Planets.Gravity;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Data_Planets.Weight = textBox1.Text;
            Data_Planets.Colour = textBox2.Text;
            Data_Planets.Temperature = textBox3.Text;
            Data_Planets.Gravity = textBox4.Text;
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
