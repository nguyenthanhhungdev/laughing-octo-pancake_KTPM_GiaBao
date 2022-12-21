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
using text.DAO;

namespace text.GUI
{
    public partial class DnDoimk : Form
    {
        public static string tendn, tenhienthi;
        public DnDoimk()
        {
            InitializeComponent();
        }
        
        private void clickThoat_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void DnDoimk_Load(object sender, EventArgs e)
        {
            this.txt_tk.Text = tendn;
            this.txt_tht.Text = tenhienthi;
            txt_tk.Enabled = false;
            txt_tht.Enabled = false;
        }
        public bool chestdata()
        {
            if (string.IsNullOrEmpty(txt_mk.Text))
            {
                MessageBox.Show("Bạn  chưa nhập Mật Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_mk.Focus();
                return false;
            }
            return true;
        }

        private void clickThoat_MouseHover(object sender, EventArgs e)
        {
            clickThoat.BackColor = Color.Red;
        }

        private void clickThoat_MouseLeave(object sender, EventArgs e)
        {
            clickThoat.BackColor = Color.Transparent;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn Thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chestdata())
            {
                string tk = txt_tk.Text;
                string mk = txt_mk.Text;
                string sql = "select * from Taikhoan where Tentk= '" + tk + "' and  Mk='" + mk + "'";
                DataTable rs = DataProvider.Instance.ExecuteQuery(sql);

                if (rs.Rows.Count > 0)
                {
                    this.Hide();
                    MessageBox.Show("Đăng nhập thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DatLaiMatKhau frm = new DatLaiMatKhau();
                    
                    DatLaiMatKhau.tendn = txt_tk.Text;
                    DatLaiMatKhau.tenhienthi = txt_tht.Text;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản, mật khẩu hoặc để trống.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
