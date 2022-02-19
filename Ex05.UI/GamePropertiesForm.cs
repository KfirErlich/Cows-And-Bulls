using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.UI
{
    public enum eNumberOfGuesses
    {
        MinGuesses = 4,
        MaxGuesses = 10
    }
    public partial class GamePropertiesForm : Form
    {
        private int m_NumOfChances = (int)eNumberOfGuesses.MinGuesses;
        public GamePropertiesForm()
        {
            InitializeComponent();
        }
        public int NumOfChances
        {
            get { return m_NumOfChances; }
            set { m_NumOfChances = value; }
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void GamePropertiesForm_Load(object sender, EventArgs e)
        {

        }
        private void buttonOfChances_Click(object sender, EventArgs e)
        {
          if(NumOfChances >= (int)eNumberOfGuesses.MaxGuesses)
          {
            NumOfChances = (int)eNumberOfGuesses.MinGuesses;
          }
          else
          {
            NumOfChances++;
          }
          m_ButtonOfChances.Text = string.Format("Number of chances: {0}", NumOfChances);
        }
    }
}
