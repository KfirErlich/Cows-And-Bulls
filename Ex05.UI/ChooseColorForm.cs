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
    public enum eColors
    {
        Purple = 'A',
        Red,
        Green,
        Cyan,
        Blue,
        Yellow,
        Chocolate,
        White
    }
    public partial class ChooseColorForm : Form
    {
        public static ChooseColorForm s_Instance;
        internal Color[] m_Colors = new Color[Enum.GetNames(typeof(eColors)).Length];
        // $G$ CSS-999 (-2) Bad members variable name (should be in the form of m_PascalCase).
        private Color m_chosenColor;
        private Object m_Sender;
        public ChooseColorForm(Object i_Sender)
        {
            m_Sender = i_Sender;
            s_Instance = this; // ?
            InitializeComponent();
            initColorsArray(m_Colors);
            int pixelsFromLeft = 10;
            int pixelFromTop = 10;
            int pixelBetweenButtons = 5;
            int colorButtonSize = 40;

            for (int i = 0; i < Enum.GetNames(typeof(eColors)).Length; i++)
            {
                if (i == (Enum.GetNames(typeof(eColors)).Length/2))
                {
                    pixelFromTop += colorButtonSize + pixelBetweenButtons;
                    pixelsFromLeft = 10;
                }
                Button currColorButton = new Button();
                currColorButton.Location = new Point(pixelsFromLeft, pixelFromTop);
                currColorButton.Size = new Size(colorButtonSize, colorButtonSize);
                currColorButton.BackColor = m_Colors[i];
                this.Controls.Add(currColorButton);
                currColorButton.Click += colorButton_Clicked;
                pixelsFromLeft += pixelBetweenButtons + colorButtonSize;
            }
            this.Size = new Size(pixelsFromLeft + 20, pixelFromTop * 3 - 20);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Choose color";
        }
        public Color ChosenColor
        {
            get { return m_chosenColor; }
            set { m_chosenColor = value; }
        }
        public Object Sender
        {
            get { return m_Sender; }
        }
        private void initColorsArray(Color[] i_ColorsArr)
        {
            i_ColorsArr[0]=Color.Purple;
            i_ColorsArr[1] = Color.Red;
            i_ColorsArr[2] = Color.Green;
            i_ColorsArr[3] = Color.Cyan;
            i_ColorsArr[4] = Color.Blue;
            i_ColorsArr[5] = Color.Yellow;
            i_ColorsArr[6] = Color.Chocolate;
            i_ColorsArr[7] = Color.White;
        }
        private void ChooseColorForm_Load(object sender, EventArgs e)
        {

        }
        // $G$ DSN-999 (-3) better use enumerations here
        private void colorButton_Clicked(object sender, EventArgs e)
        {
            Button currButton = sender as Button;
            (m_Sender as BoardButton).BackColor = currButton.BackColor;

            switch ((m_Sender as BoardButton).BackColor.Name)
            {
                case "Purple":
                    (m_Sender as BoardButton).valueOfColor = (char)eColors.Purple;
                    break;
                case "Red":
                    (m_Sender as BoardButton).valueOfColor = (char) eColors.Red;
                    break;
                case "Green":
                    (m_Sender as BoardButton).valueOfColor = (char)eColors.Green;
                    break;
                case "Cyan":
                    (m_Sender as BoardButton).valueOfColor = (char)eColors.Cyan;
                    break;
                case "Blue":
                    (m_Sender as BoardButton).valueOfColor = (char)eColors.Blue;
                    break;
                case "Yellow":
                    (m_Sender as BoardButton).valueOfColor = (char)eColors.Yellow;
                    break;
                case "Chocolate":
                    (m_Sender as BoardButton).valueOfColor = (char)eColors.Chocolate;
                    break;
                case "White":
                    (m_Sender as BoardButton).valueOfColor = (char)eColors.White;
                    break;
            }
            this.Close();
        }
    }
}