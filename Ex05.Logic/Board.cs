using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.Logic
{
    public enum eRowLength
    {
        UserLength = 4,
        ComputerLength = 8
    }
    public enum eSign
    {
        CorrectPlaceInGuess = 'V',
        ExistInGuess = 'X'
    }
    public class Board
    {
        private char[,] m_BoardGame;
        private int m_Rows;
        private int m_Cols;

        public int Rows
        {
            get { return m_Rows; }
            set { m_Rows = value; }
        }
        public int Cols
        {
            get { return m_Cols; }
            set { m_Cols = value; }
        }
        public char[,] BoardGame
        {
            get { return m_BoardGame; }
            set { m_BoardGame = value; }
        }
        public void InitBoard(int i_NumOfGuesses)
        {
            Rows = i_NumOfGuesses;
            Cols = (int)eRowLength.ComputerLength;
            m_BoardGame = new char[Rows, Cols];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    BoardGame[i, j] = ' ';
                }
            }
        }
        public void SetBoard(int i_Row, int i_Col, char i_Sign)
        {
            m_BoardGame[i_Row, i_Col] = i_Sign;
        }
        public void InsertGuessToBoard(string i_Guess, int i_NumOfCurrentGuess)
        {
            for (int i = 0; i < (int)eRowLength.UserLength; i++)
            {
                BoardGame[i_NumOfCurrentGuess, i] = i_Guess[i];
            }
        }
    }
}
