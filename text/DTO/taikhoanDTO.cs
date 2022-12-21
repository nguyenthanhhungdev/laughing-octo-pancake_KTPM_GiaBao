using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace text.DTO
{
    internal class taikhoanDTO
    {
        public taikhoanDTO() { }
        public taikhoanDTO(string usn, string tht, string loai, string mk = null)
        {
            this.Usn = usn;
            this.Tenht = tht;
            this.Loai = loai;
            this.Mk = mk;
        }

        public taikhoanDTO(DataRow row)
        {
            this.Usn = row["Tendn"].ToString();
            this.Tenht = row["Tenht"].ToString();
            this.Mk = row["Mk"].ToString();
            this.Loai = row["Loai"].ToString();
        }

        private string loai;
        public string Loai
        {
            get { return loai; }
            set { loai = value; }
        }

        private string mk;
        public string Mk
        {
            get { return mk; }
            set { mk = value; }
        }

        private string tenht;
        public string Tenht
        {
            get { return tenht; }
            set { tenht = value; }
        }

        private string usn;
        public string Usn
        {
            get { return usn; }
            set { usn = value; }
        }
        
    }
}
