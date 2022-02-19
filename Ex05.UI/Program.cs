using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// $G$ SFN-008 (-5) The --> buttons does changed status - 'button.Enabled = true' before all colors are chosen.

namespace Ex05.UI
{
    public class Program
    {
        public static void Main()
        {
            GameForm gameForm = new GameForm();
            gameForm.ShowDialog();
        }
    }
}
//TO DO:
// change Random (data member?)