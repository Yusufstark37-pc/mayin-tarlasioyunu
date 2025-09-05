using System.Windows.Forms;
using System;
using System.Windows.Forms;


namespace mayintarlasioyunu
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        List<int> mayýn = new List<int>();
        int puan, dtiklanan = 0, mayinsayisi = 0, kutu = 0;



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Oyna(string mod)
        {
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.Controls.Clear();
            mayýn.Clear();
            dtiklanan = 0;
            mayinsayisi = 0;
            kutu = 0;
            puan = 0;
            label3.Text = "PUAN: 0";

            tableLayoutPanel1.ColumnCount = 10;
            tableLayoutPanel1.RowCount = 10;

            if (mod == "kolay") mayinsayisi = 10;
            else if (mod == "orta") mayinsayisi = 25;
            else if (mod == "zor") mayinsayisi = 40;

            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                for (int x = 0; x < tableLayoutPanel1.RowCount; x++)
                {
                    if (i == 0)
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    }
                    Button cmd = new Button();
                    cmd.BackColor = Color.Gray;
                    cmd.Dock = DockStyle.Fill;
                    cmd.Name = kutu.ToString();
                    tableLayoutPanel1.Controls.Add(cmd, i, x);
                    kutu++;
                }
            }
            int randomsayi;
            for (int i = 0; i < mayinsayisi; i++)
            {
                do
                {
                    randomsayi = rnd.Next(1, (tableLayoutPanel1.ColumnCount * tableLayoutPanel1.RowCount) - 1);
                } while (mayýn.Contains(randomsayi));

                mayýn.Add(randomsayi);
            }

            ButtonClickAyarla();
        }
        private void ButtonClickAyarla()
        {
            foreach (Control ctl in this.tableLayoutPanel1.Controls)
            {
                ctl.MouseClick += new MouseEventHandler(Form1_MouseClick);
            }
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                label1.Text = "Mayýn Sayýsý 10";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
                label1.Text = "Mayýn Sayýsý 25";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                label1.Text = "Mayýn Sayýsý 40";
        }


       void Form1_MouseClick(object sender, MouseEventArgs e)
{
    Button clickedButton = sender as Button;

    if (clickedButton != null)
    {
        int buttonIndex = int.Parse(clickedButton.Name); // Butonun ismini (numarasýný) al
        if (mayýn.Contains(buttonIndex)) // Eðer buton mayýn listesinde varsa
        {
            clickedButton.BackColor = Color.Red; // Mayýna bastýysa kýrmýzý yap
            MessageBox.Show("Kaybettiniz! Mayýna bastýnýz.");
        }
        else
        {
            clickedButton.BackColor = Color.Green; // Mayýn yoksa yeþil yap
            puan += 10; // Puan artýr
            label3.Text = "PUAN: " + puan;
        }
    }
}







        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Oyna("kolay");
            }
            else if (radioButton2.Checked == true)
            {
                Oyna("orta");
            }
            else if (radioButton3.Checked == true)
            {
                Oyna("zor");
            }
            else
            {
                MessageBox.Show("Zorluk Seçin");
            }
        }

    }
}
