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
        private const string SettingsUri = "..\\..\\Settings.xml";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            settings = XElement.Load(SettingsUri);
            XElement database = settings.Element("database");
            dataSource = database.Element("serverName")?.Value ?? dataSource;
            initialCatalog = database.Element("databaseName")?.Value ?? initialCatalog;
            finalConnectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", dataSource, initialCatalog);
            skipLogin = Boolean.Parse(settings.Element("behavior")?.Element("skipLogin")?.Value ?? "false");
            if (skipLogin)
            {
                Application.Run(new Trangchu());
            } else
            {
                XElement data = settings.Element("data");
                Application.Run(new Dangnhap(data?.Element("username")?.Value ?? "", data?.Element("password")?.Value ?? ""));
            }
        }
        public static XElement settings;
        public static string dataSource=@"localhost\sqlexpress", initialCatalog="DOAN";
        public static string finalConnectionString;
        public static Boolean skipLogin=false;

        public static class CurrentlyLoggedIn
        {
            public static int id = 0;
            public static string username, password;
        }
        private static void SaveLogin()
        {
            if (!String.IsNullOrWhiteSpace(CurrentlyLoggedIn.username))
            {
                settings.Element("data")?.Element("username")?.SetValue(CurrentlyLoggedIn.username);
            }
            if (!String.IsNullOrWhiteSpace(CurrentlyLoggedIn.password))
            {
                settings.Element("data")?.Element("password")?.SetValue(CurrentlyLoggedIn.password);
            }
        }
        public static void Exit()
        {
            SaveLogin();
            settings.Save(SettingsUri);
            Application.Exit();
        }
    }
}
 