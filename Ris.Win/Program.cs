using System;
using System.Data.Entity;
using System.Windows.Forms;
using Rs.Dnevnik.Ris.EntityFramework;
using Rs.Dnevnik.Ris.EntityFramework.Configurations;
using Rs.Dnevnik.Ris.Win.IoC;
using Ninject;
using Rs.Dnevnik.Ris.Win.Modules.RadniNalog;

namespace Rs.Dnevnik.Ris.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Database.SetInitializer(new DatabaseInitializer());
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            Application.Run(new Shell());
        }
    }
}