using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using text.DTO;

namespace text.DAO
{
    internal static class BillDAO
    {
        public static Bill GetBill(int id)
        {
            return new Bill(DataProvider.Instance.ExecuteQuery("SELECT * FROM Bill WHERE id=" + id).Rows[0]);
        }
        public static List<Bill> GetBills(DateTime from, DateTime to)
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM Bill WHERE creation BETWEEN '" + from.ToString(Bill.dateFormat)
                + "' AND '" + to.ToString(Bill.dateFormat) + "'")
                .AsEnumerable()
                .Select(row => new Bill(row))
                .ToList();
        }
        public static List<BillDetail> GetBillDetails(Bill bill)
        {
            return GetBillDetails(bill.ID);
        }
        public static List<BillDetail> GetBillDetails(int billId)
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM BillDetail WHERE BillId=" + billId)
                .AsEnumerable()
                .Select(row => new BillDetail(row))
                .ToList();
        }
        public static Boolean InsertBill(Bill bill, List<BillDetail> details)
        {
            if (Program.skipLogin)
            {
                MessageBox.Show("Dang o che do test, se khong thuc su query vao CSDL", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            try
            {
                int newBillId = (int)DataProvider.Instance.ExecuteQuery(bill.Creation != null ? String.Format(
                    "INSERT INTO Bill(idNhanVien, status, discount, total, creation, idTable) OUTPUT Inserted.id VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                        bill.IDNhanvien, bill.Status, bill.Discount, bill.Total, bill.Creation, bill.IDTable)
                    : String.Format(
                        "INSERT INTO Bill(idNhanVien, status, discount, total, idTable) OUTPUT Inserted.id VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                            bill.IDNhanvien, bill.Status, bill.Discount, bill.Total, bill.IDTable))
                    .Rows[0]["id"];
                details.ForEach(detail => DataProvider.Instance.ExecuteNonQuery(String.Format("INSERT INTO BillDetail(billId, foodId, Quantity) VALUES ('{0}', '{1}', '{2}')",
                    newBillId, detail.FoodID, detail.Quantity)));
                return true;
            } catch (SqlException)
            {
                return false;
            }
        }
    }
}
