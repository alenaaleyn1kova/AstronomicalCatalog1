using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Serialization;

namespace AstronomicalCatalog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Фотография|*.jpg" };
            var dr = ofd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Фотография|*.jpg" };
            var dr = ofd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Star)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var add = new Data() { Data_Planets = new Star() };
            if (add.ShowDialog(this) == DialogResult.OK)
            {
                listBox1.Items.Add(add.Data_Planets);
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Astronom|*.astronom" };

            if (ofd.ShowDialog(this) != DialogResult.OK)
                return;
            var xs = new XmlSerializer(typeof(Planet));
            var file = File.OpenRead(ofd.FileName);
            var application = (Planet)xs.Deserialize(file);
            file.Close();

            textBox1.Text = application.Name;
            textBox2.Text = application.Radius;

            var ms = new MemoryStream(application.Photo);
            pictureBox1.Image = Image.FromStream(ms);

            listBox1.Items.Clear();
            foreach (var offers in application.List)
            {
                listBox1.Items.Add(offers);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Astronom|*.astronom" };

            if (sfd.ShowDialog(this) != DialogResult.OK)
                return;

            var application = new Planet()
            {
                Name = textBox1.Text,
                Radius = textBox2.Text,
                List = listBox1.Items.OfType<Star>().ToList()
            };

            var stream = new MemoryStream();
            pictureBox1.Image.Save(stream, ImageFormat.Jpeg);
            application.Photo = stream.ToArray();

            var xs = new XmlSerializer(typeof(Planet));


            var file = File.Create(sfd.FileName);

            xs.Serialize(file, application);
            file.Close();
        
        }
    }
}
