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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace text 
{
    public partial class TaiKhoan : Form
    {

        SqlConnection conn1;
        SqlCommand com1;
        string Quyen          = "";
        //string str            = @"Data Source=.\\sqlexpress;Initial Catalog = Data; Integrated Security = True";
        string str = Program.finalConnectionString;
        SqlDataAdapter adater = new SqlDataAdapter();
        DataTable datatb      = new DataTable();
        public TaiKhoan(string quyen)
        {
            InitializeComponent();
            this.Quyen = quyen;
        }
        public void lamtrong()
        {
            cbb_UserType.Enabled = true;

            btn_xoa.Enabled      = false;
            btn_sua.Enabled      = false;
            btnResetPW.Enabled   = false;
            txt_UserName.Enabled = true;
            btn_them.Enabled     = true;
            txt_UserName.Text    = "";
            txt_Name.Text        = "";
            //cbb_UserType.Text  = "";
            txt_UserName.Focus();
        }

        public bool chestdata()
        {


            if (string.IsNullOrEmpty(txt_UserName.Text))

            {

                MessageBox.Show("Bạn  chưa nhập userName", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_UserName.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txt_Name.Text))
            {
                MessageBox.Show("Bạn  chưa nhập tên tài khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Name.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbb_UserType.Text))
            {
                MessageBox.Show("Bạn  chưa nhập ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbb_UserType.Focus();
                return false;
            }
            
            return true;
        }
        private void ketcsdl()
        {
            com1                     = conn1.CreateCommand();
            com1.CommandText         = "select  Tentk,Tenhienthi,Loai from Taikhoan";
            adater.SelectCommand     = com1;
            datatb.Clear();
            adater.Fill(datatb);
            dataGridView1.DataSource = datatb;
        }
        public TaiKhoan()
        {
            InitializeComponent();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                if (MessageBox.Show("Bạn có muốn xóa ?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                com1             = conn1.CreateCommand();
                com1.CommandText = "delete from Taikhoan where Tentk = '" + txt_UserName.Text + "'";
                com1.ExecuteNonQuery();

                lamtrong();

            }
        }
            else { MessageBox.Show("Xin lỗi bạn phải là admin mới mới có quyền", "Cảnh báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    ketcsdl();
        }
        

        private void btnResetPW_Click(object sender, EventArgs e)
        {
            
            DatLaiMatKhau datlaimk   = new DatLaiMatKhau();
            DatLaiMatKhau.tendn      = txt_UserName.Text;
            DatLaiMatKhau.tenhienthi = txt_Name.Text;
            datlaimk.ShowDialog();

        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            lamtrong();
            conn1 = new SqlConnection(str);
            conn1.Open();       
            ketcsdl();    
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbb_UserType.Enabled = false;
            btn_them.Enabled     = false;
            btnResetPW.Enabled   = true;
            btn_xoa.Enabled      = true;
            btn_sua.Enabled      = true;

            int i;
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            i                   = dataGridView1.CurrentRow.Index;
            if (Quyen == "admin")
            {
                cbb_UserType.Enabled = true;

                txt_UserName.Text = row.Cells[0].Value.ToString();
                txt_Name.Text = row.Cells[1].Value.ToString();
                cbb_UserType.Text = row.Cells[2].Value.ToString();
            }
            else if (i == 0)
            {
                MessageBox.Show("Xin lỗi bạn không có quyền admin", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                txt_UserName.Text = row.Cells[0].Value.ToString();
                txt_Name.Text = row.Cells[1].Value.ToString();
                cbb_UserType.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                if (chestdata())
                {
                    com1 = conn1.CreateCommand();
                    com1.CommandText = "insert into Taikhoan values('" + txt_UserName.Text + "','123456','" + txt_Name.Text + "','" + cbb_UserType.Text + "')";
                    MessageBox.Show("Bạn thêm thành công với \nTài Khoản:'" + txt_UserName.Text + "' \nMật khâu được thiết lập mặt định : 123456", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    com1.ExecuteNonQuery();

                    lamtrong();
                }
            }
            else { MessageBox.Show("Xin lỗi bạn phải là admin mới mới có quyền", "Cảnh báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            ketcsdl();
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            lamtrong();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            com1             = conn1.CreateCommand();
            com1.CommandText = "update Taikhoan set  Mk='123456',Tenhienthi = N'" + txt_Name.Text + "', Loai = '" + cbb_UserType.Text + "' where Tentk ='" + txt_UserName.Text + "'";
            com1.ExecuteNonQuery();
            lamtrong();
            ketcsdl();
        }
    }
}
