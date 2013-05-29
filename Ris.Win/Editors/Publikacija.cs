using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using Ninject;
using Rs.Dnevnik.Ris.Interfaces.Repositories;

namespace Rs.Dnevnik.Ris.Win.Editors
{
    [UserRepositoryItem("Register")]
    public sealed class PublikacijaRepositoryItem : RepositoryItemLookUpEdit 
    {
        static PublikacijaRepositoryItem()
        {
            Register();
        }

         public static void Register()
         {
             EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo("Publikacija", typeof(Publikacija), typeof(PublikacijaRepositoryItem),
                typeof(LookUpEditViewInfo), new ButtonEditPainter(), true));
         }

        public PublikacijaRepositoryItem()
        {
            ValueMember = "ID";
            DisplayMember = "Naziv";
            NullText = "[Izaberite publikaciju]";
        }

        public override string EditorTypeName { get { return "Publikacija"; } }

        public void Reload()
        {
            using (var rf = IoC.Container.GetKernel().Get<IRepositoryFactory>())
            {
                DataSource = rf.PublikacijeRepository.Publikacije();
            }
            
        }
    }

    public sealed class Publikacija : LookUpEdit
    {
        static Publikacija()
        {
            PublikacijaRepositoryItem.Register();
        }

        public override string EditorTypeName { get { return "Publikacija"; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new PublikacijaRepositoryItem Properties
        {
            get { return base.Properties as PublikacijaRepositoryItem; }
        }

        public Publikacija()
        {
            EnterMoveNextControl = true;
            if (!IsDesignMode)
            {
                //Properties.Reload();
            }
        }

        public void Reload()
        {
            Properties.Reload();
        }
    }
}