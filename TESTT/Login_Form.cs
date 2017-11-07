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


    public partial class Login_Form : Form
    {
        MySqlConnection con = new MySqlConnection(@"Database=mydb;Data Source=127.0.0.1;User Id=root;Password=root");
        int Try;
        int i;
        public static int ID;



        public Login_Form()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public string Test(string login, string pass, object sender, EventArgs e)
        {
            

            


            if (login == "")
            {
                MessageBox.Show("Вы ввели неверный логин или пароль");
            }
            else
            {
                con.Open();
                i = 0;
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM user WHERE login = '" + login + "' and password = '" + pass + "'  ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    try
                    {
                        string Query1 = "SELECT try FROM user WHERE login = '" + login + "'  ";
                        MySqlCommand cmd1 = new MySqlCommand(Query1, con);

                        Try = (int)cmd1.ExecuteScalar();

                        string SelectID = "SELECT id FROM user WHERE login = '" + login + "'  ";
                        MySqlCommand cmdID = new MySqlCommand(SelectID, con);

                        ID = (int)cmdID.ExecuteScalar();

                        //начало кода с блокировкой
                        if (Try < 3)
                        {
                            string QueryTry = "UPDATE user SET try=try+1 WHERE login = '" + login + "'  ";
                            MySqlCommand CmdTry = new MySqlCommand(QueryTry, con);
                            CmdTry.ExecuteNonQuery();
                            MessageBox.Show("Вы ввели неверный логин или пароль!");
                            con.Close();
                        }
                        else
                        {
                            //block_try
                            string QueryBlockTry = "UPDATE user SET block_try=block_try+1 WHERE login = '" + login + "'  ";
                            MySqlCommand CmdTry = new MySqlCommand(QueryBlockTry, con);
                            CmdTry.ExecuteNonQuery();
                            //время блокировки
                            string QueryBlockTime = "UPDATE user SET block_time=CURTIME()+(15*block_try) WHERE login='" + login + "' ";
                            MySqlCommand cmd2 = new MySqlCommand(QueryBlockTime, con);
                            cmd2.ExecuteNonQuery();
                            //конец кода с блокировкой
                            MessageBox.Show("Вы ввели неверный логин или пароль");
                            con.Close();

                            Hide();
                            Block SsBlock = new Block();
                            SsBlock.ShowDialog();


                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Вы ввели неверный логин или пароль!!!!");
                        con.Close();
                    }
                }
                else
                {
                    string Clear = "UPDATE user SET block_try=0, try=0, block_time=0 WHERE login = '" + login + "'  ";
                    MySqlCommand CmdClear = new MySqlCommand(Clear, con);
                    CmdClear.ExecuteNonQuery();

                    if (login == "admin")
                    {
                        
                    }
                }
            }
            return ID.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
      



        public void button1_Click(object sender, EventArgs e)
        {

            


            if (textLogin.Text == "")
            {
                MessageBox.Show("Вы ввели неверный логин или пароль");
            }
            else
            {
                con.Open();
                i = 0;
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM user WHERE login = '" + textLogin.Text + "' and password = '" + textPassword.Text + "'  ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    try
                    {
                        string Query1 = "SELECT try FROM user WHERE login = '" + textLogin.Text + "'  ";
                        MySqlCommand cmd1 = new MySqlCommand(Query1, con);

                        Try = (int)cmd1.ExecuteScalar();

                        string SelectID = "SELECT id FROM user WHERE login = '" + textLogin.Text + "'  ";
                        MySqlCommand cmdID = new MySqlCommand(SelectID, con);

                        ID = (int)cmdID.ExecuteScalar();

                        //начало кода с блокировкой
                        if (Try < 3)
                        {
                            string QueryTry = "UPDATE user SET try=try+1 WHERE login = '" + textLogin.Text + "'  ";
                            MySqlCommand CmdTry = new MySqlCommand(QueryTry, con);
                            CmdTry.ExecuteNonQuery();
                            MessageBox.Show("Вы ввели неверный логин или пароль!");
                            con.Close();
                        }
                        else
                        {
                            //block_try
                            string QueryBlockTry = "UPDATE user SET block_try=block_try+1 WHERE login = '" + textLogin.Text + "'  ";
                            MySqlCommand CmdTry = new MySqlCommand(QueryBlockTry, con);
                            CmdTry.ExecuteNonQuery();
                            //время блокировки
                            string QueryBlockTime = "UPDATE user SET block_time=CURTIME()+(15*block_try) WHERE login='" + textLogin.Text + "' ";
                            MySqlCommand cmd2 = new MySqlCommand(QueryBlockTime, con);
                            cmd2.ExecuteNonQuery();
                            //конец кода с блокировкой
                            MessageBox.Show("Вы ввели неверный логин или пароль");
                            con.Close();

                            Hide();
                            Block SsBlock = new Block();
                            SsBlock.ShowDialog();


                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Вы ввели неверный логин или пароль!!!!");
                        con.Close();
                    }
                }
                else
                {
                    string Clear = "UPDATE user SET block_try=0, try=0, block_time=0 WHERE login = '" + textLogin.Text + "'  ";
                    MySqlCommand CmdClear = new MySqlCommand(Clear, con);
                    CmdClear.ExecuteNonQuery();

                    if (textLogin.Text == "admin")
                    {
                        Hide();
                        Main ssQ = new Main();
                        ssQ.Show();
                    }
                }
            }        
            
        }




        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration ssR = new Registration();
            ssR.Show();
        }
    }
}
