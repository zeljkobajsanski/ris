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
    public sealed class OdeljenjeRepositoryItem : RepositoryItemLookUpEdit
    {
        private int? m_IdSektora;

        static OdeljenjeRepositoryItem()
        {
            Register();
        }

        public OdeljenjeRepositoryItem()
        {
            ValueMember = "ID";
            DisplayMember = "Naziv";
            NullText = "[Unesite odeljenje]";
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? IdSektora
        {
            get { return m_IdSektora; }
            set
            {
                if (IdSektora == value) return;
                m_IdSektora = value;
                Reload();
            }
        }

        public void Reload()
        {
            using (var rf = IoC.Container.GetKernel().Get<IRepositoryFactory>())
            {
                DataSource = IdSektora.HasValue ? 
                    rf.OdeljenjaRepository.VratiOdeljenja(IdSektora.Value) : 
                    rf.OdeljenjaRepository.VratiOdeljenja();
            }
            
        }

        public override string EditorTypeName { get { return "Odeljenje"; } }

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo("Odeljenje", typeof(Odeljenje), typeof(OdeljenjeRepositoryItem),
               typeof(LookUpEditViewInfo), new ButtonEditPainter(), true));
        }
    }

    public sealed class Odeljenje : LookUpEdit
    {
         static Odeljenje()
         {
             OdeljenjeRepositoryItem.Register();
         }

        public Odeljenje()
        {
            EnterMoveNextControl = true;
        }

        public void Reload()
         {
             Properties.Reload();
         }

         public override string EditorTypeName { get { return "Odeljenje"; } }

         [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
         public new OdeljenjeRepositoryItem Properties
         {
             get { return base.Properties as OdeljenjeRepositoryItem; }
         }
    }
}