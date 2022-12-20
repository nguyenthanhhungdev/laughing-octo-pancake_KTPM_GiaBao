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

namespace text
{
    public partial class Dangnhap : Form
    {
        
        public Dangnhap()
        {
            InitializeComponent();
        }
        

        private void btn_dn_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source =.\\sqlexpress; Initial Catalog = Data; Integrated Security = True");
            SqlConnection conn = new SqlConnection(Program.finalConnectionString);
            try
            {
                conn.Open();    
                string tk        = txt_tk.Text;
                string mk        = txt_mk.Text;
                string sql       = "select * from Taikhoan where Tentk= '" + tk + "' and  Mk='" + mk + "'";
                SqlCommand cmd   = new SqlCommand(sql, conn);
                SqlDataAdapter dr = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                dr.Fill(dt);
                if(dt.Rows.Count >0)
                {
                    MessageBox.Show("Đăng nhập thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Trangchu frm = new Trangchu(tk,dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][4].ToString());
                    
                    frm.Show();
                    this.Hide();

                    Program.currentlyLoggedInAs = (int)dt.Rows[0]["Id"];
                }
                else
                {
                    MessageBox.Show("Sai tài khoản, mật khẩu hoặc để trống.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi kết nói", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ClickThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn Thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void ClickThoat_MouseHover(object sender, EventArgs e)
        {
            ClickThoat.BackColor = Color.Red;
        }

        private void ClickThoat_MouseLeave(object sender, EventArgs e)
        {
            ClickThoat.BackColor= Color.Transparent;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_mk.UseSystemPasswordChar = false;
                
            }
            else
            {
                txt_mk.UseSystemPasswordChar = true;
                
            }
        }
    }
}

