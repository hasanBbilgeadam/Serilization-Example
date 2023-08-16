using System.Numerics;
using System.Text;
using System.Text.Json;

namespace SporUygulaması
{
    public partial class Form1 : Form
    {
        List<Egzersiz> Egzersizler;
        const string path = "data.json";
        public Form1()
        {
            InitializeComponent();

            Egzersizler = new();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Egzersizler.Add(new()
            {
                Adı = textBox1.Text,
                Süresi = int.Parse(textBox2.Text),
                MakineAdı = textBox3.Text
            });


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();


            /*
             
             [
              ....
              ....
            ..... 
            .....
            .....
             ]
             .....
             
             
             */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Egzersiz> data = null;
            if (File.Exists(path))
            {

                data = JsonSerializer.Deserialize<List<Egzersiz>>(File.ReadAllText(path));

            }
            if (data != null)
            {
                Egzersizler.AddRange(data);


            }

            string jsonData = JsonSerializer.Serialize(Egzersizler);

            File.WriteAllText(path, jsonData);

            Egzersizler.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            string data = File.ReadAllText(path);

            List<Egzersiz> egzersizler2 = JsonSerializer.Deserialize<List<Egzersiz>>(data);


            foreach (var item in egzersizler2)
            {

                listBox1.Items.Add($"adı : {item.Adı} süresi: {item.Süresi} makine {item.MakineAdı}");

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                MessageBox.Show(checkBox1.Text + " seçildi");
            }
            if (checkBox2.Checked)
            {
                MessageBox.Show(checkBox2.Text + " seçildi");
            }
        }
    }

    public class Egzersiz
    {
        public string Adı { get; set; }
        public int Süresi { get; set; }
        public string MakineAdı { get; set; }
    }
}