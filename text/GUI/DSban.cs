using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using System.Data.OleDb;
using System.Data.Common;
using System.Collections;
using System.Runtime.Remoting.Contexts;

namespace text
{
    public partial class DSban : Form
    {
        string Quyen="";
        SqlConnection conn1;
        SqlCommand com1;
        //string str            = @"Data Source=.\SQLEXPRESS;Initial Catalog=DOAN;Integrated Security=True";
        string str = Program.finalConnectionString;
        SqlDataAdapter adater = new SqlDataAdapter();
        DataTable datatb      = new DataTable();
        public DSban()
        {
            InitializeComponent();
        }
        public DSban(string quyen)
        {
            InitializeComponent();
            this.Quyen = quyen;

            
        }
        private void ketnoicsdl()
        {
            com1                     = conn1.CreateCommand();
            com1.CommandText         = "select * from DSban";
            adater.SelectCommand     = com1;
            datatb.Clear();
            adater.Fill(datatb);
            dataGridView1.DataSource = datatb;

            //conn.Open();
            //string sql = "select * from DSban";  // lay het du lieu trong bang sinh vien
            //SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
            //com.CommandType = CommandType.Text;
            //SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            //DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            //da.Fill(dt);  // đổ dữ liệu vào kho
            //conn.Close();  // đóng kết nối
            //dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        public bool chestdata()
        {
            

            if (string.IsNullOrEmpty(txt_id.Text))
            
            {
                
                MessageBox.Show("Bạn  chưa nhập ID", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_id.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txt_tenban.Text))
            {
                MessageBox.Show("Bạn  chưa nhập tên bàn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_tenban.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txt_trangthai.Text))
            {
                MessageBox.Show("Bạn  chưa nhập trạng thái", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_trangthai.Focus();
                return false;
            }
            return true;
        }


        public void lamtrong()
        {
            btn_xoa.Enabled    = false;
            btn_sua.Enabled    = false;
            txt_id.Enabled     = true;
            btn_them.Enabled   = true;
            txt_id.Text        = "";
            txt_tenban.Text    = "";
            txt_trangthai.Text = "";
            txt_id.Focus();
        }
        private void DSban_Load(object sender, EventArgs e)
        {
            conn1 = new SqlConnection(str);
            conn1.Open();

            lamtrong();

            txt_id.Focus();

            
            ketnoicsdl();
        }
        
        private void btn_them_Click(object sender, EventArgs e)

        {
            if (Quyen == "admin")
            {
                if (chestdata())
                {
                    com1 = conn1.CreateCommand();
                    com1.CommandText = "insert into DSban values('" + txt_id.Text + "','" + txt_trangthai.Text + "','" + txt_tenban.Text + "')";
                    com1.ExecuteNonQuery();
                    txt_id.Focus();
                    lamtrong();
                }
            
            }
            else { MessageBox.Show("Xin lỗi bạn phải là admin mới mới có quyền", "Cảnh báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            ketnoicsdl();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                if (MessageBox.Show("Bạn có muốn xóa ?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    com1 = conn1.CreateCommand();
                    com1.CommandText = "delete from DSban where Id = '" + txt_id.Text + "'";
                    com1.ExecuteNonQuery();
                    txt_id.Focus();

                    lamtrong();
                }
            }
            else { MessageBox.Show("Xin lỗi bạn phải là admin mới mới có quyền", "Cảnh báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            ketnoicsdl();
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {         
            lamtrong();
            
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            com1             = conn1.CreateCommand();
            com1.CommandText = "update DSban set Tenban = N'" + txt_tenban.Text + "',Tinhtrangban = N'" + txt_trangthai.Text + "' where Id = '"+txt_id.Text+"'";
            com1.ExecuteNonQuery();
            ketnoicsdl();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txt_id.Enabled   = false;
            btn_them.Enabled = false;
            btn_xoa.Enabled  = true;
            btn_sua.Enabled  = true;

            int i;
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            i                   = dataGridView1.CurrentRow.Index;
            txt_id.Text         = row.Cells[0].Value.ToString();
            txt_trangthai.Text  = row.Cells[1].Value.ToString();
            txt_tenban.Text     = row.Cells[2].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
