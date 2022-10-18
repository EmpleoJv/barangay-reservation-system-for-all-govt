using MySql.Data.MySqlClient;

namespace barangayReservationSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginStart_Click(object sender, EventArgs e)
        {
            string conString = "datasource=localhost;username=root;password=;database=capsstone;";
            string query = "SELECT * FROM loginsystem";
            MySqlConnection conn = new MySqlConnection(conString);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader myReader;

            try
            {
                conn.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    string user = myReader.GetString("username");
                    string pass = myReader.GetString("password");
                    if (userTxb.Text == user)
                    {
                        if (passTxb.Text == pass)
                        {
                            this.Hide();
                            Form2 form2 = new Form2();
                            form2.Show();
                        }
                        else
                        {
                            userTxb.Text = "";
                            passTxb.Text = "";
                            MessageBox.Show("Password Error");
                        }
                    }
                    else
                    {
                        userTxb.Text = "";
                        passTxb.Text = "";
                        MessageBox.Show("Username Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }
        private void clearBtn_Click(object sender, EventArgs e)
        {
            userTxb.Text = "";
            passTxb.Text = "";
        }
    }
}