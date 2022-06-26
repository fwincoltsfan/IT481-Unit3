using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Mike_McNeal_Unit2_IT481
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=DADS_LAPTOP\SQLEXPRESS02;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            messageBox.Text = "Inserting Record...";
            command.Connection = connection;
            command.CommandText = "insert into Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) values('" + txtCustomerID.Text + "','" + txtCompanyName.Text + "','" + txtContactName.Text + "','" + txtContactTitle.Text + "','" + txtAddress.Text + "','" + txtCity.Text + "','" + txtRegion.Text + "','" + txtPostalCode.Text + "','" +txtCountry.Text + "','" + txtPhone.Text + "','" + txtFax.Text + "')";
            command.ExecuteNonQuery();
            messageBox.Text = "Record Inserted...";
            connection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form1_Load() called...");
            messageBox.Text = "Startup...";

            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=DADS_LAPTOP\SQLEXPRESS02;Initial Catalog=Northwind;Integrated Security=True");
                connection.Open();
                messageBox.Text = "Connection Successful";
                connection.Close();
            }
            catch (Exception ex)
            {
                messageBox.Text = "Error, " + ex;
            }

        }
        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=DADS_LAPTOP\SQLEXPRESS02;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            messageBox.Text = "Retrieving Records...";
            command.Connection = connection;
            command.CommandText = "select * from Customers";
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            messageBox.Text = "Retrieval Successful!";
            connection.Close();
        }

        private void btnCount_Click_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=DADS_LAPTOP\SQLEXPRESS02;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            messageBox.Text = "Counting Records...";
            command.Connection = connection;
            command.CommandText = "select count(*) from Customers";
            int count = (int)command.ExecuteScalar();
            messageBox.Text = "Number of records: " + count;
            connection.Close();
        }
    }
}