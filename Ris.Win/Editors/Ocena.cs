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
    public sealed class OcenaRepositoryItem : RepositoryItemLookUpEdit
    {
        static OcenaRepositoryItem()
        {
            Register();
        }

        public OcenaRepositoryItem()
        {
            ValueMember = "ID";
            DisplayMember = "Opis";
            NullText = "[Unesite ocenu]";
        }

        public void Reload()
        {
            using (var rf = IoC.Container.GetKernel().Get<IRepositoryFactory>())
            {
                DataSource = rf.OceneRepository.Ocene();
            }
        }

        public override string EditorTypeName { get { return "Ocena"; } }

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo("Ocena", typeof(Ocena), typeof(OcenaRepositoryItem),
               typeof(LookUpEditViewInfo), new ButtonEditPainter(), true));
        }
    }

    public sealed class Ocena : LookUpEdit
    {
         static Ocena()
         {
             OcenaRepositoryItem.Register();
         }

        public Ocena()
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

        public override string EditorTypeName { get { return "Ocena"; } }

         [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
         public new OcenaRepositoryItem Properties
         {
             get { return base.Properties as OcenaRepositoryItem; }
         }
    }
}