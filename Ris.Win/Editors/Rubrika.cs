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
    public sealed class RubrikaRepositoryItem : RepositoryItemLookUpEdit
    {
        private int fIdPublikacije;

        static RubrikaRepositoryItem()
        {
            Register();
        }

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo("Rubrika", typeof(Rubrika), typeof(RubrikaRepositoryItem),
               typeof(LookUpEditViewInfo), new ButtonEditPainter(), true));
        }

        public RubrikaRepositoryItem()
        {
            ValueMember = "ID";
            DisplayMember = "Naziv";
            NullText = "[Izaberite rubriku]";
        }

        public override string EditorTypeName { get { return "Rubrika"; } }

        public int IdPublikacije
        {
            get { return fIdPublikacije; }
            set
            {
                if (IdPublikacije != value)
                {
                    fIdPublikacije = value;
                    Reload();
                }
            }
        }

        public void Reload()
        {
            using (var rf = IoC.Container.GetKernel().Get<IRepositoryFactory>())
            {
                DataSource = rf.RubrikeRepository.VratiRubrike(IdPublikacije);
            }
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                var source = item as RubrikaRepositoryItem;
                if (source == null) return;
                this.IdPublikacije = source.IdPublikacije;
            }
            finally
            {
                EndUpdate();
            }
        }
    }

    public sealed class Rubrika : LookUpEdit
    {
        static Rubrika()
        {
            RubrikaRepositoryItem.Register();
        }

        public override string EditorTypeName { get { return "Rubrika"; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RubrikaRepositoryItem Properties
        {
            get { return base.Properties as RubrikaRepositoryItem; }
        }

        public Rubrika()
        {
            EnterMoveNextControl = true;
        }

        public void Reload()
        {
            Properties.Reload();
        }
    }
}