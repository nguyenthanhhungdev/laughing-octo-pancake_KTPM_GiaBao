
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace text
{
    public partial class Trangchu : Form
    {
        string tendn = "", matkhau = "", Quyen = "";
        public Trangchu()
        {
            InitializeComponent();
            
        }
        public Trangchu(string txt_tk,string tendn,string matkhau, string Quyen)
        {
            InitializeComponent();
            menu.Text = txt_tk;    
            this.tendn = tendn;
            this.matkhau = matkhau;
            this.Quyen = Quyen;
        }
        private Form currentFormChild;

        
        private void OpenChidFrom(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild          = childForm;
            childForm.TopLevel        = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock            = DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag            = childForm;
            childForm.BringToFront();

            childForm.Show();
        }

        private void btn_dsb_Click(object sender, EventArgs e)
        {

            btn_tc.BackColor  = Color.White;
            btn_dm.BackColor  = Color.White;
            btn_dsb.BackColor = Color.AntiqueWhite;
            btn_td.BackColor  = Color.White;
            btn_Hd.BackColor  = Color.White;
            btn_dt.BackColor  = Color.White;
            btn_tk.BackColor  = Color.White;
            
            OpenChidFrom(new DSban(Quyen));
            
        }

       

        private void btn_tc_Click(object sender, EventArgs e)
        {
            btn_tc.BackColor  = Color.AntiqueWhite;
            btn_dm.BackColor  = Color.White;
            btn_dsb.BackColor = Color.White;
            btn_td.BackColor  = Color.White;
            btn_Hd.BackColor  = Color.White;
            btn_dt.BackColor  = Color.White;
            btn_tk.BackColor  = Color.White;


            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
        }

        private void btn_dt_Click(object sender, EventArgs e)
        {
            btn_tc.BackColor  = Color.White;
            btn_dm.BackColor  = Color.White;
            btn_dsb.BackColor = Color.White;
            btn_Hd.BackColor  = Color.White;
            btn_dt.BackColor  = Color.AntiqueWhite;
            btn_td.BackColor  = Color.White; 
            btn_tk.BackColor  = Color.White;
            OpenChidFrom(new DoanhThu());
        }

        private void btn_td_Click(object sender, EventArgs e)
        {
            btn_tc.BackColor  = Color.White;
            btn_dm.BackColor  = Color.White;
            btn_td.BackColor  = Color.AntiqueWhite;
            btn_dsb.BackColor = Color.White;
            btn_Hd.BackColor  = Color.White;
            btn_dt.BackColor  = Color.White;
            btn_tk.BackColor  = Color.White;
            OpenChidFrom(new ThucDon());
        }

        private void btn_tk_Click(object sender, EventArgs e)
        {

            btn_tc.BackColor  = Color.White;
            btn_dm.BackColor  = Color.White;
            btn_dsb.BackColor = Color.White;
            btn_Hd.BackColor  = Color.White;
            btn_td.BackColor  = Color.White;
            btn_dt.BackColor  = Color.White;
            btn_tk.BackColor  = Color.AntiqueWhite;       
            OpenChidFrom(new TaiKhoan(Quyen));
        }

        private void btn_thoatf_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn Thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_dm_Click(object sender, EventArgs e)
        {
            btn_tc.BackColor  = Color.White;
            btn_dm.BackColor  = Color.AntiqueWhite;
            btn_dsb.BackColor = Color.White;
            btn_td.BackColor  = Color.White;
            btn_Hd.BackColor  = Color.White;
            btn_dt.BackColor  = Color.White;
            btn_tk.BackColor  = Color.White;
        }

        private void btn_Hd_Click(object sender, EventArgs e)
        {
            btn_tc.BackColor  = Color.White;
            btn_dm.BackColor  = Color.White;
            btn_dsb.BackColor = Color.White;
            btn_Hd.BackColor  = Color.AntiqueWhite;
            btn_td.BackColor  = Color.White;
            btn_dt.BackColor  = Color.White;
            btn_tk.BackColor  = Color.White;
            OpenChidFrom(new HoaDon());

        }

        private void dxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Dangnhap dn = new Dangnhap();
            dn.ShowDialog();

            Program.currentlyLoggedInAs = 0;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            ClickThoat.BackColor = Color.Red;
        }

        private void ClickThoat_MouseLeave(object sender, EventArgs e)
        {
            ClickThoat.BackColor = Color.Transparent;
        }
    }
}
