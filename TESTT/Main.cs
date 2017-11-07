using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TESTT
{
    public partial class Main : Form
    {

        MySqlConnection con = new MySqlConnection(@"Database=mydb;Data source=127.0.0.1;User Id=root;Password=root");
        



        public Main()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick);

            

        }

        private void Main_Load(object sender, EventArgs e)
        {

            IDBox.SelectedIndex = -1;
            IDBox.Items.Clear();

            IDBoxDel.SelectedIndex = -1;
            IDBoxDel.Items.Clear();

            IDBoxPR.SelectedIndex = -1;
            IDBoxPR.Items.Clear();

            PRBox.Clear();

            try
            {
                con.Open();
                MySqlCommand cmdC = new MySqlCommand("SELECT boat_ID FROM boat", con);
                MySqlDataReader readC = cmdC.ExecuteReader();

                while (readC.Read())
                {
                    IDBox.Items.Add(readC.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

            try
            {
                con.Open();
                MySqlCommand cmdCC = new MySqlCommand("SELECT boat_ID FROM boat", con);
                MySqlDataReader readCC = cmdCC.ExecuteReader();

                while(readCC.Read())
                {
                    IDBoxDel.Items.Add(readCC.GetValue(0).ToString());
                }
                con.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

            try
            {
                con.Open();
                MySqlCommand cmdPR = new MySqlCommand("SELECT boat_ID FROM boat", con);
                MySqlDataReader readPR = cmdPR.ExecuteReader();

                while (readPR.Read())
                {
                    IDBoxPR.Items.Add(readPR.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }


            // TODO: данная строка кода позволяет загрузить данные в таблицу "mydbDataSet.boat". При необходимости она может быть перемещена или удалена.
            this.boatTableAdapter.Fill(this.mydbDataSet.boat);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mydbDataSet.user". При необходимости она может быть перемещена или удалена.
            this.userTableAdapter.Fill(this.mydbDataSet.user);
            timer1.Stop();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string Query = "INSERT INTO user (login,password) VALUES ('" + textLogin.Text + "','" + textPassword.Text + "')";
                MySqlCommand cmd = new MySqlCommand(Query, con);
                MySqlDataReader read;
                read = cmd.ExecuteReader();
                MessageBox.Show("Пользователь успешно добавлен");
                timer1.Start();
                con.Close();
                
            }
            catch (MySqlException)
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                con.Close();
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string QueryDel = "DELETE FROM user WHERE id='" + textID.Text + "'";
                MySqlCommand cmdDel = new MySqlCommand(QueryDel, con);
                MySqlDataReader ReadDel;
                ReadDel = cmdDel.ExecuteReader();

                MessageBox.Show("Пользователь успешно удалён");
                timer1.Start();
                con.Close();
            }
            catch(MySqlException)
            {
                MessageBox.Show("Пользователя с таким ID не существует !");
                con.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Main_Load(null, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {



            con.Open();
            try
            {

                string QueryQ = "INSERT INTO boat (boat_ID, Model,BoatType,NumberOfRowers,Mast,Colour,Wood,BasePrice,VAT) VALUES ('"+textID1.Text + "', '" + textModel1.Text + "','" + textBoatType1.Text + "','" + textNOR1.Text + "','" + textMast1.Text + "','" + textColour1.Text + "','" + textWood1.Text + "','" + textBasePrice1.Text + "','" + textVAT1.Text + "')  ";
                MySqlCommand cmdQ = new MySqlCommand(QueryQ, con);
                MySqlDataReader readQ;

                readQ = cmdQ.ExecuteReader();
                MessageBox.Show("Данные о продукции успешно добавлены");
                timer1.Start();
                con.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Данные невалидны !");
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Object IDBoatDel = IDBoxDel.SelectedItem;
            
            IDBoxDel.Items.Clear();
            con.Open();
            try
            {
                string QueryDel1 = "DELETE FROM boat WHERE boat_ID='" + IDBoatDel + "'";
                MySqlCommand cmdDel1 = new MySqlCommand(QueryDel1, con);
                MySqlDataReader ReadDel1;
                ReadDel1 = cmdDel1.ExecuteReader();

                MessageBox.Show("Продукция успешно удалена");
                timer1.Start();
                con.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Продукции с таким ID не существует !");
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                Object IDBoat = IDBox.SelectedItem;
                string QueryQ = "UPDATE boat SET Model = '" + textModel.Text + "',BoatType = '" + textBoatType.Text + "',NumberOfRowers = '" + textNumberOfRowers.Text + "',Mast = '" + textMast.Text + "',Colour = '" + textColour.Text + "',Wood = '" + textWood.Text + "',BasePrice = '" + textBasePrice.Text + "',VAT = '" + textVAT.Text + "' WHERE boat_ID='" + IDBoat + "' ";
                MySqlCommand cmdQ = new MySqlCommand(QueryQ, con);
                MySqlDataReader readQ;

                readQ = cmdQ.ExecuteReader();
                MessageBox.Show("Данные о продукции успешно добавлены");
                timer1.Start();
                con.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Данные невалидны !");
                con.Close();
            }
        }

        private void IDBox_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void IDBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Object IDBoat = IDBox.SelectedItem;
            textModel.Clear();
            textBoatType.Clear();
            textNumberOfRowers.Clear();
            textMast.Clear();
            textColour.Clear();
            textWood.Clear();
            textBasePrice.Clear();
            textVAT.Clear();


            try
            {
                con.Open();
                MySqlCommand cmdPO = new MySqlCommand("SELECT Model, BoatType, NumberOfRowers, Mast, Colour, Wood, BasePrice, VAT FROM boat WHERE boat_ID = '" + IDBoat + "'  ", con);
                MySqlDataReader readPO = cmdPO.ExecuteReader();

                while (readPO.Read())
                {
                    textModel.Text += readPO["Model"];
                    textBoatType.Text += readPO["BoatType"];
                    textNumberOfRowers.Text += readPO["NumberOfRowers"];
                    textMast.Text += readPO["Mast"];
                    textColour.Text += readPO["Colour"];
                    textWood.Text += readPO["Wood"];
                    textBasePrice.Text += readPO["BasePrice"];
                    textVAT.Text += readPO["VAT"];
                }
                con.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                //MySqlCommand cmdPRICE = new MySqlCommand("SELECT Base", con);

                MySqlCommand cmdPRC = new MySqlCommand("UPDATE boat SET BasePrice = BasePrice + (BasePrice *'" + PRBox.Text + "')/100 WHERE boat_ID = '" + IDBoxPR.SelectedItem + "'  ", con);
                MySqlDataReader readPRC = cmdPRC.ExecuteReader();
                MessageBox.Show("OK");

                timer1.Start();
                con.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmdPRC2 = new MySqlCommand("UPDATE boat SET BasePrice = BasePrice + (BasePrice * '"+ PRBox2.Text +"')/100  ", con);
                MySqlDataReader readPRC2 = cmdPRC2.ExecuteReader();
                MessageBox.Show("OK");

                timer1.Start();
                con.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
    }
}
