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
    public partial class add_change : Form
        
           {
           public string modeS = "";
           int item;
           void setMode(string mode) //Создание мода для редактирования и добавления даннхы
            {
                if (mode == "add") //Если перейдем по кнопке Добавить, то AddButton.Text = "Добавить";
            {
                    AddButton.Text = "Добавить";
                }
                else if (mode == "change") //Если перейдем по Редактировать Добавить, то AddButton.Text = "Изменить";
            {
                    AddButton.Text = "Изменить";
                    string Info = "select id, Title, INN, StartDate, QualityRating, SupplierType from supplier where id =" + item.ToString() + ";";//Вывод данных для update по id
                MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmInfo = new MySqlCommand(Info, conn);
                    MySqlDataReader inRead;
                    cmInfo.CommandTimeout = 60;
                    try
                    {
                        conn.Open();
                        inRead = cmInfo.ExecuteReader();
                        if (inRead.HasRows)
                        {
                            while (inRead.Read())
                            {
                                
                                textBox1.Text = inRead.GetString(0);
                                textBox2.Text = inRead.GetString(1);
                                textBox3.Text = inRead.GetString(2);
                                textBox4.Text = inRead.GetString(3);
                                textBox5.Text = inRead.GetString(4);
                                textBox6.Text = inRead.GetString(5);


                            }
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            void getNames(ComboBox Box)
            {
                string query = "select FIO from supplier;"; //Вывод данных для update
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                MySqlDataReader rd;
                cmDB.CommandTimeout = 60;
                try
                {
                    conn.Open();
                    rd = cmDB.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            string row = rd.GetString(0);
                            Box.Items.Add(row);
                        }
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

          

        public add_change(string mode, int id)
            {
            InitializeComponent();
            modeS = mode;
            item = id;
            setMode(mode);
            }   

        private void AddButton_Click(object sender, EventArgs e)
            {

                if (modeS == "add")
                {

                    string query = "insert into supplier(id,Title, INN, StartDate, QualityRating, SupplierType) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "');"; //Добавление данных через insert
                MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    cmDB.CommandTimeout = 60;
                    try
                    {
                        conn.Open();
                        MySqlDataReader rd = cmDB.ExecuteReader();
                        conn.Close();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                if (modeS == "change")
                {

                    string query = "update supplier set Title ='" + textBox1.Text + "',INN ='" + textBox2.Text + "',StartDate = '" + textBox3.Text + "',QualityRating = '" + textBox4.Text + "', SupplierType ='" + textBox5.Text + "' where id =" + item.ToString() + ";"; // Редактирование данных с помощью update
                MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    cmDB.CommandTimeout = 60;
                    try
                    {
                        conn.Open();
                        MySqlDataReader rd = cmDB.ExecuteReader();
                        conn.Close();

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            private void nameBox_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

           

        private void add_change_Load(object sender, EventArgs e)
        {

        }

        
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close(); //Закртытие формы
        }
    }
    }