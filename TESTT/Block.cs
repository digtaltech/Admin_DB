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
    public partial class Block : Form
    {


        int BlockTime;
        int Time;
        int TimeST = 1;
        MySqlConnection con = new MySqlConnection(@"Database=mydb;Data Source=127.0.0.1;User Id=root;Password=root");
        


        public Block()
        {
            
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            con.Open();
            try
            {
                //получение время блокировки если оно есть
                string Query = "SELECT block_time FROM user WHERE id='"+Login_Form.ID+ "'";
                MySqlCommand BlockCmd = new MySqlCommand(Query, con);

                BlockTime = (int)BlockCmd.ExecuteScalar();

                
                if (BlockTime != 0)
                {
                    //запись текущего времени
                    string QueryTime = "UPDATE user SET time=CURTIME() WHERE id='" + Login_Form.ID + "'";
                    MySqlCommand CmdTime = new MySqlCommand(QueryTime, con);
                    CmdTime.ExecuteNonQuery();
                    //получение текущего времени
                    string TimeQuery = "SELECT time FROM user WHERE id='" + Login_Form.ID + "'";
                    MySqlCommand TimeCmd = new MySqlCommand(TimeQuery, con);

                    Time = (int)TimeCmd.ExecuteScalar();
                    
                    TimeST = BlockTime - Time;

                    UnblockTime.Text = TimeST.ToString();
                    con.Close();

                    if (TimeST == 0)
                    {
                        
                        Hide();
                        Login_Form ssN =  new  Login_Form();
                        ssN.ShowDialog();
                    }
                }
                
            }
            
            catch (NullReferenceException)
            {
                con.Close();
            }

            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            

        }

        private void UnblockTime_Click(object sender, EventArgs e)
        {

        }

        private void Block_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1_Paint(null, null);
        }
    }
}
