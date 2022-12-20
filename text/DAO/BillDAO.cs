using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            try
            {
                int newBillId = (int)DataProvider.Instance.ExecuteQuery(bill.Creation != null ? String.Format(
                    "INSERT INTO Bill(idNhanVien, status, discount, total, creation) OUTPUT Inserted.id VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                        bill.IDNhanvien, bill.Status, bill.Discount, bill.Total, bill.Creation)
                    : String.Format(
                        "INSERT INTO Bill(idNhanVien, status, discount, total) OUTPUT Inserted.id VALUES ('{0}', '{1}', '{2}', '{3}')",
                            bill.IDNhanvien, bill.Status, bill.Discount, bill.Total))
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
