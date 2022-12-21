using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text.DTO
{
    internal class DsbanDTO
    {
        public DsbanDTO () { }

        public DsbanDTO(string trangthai, string name, int id)
        {
            this.trangthai = trangthai;
            this.name = name;
            this.id = id;
        }
        public DsbanDTO(DataRow row)
        {
            this.trangthai = row["Tinhtrangban"].ToString();
            this.name = row["Tenban"].ToString();
            this.id = (int)row["Id"];
            
        }

        private string trangthai;
        public string Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
