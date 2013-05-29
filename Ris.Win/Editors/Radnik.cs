using System;
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
    public sealed class RadnikRepositoryItem : RepositoryItemLookUpEdit
    {
        static RadnikRepositoryItem()
        {
            Register();
        }

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo("Radnik", typeof(Radnik), typeof(RadnikRepositoryItem),
               typeof(LookUpEditViewInfo), new ButtonEditPainter(), true));
        }

        public RadnikRepositoryItem()
        {
            ValueMember = "ID";
            DisplayMember = "ImeIPrezime";
            NullText = "[Izaberite radnika]";
        }

        public override string EditorTypeName { get { return "Radnik"; } }

        public void Reload()
        {
            using (var rf = IoC.Container.GetKernel().Get<IRepositoryFactory>())
            {
                DataSource = rf.RadniciRepository.VratiRadnike();
            }
        }
    }

    public sealed class Radnik : LookUpEdit
    {
         static Radnik()
         {
             RadnikRepositoryItem.Register();
         }

         public override string EditorTypeName { get { return "Radnik"; } }

         [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
         public new RadnikRepositoryItem Properties
         {
             get { return base.Properties as RadnikRepositoryItem; }
         }

        public Radnik()
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

        public int? IzabraniId
        {
            get
            {
                if (EditValue != null && EditValue != DBNull.Value)
                {
                    return Convert.ToInt32(EditValue);
                }
                return null;
            }
        }
    }
}