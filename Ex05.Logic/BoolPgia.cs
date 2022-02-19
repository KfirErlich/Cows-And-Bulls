using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.Logic
{
    public enum eNumOfAnswers
    {
        numOfAnswers = 4
    }
    public class BoolPgia
    {
        private int m_NumberOfGuesses;
        private string m_ComputerGuess = null;
        private readonly Board r_BoardGame;
        private string m_CurrentGuess;
        private int m_GuessNumber = 0;

        public BoolPgia(int i_numOfGuesses)
        {
            r_BoardGame = new Board();
            r_BoardGame.InitBoard(i_numOfGuesses);
            m_NumberOfGuesses = i_numOfGuesses;
            m_ComputerGuess = RandomInput();
        }
        public Board BoardGame
        {
            get { return r_BoardGame; }
        }
        public string ComputerGuess
        {
            get { return m_ComputerGuess; }
            set { m_ComputerGuess = value; }
        }
        public int CurrentGuessNumber
        {
            get { return m_GuessNumber; }
            set { m_GuessNumber = value; }
        }
        public string CurrentGuess
        {
            get { return m_CurrentGuess; }
            set { m_CurrentGuess = value; }
        }
        public bool CheckValidation(string i_UserGuess)
        {
            return checkCapitalLetters(i_UserGuess) &&
                   checkValidRange(i_UserGuess) &&
                   checkNumberOfLetters(i_UserGuess) &&
                   checkEqualLetters(i_UserGuess);
        }
        public string RandomInput()
        {
            string randomLetters = null;
            // $G$ NTT-007 (-5) There's no need to re-instantiate the Random instance each time it is used.
            Random random = new Random();
            char randomChar = ' ';
            // $G$ DSN-999 (-2) Redundent variable - unused.
            bool isUnique = true;

            randomLetters += Convert.ToChar(random.Next(65, 72));
            for (int i = 1; i < (int)eNumOfAnswers.numOfAnswers; i++)
            {
                randomChar = Convert.ToChar(random.Next(65, 72));
                while (randomLetters.Contains(randomChar))
                {
                    randomChar += Convert.ToChar(random.Next(65, 72));
                }

                randomLetters += randomChar;
            }

            return randomLetters;
        }
        public string StateOfGuess(String currentGuess, ref bool isWin)
        {
            string resultOfGuess = null;
            int ticCounter = 0;
            int xCounter = 0;
            isWin = CheckNextGuessInput(currentGuess, ref ticCounter, ref xCounter); // check if need the board
            resultOfGuess = CreateGuessAnswer(ticCounter,xCounter);
            return (resultOfGuess);
        }

        public bool isRawFull()
        {
            bool isFull = true;

            for (int i = 0; i < (int)eNumOfAnswers.numOfAnswers; i++)
            {
                if ((BoardGame.BoardGame[CurrentGuessNumber, i]) == ' ')
                {
                    isFull = false;
                }
            }
            return isFull;
        }
        public void clearBoard()
        {
            for (int i = 0; i <BoardGame.Rows; i++)
            {
                for (int j = 0; j < (int)eNumOfAnswers.numOfAnswers; j++)
                {
                    BoardGame.BoardGame[i, j] = ' ';
                }
            }
            CurrentGuessNumber = 0;
            // $G$ CSS-026 (-2) Bad code indentation.
             ComputerGuess = RandomInput();
        }
        public void createCurrentGuessString()
        {
            StringBuilder currGuessString = new StringBuilder();
            for (int i = 0; i < (int)eNumOfAnswers.numOfAnswers; i++)
            {
                currGuessString.Append(BoardGame.BoardGame[CurrentGuessNumber, i]);
            }
            CurrentGuess = currGuessString.ToString();
        }

        public string CreateGuessAnswer(int i_TicCounter, int i_XCounter)
        {
            StringBuilder resultOfGuess = new StringBuilder();

            if (i_XCounter != 0 || i_TicCounter != 0)
            {
                for (int i = 0; i < (int)eRowLength.UserLength; i++)
                {
                    if (i_TicCounter != 0)
                    {
                        resultOfGuess.Append((char)eSign.CorrectPlaceInGuess);
                        i_TicCounter--;
                    }
                    else if (i_XCounter != 0)
                    {
                        resultOfGuess.Append((char)eSign.ExistInGuess);
                        i_XCounter--;
                    }
                }
            }
            return (resultOfGuess.ToString());
        }
        public bool CheckNextGuessInput(string i_CurrGuess, ref int io_ticCounter, ref int io_XCounter)
        {
            bool isPerfectGuess = true;
            io_ticCounter = 0;
            io_XCounter = 0;
            for (int i = 0; i < i_CurrGuess.Length; i++)
            {
                for (int j = 0; j < ComputerGuess.Length; j++)
                {
                    if (i_CurrGuess[i] == ComputerGuess[j] && i == j)
                    {
                        io_ticCounter++;
                    }
                    else if (i_CurrGuess[i] == ComputerGuess[j] && i != j)
                    {
                        io_XCounter++;
                    }
                }
            }

            if (io_ticCounter != (int)eNumOfAnswers.numOfAnswers)
            {
                isPerfectGuess = false;
            }

            return isPerfectGuess;
        }
        private bool checkCapitalLetters(string i_StringToCheck)
        {
            foreach (char charCheck in i_StringToCheck)
            {
                // $G$ CSS-999 (-2) Use ! operator instead of == false.
                if (char.IsUpper(charCheck) == false)
                {
                    return false;
                }
            }

            return true;
        }

        // $G$ CSS-028 (-3) A method should not include more than one return statement.
        private bool checkValidRange(string i_StringToCheck)
        {
            foreach (char charCheck in i_StringToCheck)
            {
                if (charCheck < 'A' || charCheck > 'H')
                {
                    return false;
                }
            }

            return true;
        }

        private bool checkNumberOfLetters(string i_StringToCheck)
        {
            if (i_StringToCheck.Length != (int)eNumOfAnswers.numOfAnswers)
            {
                return false;
            }

            return true;
        }

        private bool checkEqualLetters(string i_StringToCheck)
        {
            for (int i = 0; i < i_StringToCheck.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (i_StringToCheck[i] == i_StringToCheck[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
