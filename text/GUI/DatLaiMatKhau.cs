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
using text.DTO;

namespace text
{

    public partial class DatLaiMatKhau : Form
    {
        string Quyen = "";

        public DatLaiMatKhau()
        {
            InitializeComponent();
        }

        public DatLaiMatKhau(string quyen)
        {
            InitializeComponent();
            this.Quyen = quyen;
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
            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (chestdata())
            {
                string tk = txt_tdn.Text;
                string matkhau = txt_mk.Text;
                string sql = "select * from Taikhoan where Tentk= '" + tk + "' and  Mk='" + matkhau + "'";
                DataTable rs = DataProvider.Instance.ExecuteQuery(sql);

                if (rs.Rows.Count > 0)
                {
                    if (txt_mkm.Text == txt_nlmkm.Text)
                    {
                        string tendn = txt_tdn.Text;
                        string mk = txt_mkm.Text;
                        if (TaikhoanDao.Instance.updateac(tendn, mk))
                        {
                            MessageBox.Show("Đổi mật khẩu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhập Lại Mật Khẩu Không Đúng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản, mật khẩu hoặc để trống.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public static string tendn, tenhienthi;

        private void cb_showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_showpass.Checked)
            {
                txt_mk.UseSystemPasswordChar = false;
                txt_mkm.UseSystemPasswordChar = false;
                txt_nlmkm.UseSystemPasswordChar = false;
            }
            else
            {
                txt_mk.UseSystemPasswordChar = true;
                txt_mkm.UseSystemPasswordChar = true;
                txt_nlmkm.UseSystemPasswordChar = true;
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

            txt_tdn.Enabled = false;
            txt_tht.Enabled = false;

            this.txt_tdn.Text = tendn;
            this.txt_tht.Text = tenhienthi;

        }

    }
}
