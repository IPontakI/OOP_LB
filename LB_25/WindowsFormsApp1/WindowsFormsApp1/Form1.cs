using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{   
    public partial class Form1 : Form
    {       
        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=VehicleDB.mdb;";

        private OleDbConnection oleDbConnection = null;
        OleDbCommand command;

        public Form1()
        {
            InitializeComponent();
            oleDbConnection = new OleDbConnection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            oleDbConnection.Open();

            textBox1.MaxLength = 25;
            textBox2.MaxLength = 2;
            textBox3.MaxLength = 15;
            textBox4.MaxLength = 2;
            textBox5.MaxLength = 2;

            label8.Text = "";
            label9.Text = "";

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from vehicle_table where name = '" + textBox6.Text + "';";
            try
            {
                command = new OleDbCommand(query, oleDbConnection);
                OleDbDataReader reader = command.ExecuteReader();
                
                if(reader.HasRows) 
                {
                    while (reader.Read())
                    {
                        label8.Text = textBox6.Text + " has " + reader.GetInt32(4) + " years of\n experience";
                    }

                    MessageBox.Show("Successfully selected from DB!", "DB Execute", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox6.Text = "";
                }
                else
                {
                    MessageBox.Show("Such name not found", "DB Execute", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox6.Text = "";
                } 
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error in select!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string age = textBox2.Text;
            string car = textBox3.Text;
            int exp = Convert.ToInt32(textBox4.Text);
            string license = textBox5.Text;

            string query = "INSERT INTO vehicle_table (name, age, car, experience, license) VALUES ('" + name + "', '" + age + "', '" + car + "'," + exp + ", '" + license +"')";
            try
            {
                OleDbCommand command = new OleDbCommand(query, oleDbConnection);

                command.ExecuteNonQuery();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

                MessageBox.Show("Successfully added to DB!", "DB Execute", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error with DB Execute!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "select * from vehicle_table;";

            if (comboBox1.SelectedIndex == 0)
            {
                int iterator = 0;
                int avgExp = 0;

                OleDbCommand command = new OleDbCommand(query, oleDbConnection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    avgExp += reader.GetInt32(4);
                    iterator++;
                }
                label9.Text = "Average experience in\n company is " + Convert.ToString(avgExp / iterator) + " years!";
            }
            else
            {                
                int hAge = 0;
                string hAgeName = "";

                OleDbCommand command = new OleDbCommand(query, oleDbConnection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if(reader.GetInt32(2) > hAge)
                    {
                        hAge = reader.GetInt32(2);
                        hAgeName = reader.GetString(1);
                    }                                        
                }
                label9.Text = "The highest age in company\n has " + hAgeName + " with age " + hAge.ToString() + " years!";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            oleDbConnection.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }        
    }
}
