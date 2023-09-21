using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAD_Project
{
    public partial class UserControl1_Doctor : UserControl
    {
        public UserControl1_Doctor()
        {
            InitializeComponent();
        }

        //sql connection
        private SqlConnection connectDB()
        {

            SqlConnection cnn = DatabaseConnection.Instance.GetConnection();
            return cnn;

        }
        private void ADD_Click(object sender, EventArgs e)
        {
            string doctorid = txtdoctorid.Text;
            string name = txtname.Text;
            string gender = txtgender.Text;
            string contactno = txtcontactno.Text;
            string specialization = txtspecialization.Text;
            string time = txttime.Text;
            string doctormln = txtdoctormln.Text;

            string qualification = txtqualification.Text;
            string hospital = txthospital.Text;
            string yearsofexp = txtyearsofexp.Text;
            string date = txtdate.Text;
            SqlConnection cnn;
            cnn = connectDB();
            SqlCommand command;
            cnn.Open();
            String sql = "Insert into Doctor values('" + doctorid + "','" + name + "','" + gender + "','" + doctormln + "','"+qualification+"','"+hospital+"','" +yearsofexp + "','" +contactno+ "','" +specialization+ "','" +time+ "',,'" +date + "')";

            command = new SqlCommand(sql, cnn);
            command.ExecuteNonQuery();
            MessageBox.Show("Data inserted");

            dataGridView1.Rows.Add(txtdoctorid.Text, txtname.Text, txtgender.Text, txtdoctormln.Text, txtcontactno.Text, txtqualification.Text, txthospital.Text, txtyearsofexp.Text, txtspecialization.Text,txttime.Text);
            cnn.Close();
            populate();

            ClearTextBoxes(this);

        }
        private void populate()
        {
            SqlConnection cnn;
            cnn = connectDB();
            cnn.Open();
            string query = "select * from Doctor";
            SqlDataAdapter sda = new SqlDataAdapter(query, cnn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);   
            dataGridView1.DataSource = ds.Tables[0];
            cnn.Close();
        }
        private void ClearTextBoxes(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }

            }
        }

       
    private void Remove_Click(object sender, EventArgs e)
        {
            if (txtdoctorid.Text != "")
            {
                string Doctor_id = txtdoctorid.Text;
                SqlConnection cnn = connectDB();
                cnn.Open();
                string query = "delete from Doctor where Doctor_ID = '" + Doctor_id + "' ";
                SqlCommand command;
                command = new SqlCommand(query, cnn);
                command.ExecuteNonQuery();
                cnn.Close();
                populate();

                MessageBox.Show("Doctor Record Deleted !!");
            }

            else
            {
                MessageBox.Show("Please select record to Delete");
            }
           //idelete();   
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
