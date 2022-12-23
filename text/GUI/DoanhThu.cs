using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using text.DAO;

namespace text
{
    public partial class DoanhThu : Form
    {
        public DoanhThu()
        {
            InitializeComponent();
            //LoadDateTimePickerBill();
        }

        void loadBillListDefault()
        {
            dtpkFromDate.CustomFormat = "dd-MM-yyyy";
            dtpkToDate.CustomFormat = "dd-MM-yyyy";
            string query = "SELECT * FROM Bill";
            DataProvider dataProvider = new DataProvider();
            var data = dataProvider.ExecuteQuery(query);
            UpdateTotal(data);
            dgvListBill.DataSource = data;
        }

        void loadBillList()
        {
            dtpkFromDate.CustomFormat = "dd-MM-yyyy";
            dtpkToDate.CustomFormat = "dd-MM-yyyy";
            //string query = string.Format("SELECT * FROM Bill WHERE creation <= '{0}' AND creation >= '{1}'", dtpkToDate.Value, dtpkFromDate.Value);
            string query = string.Format("SELECT * FROM Bill WHERE creation < '{0}' AND creation >= '{1}'", dtpkToDate.Value.AddDays(1), dtpkFromDate.Value);
            DataProvider dataProvider = new DataProvider();
            var data = dataProvider.ExecuteQuery(query);
            UpdateTotal(data);
            dgvListBill.DataSource = data;
        }
        private void UpdateTotal(DataTable table)
        {
            Total.Text = String.Format("{0:n0}", table.AsEnumerable().Sum(row => decimal.Parse(row["total"].ToString())));
        }
        /*
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        } 
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dgvListBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        } */

        private void btnEnter_Click(object sender, EventArgs e)
        {
            loadBillList();
        }

        private void DoanhThu_Load(object sender, EventArgs e)
        {
            loadBillListDefault();
        }

    }
}
