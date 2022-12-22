using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using text.DAO;

namespace text.GUI
{
    public partial class Quenmk : Form
    {
        public Quenmk()
        {
            InitializeComponent();
        }

        private void ClickThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_tl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_hmk_Click(object sender, EventArgs e)
        {
            string tht  = txt_tht.Text;
            
            string sql = "select Tenhienthi,Mk from Taikhoan where Tenhienthi= '" + tht + "'";
            DataTable rs = DataProvider.Instance.ExecuteQuery(sql);

            if (rs.Rows.Count >0)
            {
                label3.Text = "Mật khảu";
                label3.Visible = true;
                txt_hmk.Visible = true;
                txt_hmk.Text = rs.Rows[0]["Mk"].ToString();
            }
            else
            {
                MessageBox.Show("Sai tài khoản, hoặc để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tht.Focus();
            }
        }
    }
}
