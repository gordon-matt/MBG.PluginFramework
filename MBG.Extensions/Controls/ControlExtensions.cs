using System.Reflection;
using System.Windows.Forms;

namespace MBG.Extensions.Controls
{
    public static class ControlExtensions
    {
        private delegate object GetControlPropertyThreadSafeDelegate(Control control, string propertyName, object[] args);
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static object GetPropertyThreadSafe(this Control control, string propertyName, object[] args)
        {
            if (control.InvokeRequired)
            {
                return control.Invoke(new GetControlPropertyThreadSafeDelegate(
                    GetPropertyThreadSafe),
                    new object[] { control, propertyName, args });
            }
            else
            {
                return control.GetType().InvokeMember(
                    propertyName,
                    BindingFlags.GetProperty,
                    null,
                    control,
                    args);
            }
        }

        public static void SetPropertyThreadSafe(this Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(
                    SetPropertyThreadSafe),
                    new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(
                    propertyName,
                    BindingFlags.SetProperty,
                    null,
                    control,
                    new object[] { propertyValue });
            }
        }
    }
}