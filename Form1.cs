using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BaiTapVeNha_14
{
    public partial class Form1 : Form
    {
        DataTable ban = new DataTable();
        DataTable Ds = new DataTable();
        List<DataTable> Order = new List<DataTable>();
        int index=0;
        int check = 0;
        String order;
        public Form1()
        {
            InitializeComponent();
            Load_Event_Button();
            
            Contruction_Data();
            Load_Data_ComonBox();
            Data();
        }
        public int Check_Order(String s)
        {
            DataTable dt = Order[index];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               
                String r = dt.Rows[i][0].ToString();
                if (String.Compare(r,s)==0)
                    return i;
            }
            return -1;
        }
        public void Contruction_Data()
        {
            ban.Columns.AddRange(new DataColumn[]
            {
                new DataColumn { DataType =typeof(int) , ColumnName = "Id"},
                new DataColumn { DataType =typeof(string) , ColumnName = "Ten Ban"}
            });
            ban.Rows.Add(1, "Ban 1");
            ban.Rows.Add(2, "Ban 2");
            ban.Rows.Add(3, "Ban 3");
            ban.Rows.Add(4, "Ban 4");
            
            
            for (int i = 0; i < 4; i++)
            {

                Order.Add(new DataTable());
                Order[i].Columns.AddRange(
            new DataColumn[]
        {
                new DataColumn { DataType =typeof(string) , ColumnName = "Mon An"},
                new DataColumn { DataType =typeof(int) , ColumnName = "So Luong"}
        });

            }
           


        }
        public void Load_Data_ComonBox()
        {

            for (int i = 0; i < 4; i++)
            {
                comboBox1.Items.Add(ban.Rows[i].ItemArray[0]);
            }
        }
        public void Data()
        {

        }
        public void Load_Event_Button()
        {
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    c.Click += new System.EventHandler(btn_click);
                }
            }
        } 
        private void btn_click(object o , EventArgs e)
        {
            if (comboBox1.SelectedItem == null)

            {
                return;
            }
               Button button = (Button)o;
            if (!button.Text.Equals("Xoa") && !button.Text.Equals("Order"))
            {
               if(Check_Order(button.Text)==-1)
                {
                    check = -1;
                    order = button.Text;
                }
               else
                {
                    check = Check_Order(button.Text);
                    order = button.Text;
                }
              

            }
            else
            {
                if(button.Text.Equals("Xoa"))
                {
                    Order[index].Clear();
               
                }
                else if(check==-1&&order!=null)
                {
                    Order[index].Rows.Add(order, 1);
                   
         
                }
                else if(check!=-1&&order!=null)
                {
                    Order[index].Rows[check][1] = (Convert.ToInt32(Order[index].Rows[check][1].ToString()) + 1);
                    order = null;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = Convert.ToInt32(comboBox1.SelectedItem.ToString())-1;
            dataGridView1.DataSource = Order[index];
            dataGridView1.Update();
            dataGridView1.Refresh();


        }
    }
}
