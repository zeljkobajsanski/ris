using System.Windows.Forms;

namespace Rs.Dnevnik.Ris.Win.Utils
{
    public static class Extensions
    {
         public static void MoveTo(this BindingSource bindingSource, object item)
         {
             bindingSource.Position = bindingSource.IndexOf(item);
         }
    }
}