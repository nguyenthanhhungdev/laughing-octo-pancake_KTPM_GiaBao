using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace text
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            XElement settings = XElement.Load("..\\..\\Settings.xml");
            XElement database = settings.Element("database");
            dataSource = database.Element("serverName")?.Value ?? dataSource;
            initialCatalog = database.Element("databaseName")?.Value ?? initialCatalog;
            finalConnectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", dataSource, initialCatalog);
            skipLogin = Boolean.Parse(database.Element("skipLogin")?.Value ?? "false");
            if (skipLogin)
            {
                Application.Run(new Trangchu());
            } else
            {
                Application.Run(new Dangnhap());
            }
        }
        public static string dataSource=@"localhost\sqlexpress", initialCatalog="DOAN";
        public static string finalConnectionString;
        public static Boolean skipLogin=false;

        public static int currentlyLoggedInAs = 0;
    }
}
 