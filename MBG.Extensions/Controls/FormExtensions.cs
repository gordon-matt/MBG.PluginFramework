using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MBG.Extensions.Controls
{
    public static class FormExtensions
    {
        public static void CenterToParent(this Form form, Form parentForm)
        {
            if (parentForm != null)
            {
                CenterToParent(form, parentForm.Location, parentForm.Size);
            }
        }
        public static void CenterToParent(this Form form, Point parentLocation, Size parentSize)
        {
            CenterToParent(form, parentLocation, new Point(parentSize));
        }
        public static void CenterToParent(this Form form, Point parentLocation, Point parentSize)
        {
            if (parentLocation != null && parentSize != null)
            {
                int centerX = parentLocation.X + (parentSize.X / 2);
                int centerY = parentLocation.Y + (parentSize.Y / 2);

                int x = centerX - (form.Size.Width / 2);
                int y = centerY - (form.Size.Height / 2);

                form.Location = new Point(x, y);
            }
        }
    }
}