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
    public sealed class SektorRepositoryItem : RepositoryItemLookUpEdit
    {
        static SektorRepositoryItem()
        {
            Register();
        }

        public SektorRepositoryItem()
        {
            ValueMember = "ID";
            DisplayMember = "Naziv";
            NullText = "[Unesite sektor]";
        }

        public void Reload()
        {
            using (var rf = IoC.Container.GetKernel().Get<IRepositoryFactory>())
            {
                DataSource = rf.SektoriRepository.VratiSektore(0);
            }
        }

        public override string EditorTypeName { get { return "Sektor"; } }

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo("Sektor", typeof(Sektor), typeof(SektorRepositoryItem),
               typeof(LookUpEditViewInfo), new ButtonEditPainter(), true));
        }
    }

    public sealed class Sektor : LookUpEdit
    {
         static Sektor()
         {
             SektorRepositoryItem.Register();
         }

        public Sektor()
        {
            EnterMoveNextControl = true;
        }

        public void Reload()
        {
            Properties.Reload();
        }

        public override string EditorTypeName { get { return "Sektor"; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new SektorRepositoryItem Properties
        {
            get { return base.Properties as SektorRepositoryItem; }
        }
    }
}