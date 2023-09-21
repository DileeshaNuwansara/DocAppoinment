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
    public partial class UserControl1_Appoinmentnew : UserControl
    {
        public UserControl1_Appoinmentnew()
        {
            InitializeComponent();
        }
        private SqlConnection connectDB()
        {
            
            SqlConnection cnn;
            cnn = DatabaseConnection.Instance.GetConnection();
            return cnn;


        }
       
        
           
        

        private void Viewbtn(object sender, EventArgs e)
        {

            SqlConnection cnn = connectDB();
            String query = "select * from Appoinment";
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }
        string toDeleteIndex;
        private void Removebtn(object sender, EventArgs e)
        {
            ;
            if (toDeleteIndex != "")
            {
                string appoinment_id = toDeleteIndex;
                SqlConnection cnn = connectDB();

                string query = "delete from Appoinment where Appoinment_ID = '" + appoinment_id + "'";
                SqlCommand command;
                command = new SqlCommand(query, cnn);
                command.ExecuteNonQuery();
                cnn.Close();
                

                MessageBox.Show("Appoinment Record Deleted !!");
            }

            else
            {
                MessageBox.Show("Please select record to Delete");
            }
        }

        private void getSelectedID(object sender, DataGridViewCellEventArgs e)
        {
            int index=e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            toDeleteIndex = row.Cells[0].Value.ToString();
        }
    }
}
       
