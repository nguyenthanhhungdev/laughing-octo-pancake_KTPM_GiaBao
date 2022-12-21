using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text.DTO;
using static System.Net.Mime.MediaTypeNames;

namespace text.DAO
{
    internal class TaikhoanDao
    {
        private static TaikhoanDao instance;
        public static TaikhoanDao Instance { 
            get { if (instance == null) instance = new TaikhoanDao();  return instance; }
            private set { instance = value; }
        }

        private TaikhoanDao() { }

        public bool login(string username, string password)
        {
            string sql = "select * from Taikhoan where Tentk =N'"+username+"'and Mk=N'"+password+"'";

            DataTable rs = DataProvider.Instance.ExecuteQuery(sql);


            return rs.Rows.Count >0;
        }

        public taikhoanDTO GetTaikoanByUsn(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Taikhoan where Tentk='" + username+"'");
            foreach (DataRow item in data.Rows){
                return new taikhoanDTO(item);
            }
            return null;
        }

        public bool instk(string Tentk, string Tenhienthi, string Loai)
        {

            string sql = "insert into Taikhoan(Tentk,Mk,Tenhienthi,Loai) values ('" + Tentk + "','123456','" + Tenhienthi + "','"+Loai+"')";
            int rs = DataProvider.Instance.ExecuteNonQuery(sql);

            return rs > 0;
        }
        public bool updatetk(string Tentk, string Tenhienthi, string Loai,int id)
        {
            string query = "update Taikhoan set Tentk = '" + Tentk+ "', Tenhienthi ='" + Tenhienthi + "',Loai='" + Loai + "' where Id='"+id+"'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Deletetk(int id)
        {
            string query = "delete from Taikhoan where Id = '" + id + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool updateac(string usn, string mk)
        {
            string sql = "update Taikhoan set Mk='"+mk+"' where Tentk = '" + usn + "'";
            int  rs = DataProvider.Instance.ExecuteNonQuery(sql);
            
            return    rs>0;
        }
    }
}
