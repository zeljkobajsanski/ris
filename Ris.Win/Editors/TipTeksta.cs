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
    public sealed class TipTekstaRepositoryItem : RepositoryItemLookUpEdit
    {
        static TipTekstaRepositoryItem()
        {
            Register();
        }

        public TipTekstaRepositoryItem()
        {
            ValueMember = "ID";
            DisplayMember = "Naziv";
            NullText = "[Unesite tip teksta]";
        }

        public override string EditorTypeName { get { return "TipTeksta"; } }

        public void Reload()
        {
            using (var rf = IoC.Container.GetKernel().Get<IRepositoryFactory>())
            {
                DataSource = rf.TipoviTekstovaRepository.TipoviTekstova();
            }
        }

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo("TipTeksta", typeof(TipTeksta), typeof(TipTekstaRepositoryItem),
               typeof(LookUpEditViewInfo), new ButtonEditPainter(), true));
        }
    }

    public sealed class TipTeksta : LookUpEdit
    {
         static TipTeksta()
         {
             TipTekstaRepositoryItem.Register();
         }

        public TipTeksta()
        {
            EnterMoveNextControl = true;
            if (!IsDesignMode)
            {
                //Properties.Reload();
            }
        }

        public override string EditorTypeName { get { return "TipTeksta"; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new TipTekstaRepositoryItem Properties
        {
            get { return base.Properties as TipTekstaRepositoryItem; }
        }

        public void Reload()
        {
            Properties.Reload();
        }
    }
}