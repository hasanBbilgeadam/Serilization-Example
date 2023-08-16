using System.ComponentModel;
using System.Text.Encodings.Web;
using System.Text.Json;
using static System.Windows.Forms.Design.AxImporter;

namespace SiparişUygulama
{
    public partial class Form1 : Form
    {
        public const string path = "data.json";
        //private List<Müşteri> Müşterler;
        public Form1()
        {
            //Müşterler = new();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<Yemek> seçilenyemeker = new List<Yemek>();


            if (checkBox1.Checked)
            {
                seçilenyemeker.Add(new Döner() { YemekAdı="döner"});
            }
            if (checkBox2.Checked)
            {
                seçilenyemeker.Add(new AdanaKebap() { YemekAdı = "adana kebap"});
            }
            if (checkBox3.Checked)
            {
                seçilenyemeker.Add(new Künefe("künefe") { /*YemekAdı="müşteri"*/});
            }
            if (checkBox4.Checked)
            {
                seçilenyemeker.Add(new Kavurma() { YemekAdı = "kavurma"});
            }


            Müşteri müşteri = new Müşteri();
            müşteri.MasaNumarası = int.Parse(textBox1.Text);
            müşteri.Yemekler = seçilenyemeker;

            WriteToJsonFile(müşteri, path);


        }


        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in ReadToJsonFile(path))
            {
                string temp = "";
                temp = $"masa : {item.MasaNumarası}";
                foreach (var yemek in item.Yemekler)
                {
                    temp += $" {yemek.YemekAdı}";
                }
                listBox1.Items.Add(temp);
             }
        }
        public void WriteToJsonFile(Müşteri müşteri, string path)
        {
            var options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            List<Müşteri> mevcutMüşteriler = null;
            if (File.Exists(path))
            {
                string jsonDataFromFile = File.ReadAllText(path);
                mevcutMüşteriler = JsonSerializer.Deserialize<List<Müşteri>>(jsonDataFromFile, options);
            }
            if (mevcutMüşteriler != null)
            {
                mevcutMüşteriler.Add(müşteri);

                string jsonData = JsonSerializer.Serialize(mevcutMüşteriler, options);

                File.WriteAllText(path, jsonData);

                return;
            }

            mevcutMüşteriler = new();
            mevcutMüşteriler.Add(müşteri);
            File.WriteAllText(path, JsonSerializer.Serialize(mevcutMüşteriler, options));

        }

        public List<Müşteri> ReadToJsonFile(string path)
        {

            var options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            return JsonSerializer.Deserialize<List<Müşteri>>(File.ReadAllText(path), options);
        }

    }


}