using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using text.DTO;

namespace text.DAO
{
    internal class DsbanDAO
    {
        private static DsbanDAO instance;
        public static DsbanDAO Instance
        {
            get { if (instance == null) instance = new DsbanDAO(); return instance; }
            private set { instance = value; }
        }

        private DsbanDAO() {  }

        public bool insdsb(int id,string tinhtrangban,string tenban)
        {

            string sql = "insert into Dsban(Id,Tinhtrangban,Tenban) values ('"+id+ "','"+tinhtrangban+"','"+tenban+"')";
            int rs = DataProvider.Instance.ExecuteNonQuery(sql);

            return rs>0;
        }
        public bool updatedsb(int id, string tinhtrangban, string tenban)
        {
            string query = "update DSban set Tinhtrangban ='"+tinhtrangban+"',Tenban='"+tenban+"' where Id = '" + id + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Deletedsb(int id)
        {
            string query = "delete from DSban where Id = '" + id + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public static List<DsbanDTO> GetTables()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM DSBan")
                .AsEnumerable()
                .Select(table => new DsbanDTO(table))
                .ToList();
        }
        public static bool UpdateTable(int id, bool tinhtrangban)
        {
            return DataProvider.Instance.ExecuteNonQuery("UPDATE DSBan SET Tinhtrangban='" + HoaDon.ConvertToTinhtrangban(tinhtrangban)
                + "' WHERE Id='" + id + "'") > 0;
        }
    }
}
