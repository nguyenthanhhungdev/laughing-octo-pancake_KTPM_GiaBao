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


namespace text
{
    
    public partial class DatLaiMatKhau : Form
    {


        //SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DOAN;Integrated Security=True");
        //string connect = @"Data Source=.\SQLEXPRESS;Initial Catalog=DOAN;Integrated Security=True";
        string connect = Program.finalConnectionString;
        SqlCommand cmd;
        SqlConnection conn1;


        public DatLaiMatKhau()
        {
            InitializeComponent();
        }


        
        

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool chestdata()
        {
            if (string.IsNullOrEmpty(txt_mk.Text))
            {
                MessageBox.Show("Bạn  chưa nhập Mật Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_mk.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txt_mkm.Text))
            {
                MessageBox.Show("Bạn  chưa nhập Mật Khẩu Mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_mkm.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txt_nlmkm.Text))
            {
                MessageBox.Show("Bạn  chưa nhập Nhập Lại Mật Khẩu Mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_nlmkm.Focus();
                return false;
            }
            SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DOAN;Integrated Security=True");
            conn.Open();
            string tk = txt_tdn.Text;
            string mk = txt_mk.Text;
            string sql = "select * from Taikhoan where Tentk= '" + tk + "' and  Mk='" + mk + "'";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read() == false)
            {
                MessageBox.Show("Mật khẩu không đúng", "Thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            conn.Close();
            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            conn1 = new SqlConnection(connect);
            conn1.Open();
            if (chestdata())
            {
                if ( txt_mkm.Text == txt_nlmkm.Text)
                {
                   cmd = conn1.CreateCommand();
                   MessageBox.Show("Đổi mật khẩu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   cmd.CommandText = "update Taikhoan set Mk = N'" + txt_mkm.Text + "',Tenhienthi = N'" + txt_tht.Text + "',Loai='0' where Tentk = '" + txt_tdn.Text + "'";
                   cmd.ExecuteNonQuery();
                   this.Close();                   
                }
                else
                {
                    MessageBox.Show("Nhập Lại Mật Khẩu Không Đúng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                }              
            }
            conn1.Close();       
        }
        public static string tendn,tenhienthi;

        private void cb_showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_showpass.Checked)
            {
                txt_mk.UseSystemPasswordChar    = false;
                txt_mkm.UseSystemPasswordChar   = false;
                txt_nlmkm.UseSystemPasswordChar = false;            
            }
            else
            {
                txt_mk.UseSystemPasswordChar    = true;
                txt_mkm.UseSystemPasswordChar    = true;
                txt_nlmkm.UseSystemPasswordChar  = true;
            }
        }

        private void ClickThoat_MouseHover(object sender, EventArgs e)
        {
            ClickThoat.BackColor = Color.Red;
        }

        private void ClickThoat_MouseLeave(object sender, EventArgs e)
        {
            ClickThoat.BackColor = Color.Transparent;
        }

        private void DatLaiMatKhau_Load(object sender, EventArgs e)
        {
            txt_mk.Focus();
            

            txt_tdn.Enabled        = false;
            txt_tht.Enabled        = false;
            
            this.txt_tdn.Text      = tendn;
            this.txt_tht.Text      = tenhienthi;
            

        }
        
    }
}
