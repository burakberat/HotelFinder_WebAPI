using System.Runtime.InteropServices;

namespace HotelWFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var responce = await RestHelper.GetAll();
            richTextBox1.Text = RestHelper.BeautifyJson(responce);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var responce = await RestHelper.GetById(textBox1.Text);
            richTextBox1.Text = RestHelper.BeautifyJson(responce);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var responce = await RestHelper.Post(textBox2.Text , textBox3.Text);
            richTextBox1.Text = RestHelper.BeautifyJson(responce);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var responce = await RestHelper.Update(textBox1.Text, textBox2.Text, textBox3.Text);
            richTextBox1.Text = RestHelper.BeautifyJson(responce);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var responce = await RestHelper.Delete(textBox1.Text);
            var deleted = await RestHelper.GetAll();
            richTextBox1.Text = RestHelper.BeautifyJson(deleted);
        }
    }
} 