using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ex05.UI
{
    public class BoardButton : Button
    {
        private static BoardButton s_Instance;
        private static readonly int sr_BoardButtonWidth = 40;
        private static readonly int sr_BoardButtonHeight = 40;
        private readonly int r_RowIndex;
        private readonly int r_ColIndex;
        private char m_ValueOfColor = '0';
        public static int BoardButtonWidth
        {
            get { return sr_BoardButtonWidth; }
        }
        public static int BoardButtonHeight
        {
            get { return sr_BoardButtonHeight; }
        }
        public int BoardButtonRowIndex
        {
            get { return r_RowIndex; }
        }
        public int BoardButtonColIndex
        {
            get { return r_ColIndex; }
        }
        public char valueOfColor 
        {
            get { return m_ValueOfColor; }
            set { m_ValueOfColor = value; }
        }
        public BoardButton(int i_RowIndex, int i_ColIndex)
        {
            s_Instance = this;
            this.Width = sr_BoardButtonWidth;
            this.Height = sr_BoardButtonHeight;
            r_RowIndex = i_RowIndex;
            r_ColIndex = i_ColIndex;
        }
    }
}
