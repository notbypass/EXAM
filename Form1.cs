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

namespace Makarrrrrrrrrrrrrr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            get_Info(listView1); //вызов при включении 
        }

        void get_Info(ListView List)
        {
            string query = "select*from supplier"; //вывод данных
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string[] row = { rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4), rd.GetString(5) }; //Столбцы из ListView
                        var listItem = new ListViewItem(row);
                        listView1.Items.Add(listItem);
                    }
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            get_Info(listView1); //очищение и вызов на кнопку обновить 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string query = "select * from user6_db.supplier where concat(Title, INN, StartDate, QualityRating, SupplierType) like '%" + textBox1.Text + "%'"; //условие like позволяет искать по всем столбцам.
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string[] row = { rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4), rd.GetString(5) };
                        var listItem = new ListViewItem(row);
                        listView1.Items.Add(listItem);
                    }
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string query = "delete from supplier where id = " + listView1.Items[listView1.SelectedIndices[0]].Text + ";"; //Удаление данных в ListView по id
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            listView1.Items.Clear();
            get_Info(listView1);
        }
    
        private void button3_Click(object sender, EventArgs e)
        {

            add_change Win = new add_change("add", 0); //Переход на форму добавления 
            Win.Show();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            add_change Win = new add_change("change", Convert.ToInt32(Convert.ToString(listView1.Items[listView1.SelectedIndices[0]].Text))); //Переход на форму редактирования по id
            Win.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            columnHeader1.Text = "Материалы";
            columnHeader2.Text = "Поставщик";
            columnHeader3.Text = "";
            columnHeader4.Text = "";
            columnHeader5.Text = "";
            columnHeader6.Text = "";
            listView1.Items.Clear();
            string query = "SELECT namess,postt FROM test;"; // Вывод информации о материалах 
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string[] row = { rd.GetString(0), rd.GetString(1)}; //Столбцы из ListView
                        var listItem = new ListViewItem(row);
                        listView1.Items.Add(listItem);
                    }
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            columnHeader1.Text = "Материалы";
            columnHeader2.Text = "Поставщик";
            columnHeader3.Text = "";
            columnHeader4.Text = "";
            columnHeader5.Text = "";
            columnHeader6.Text = "";
            string query = "select * from user6_db.test where concat(namess, postt) like '%" + textBox2.Text + "%'"; //условие like позволяет искать по всем столбцам.
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string[] row = { rd.GetString(0), rd.GetString(1)};
                        var listItem = new ListViewItem(row);
                        listView1.Items.Add(listItem);
                    }
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }

    

