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

    public partial class Registration : Form
    {
        MySqlConnection con = new MySqlConnection(@"Database=mydb;Data Source=127.0.0.1;User Id=root;Password=root");
        public Registration()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            try
            {

                string Query = "INSERT INTO user (login, password) VALUES ('" + textLogin.Text + "','" + textPassword.Text + "')  ";
                MySqlCommand cmd = new MySqlCommand(Query, con);
                MySqlDataReader read;

                read = cmd.ExecuteReader();
                MessageBox.Show("Вы успешно зарегистрированы");

                Close();
                Login_Form ss = new Login_Form();
                ss.Show();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Данные невалидны !");
                con.Close();
            }

            
            
            


        }
    }
}
