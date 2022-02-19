using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.UI
{
    public class ArrowButton : Button
    {
        private static readonly int sr_ArrowButtonWidth = 40;
        private static readonly int sr_ArrowButtonHeight = 20;
        public ArrowButton()
        {
            this.Width = sr_ArrowButtonWidth;
            this.Height = sr_ArrowButtonHeight;
            this.Text = "-->>";
            this.Enabled = false;
        }
        public static int ArrowButtonWidth
        {
            get { return sr_ArrowButtonWidth; }
        }
        public static int ArrowButtonHeight
        {
            get { return sr_ArrowButtonHeight; }
        }
    }
}
