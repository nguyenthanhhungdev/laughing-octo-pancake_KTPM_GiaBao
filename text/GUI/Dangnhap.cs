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
using text.DAO;
using text.DTO;
using text.GUI;

namespace text
{
    public partial class Dangnhap : Form
    {

        public Dangnhap(string defaultUsername, string defaultPassword)
        {
            InitializeComponent();
            txt_tk.Text = defaultUsername;
            txt_mk.Text = defaultPassword;
        }
        private void btn_dn_Click(object sender, EventArgs e)
        {
            string tk = txt_tk.Text;
            string mk = txt_mk.Text;
            string sql = "select * from Taikhoan where Tentk= '" + tk + "' and  Mk='" + mk + "'";
            DataTable rs = DataProvider.Instance.ExecuteQuery(sql);

            if (rs.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Trangchu frm = new Trangchu(tk, rs.Rows[0][1].ToString(), rs.Rows[0][2].ToString(), rs.Rows[0][4].ToString());

                frm.Show();
                this.Hide();

                Program.CurrentlyLoggedIn.id = (int)rs.Rows[0][0];
                Program.CurrentlyLoggedIn.username = tk;
                Program.CurrentlyLoggedIn.password = mk;
            }
            else
            {
                MessageBox.Show("Sai tài khoản, mật khẩu hoặc để trống.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void ClickThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn Thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.Exit();
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

