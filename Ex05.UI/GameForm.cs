using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Ex05.Logic;

namespace Ex05.UI
{
    public partial class GameForm : Form
    {
        private readonly GamePropertiesForm r_GamePropertiesForm;
        // $G$ NTT-999 (-2) Redundant namespace prefix.
        private readonly Logic.BoolPgia r_GameLogic;
        private readonly BoardButton[,] r_MatrixGuessButton;
        private readonly Button[,] r_MatrixAnswerButton;
        private readonly ArrowButton[] r_ArrowButtonArray;
        private readonly BoardButton[] r_ComputerGuess;
        // $G$ DSN-999 (-2) Redundent member - unused.
        private readonly ChooseColorForm r_ChooseColorForm;
        public GameForm()
        {
            InitializeComponent();
            r_GamePropertiesForm = new GamePropertiesForm();

            if (r_GamePropertiesForm.ShowDialog() == DialogResult.OK)
            {
                r_GameLogic = new Logic.BoolPgia(r_GamePropertiesForm.NumOfChances);
                r_MatrixGuessButton = new BoardButton[r_GamePropertiesForm.NumOfChances, (int)eNumOfAnswers.numOfAnswers];
                r_MatrixAnswerButton = new Button[r_GamePropertiesForm.NumOfChances, (int)eNumOfAnswers.numOfAnswers];
                r_ArrowButtonArray = new ArrowButton[r_GamePropertiesForm.NumOfChances];
                r_ComputerGuess = new BoardButton[(int)eNumOfAnswers.numOfAnswers];
                buildGameBoard();
            }
            else
            {
                Environment.Exit(1);
            }
        }
        public BoardButton[] ComputerBoardArray
        {
            get { return r_ComputerGuess; }
        }
        public GamePropertiesForm GamePropertiesForm
        {
            get { return r_GamePropertiesForm; }
        }
        public ArrowButton[] ArrowButtonArray
        {
            get { return r_ArrowButtonArray; }
        }
        public BoardButton[,] MatrixGuessButton
        {
            get { return r_MatrixGuessButton; }
        }
        public Button[,] MatrixAnswerButton
        {
            get { return r_MatrixAnswerButton; }
        }
        private void GameForm_Load(object sender, EventArgs e)
        {

        }
        private void buildGameBoard()
        {
            int pixelBetweenButtons = 5;
            int pixelFromLeft = 10;
            int pixelFromTop = 10;
            int boardHeight = 0;
            int boardWidth = 0;
            int randomPartHeight = 0;
            int smallSquareSize = BoardButton.BoardButtonHeight / 3;
            initRandomButtons(ref pixelFromLeft, ref pixelFromTop, ref randomPartHeight, pixelBetweenButtons, ComputerBoardArray);

            for (int i = 0; i < r_GamePropertiesForm.NumOfChances; i++)
            {
                initBoardButton(ref pixelFromLeft, MatrixGuessButton, i, pixelBetweenButtons, pixelFromTop);
                initArrowButtons(ref pixelFromLeft, pixelFromTop, pixelBetweenButtons, ArrowButtonArray, i);
                int answerButtonTopLocation = pixelFromTop + pixelBetweenButtons / 2;

                initSmallSquares(ref answerButtonTopLocation, ref pixelFromLeft, MatrixAnswerButton, pixelBetweenButtons, smallSquareSize, i);
                pixelFromLeft = 10;
                pixelFromTop += pixelBetweenButtons + BoardButton.BoardButtonHeight;
            }
            // $G$ CSS-007 (-2) Missing blank line, after "for" block.
            boardWidth = r_MatrixAnswerButton[r_GamePropertiesForm.NumOfChances - 1,(int) eNumOfAnswers.numOfAnswers - 1].Left + smallSquareSize + pixelBetweenButtons;
            boardHeight = pixelFromTop + 10;
            this.ClientSize = new Size(boardWidth, boardHeight);
        }
        // $G$ CSS-025 (-2) Symbols are not spaced properly.
        private void initBoardButton(ref int io_PixelFromLeft, BoardButton[,] i_MatrixGuessButton,int i_CurrIndex, int i_PixelBetweenButtons, int i_PixelFromTop)
        {
            for (int j = 0; j < (int)eNumOfAnswers.numOfAnswers; j++)
            {
                BoardButton currButton = new BoardButton(i_CurrIndex, j);
                currButton.Location = new Point(io_PixelFromLeft, i_PixelFromTop);
                r_MatrixGuessButton[i_CurrIndex, j] = currButton;
                this.Controls.Add(currButton);
                if (i_CurrIndex != 0)
                {
                    currButton.Enabled = false;
                }
                currButton.Click += boardButton_Clicked;
                io_PixelFromLeft += i_PixelBetweenButtons + currButton.Width;
            }
        }
        private void initSmallSquares(ref int io_AnswerButtonTopLocation, ref int io_PixelFromLeft, Button[,] i_MatrixAnswerButton, int i_PixelBetweenButtons, int i_SmallSquareSize, int i_CurrIndex)
        {
            for (int j = 0; j < (int)eNumOfAnswers.numOfAnswers; j++)
            {
                if (j == ((int)eNumOfAnswers.numOfAnswers) / 2)
                {
                    io_AnswerButtonTopLocation += i_SmallSquareSize + i_PixelBetweenButtons;
                    io_PixelFromLeft -= (2 * (i_SmallSquareSize + i_PixelBetweenButtons));
                }
                Button currAnswerButton = new Button();
                currAnswerButton.Location = new Point(io_PixelFromLeft, io_AnswerButtonTopLocation);
                r_MatrixAnswerButton[i_CurrIndex, j] = currAnswerButton;
                currAnswerButton.Size = new Size(i_SmallSquareSize, i_SmallSquareSize);
                this.Controls.Add(currAnswerButton);
                io_PixelFromLeft += i_PixelBetweenButtons + currAnswerButton.Width;
            }
        }
        private void initRandomButtons(ref int io_PixelFromLeft, ref int io_PixelFromTop, ref int io_RandomPartHeight, int i_PixelBetweenButtons, BoardButton[] i_ComputerBoardArray)
        {
            for (int i = 0; i < (int)eNumOfAnswers.numOfAnswers; i++)
            {
                BoardButton currRandomButton = new BoardButton(0, i);
                currRandomButton.Location = new Point(io_PixelFromLeft, io_PixelFromTop);
                currRandomButton.Size = new Size(40, 40);
                io_PixelFromLeft += i_PixelBetweenButtons + currRandomButton.Width;
                currRandomButton.BackColor = Color.Black;
                r_ComputerGuess[i] = currRandomButton;
                currRandomButton.Enabled = false;
                this.Controls.Add(currRandomButton);
            }
            io_PixelFromLeft = 10;
            io_PixelFromTop = 30 + BoardButton.BoardButtonHeight;
            io_RandomPartHeight = io_PixelFromTop;
        }
        private void initArrowButtons(ref int io_PixelFromLeft, int i_PixelFromTop, int i_PixelBetweenButtons, ArrowButton[] i_ArrowButtonArray, int i_CurrentIndex)
        {
            ArrowButton arrowButton = new ArrowButton();
            arrowButton.Location = new Point(io_PixelFromLeft, i_PixelFromTop + (arrowButton.Height / 2));
            r_ArrowButtonArray[i_CurrentIndex] = arrowButton;
            this.Controls.Add(arrowButton);
            arrowButton.Click += arrowButton_Clicked;
            io_PixelFromLeft += (2 * i_PixelBetweenButtons) + arrowButton.Width;
        }
        private void boardButton_Clicked(object sender, EventArgs e)
        {
            ChooseColorForm currColorForm = new ChooseColorForm(sender);
            currColorForm.ShowDialog();
            BoardButton currBoardButton = sender as BoardButton;
            r_GameLogic.BoardGame.BoardGame[currBoardButton.BoardButtonRowIndex, currBoardButton.BoardButtonColIndex] = currBoardButton.valueOfColor;
            if (r_GameLogic.isRawFull())
            {
                r_ArrowButtonArray[r_GameLogic.CurrentGuessNumber].Enabled = true;
                r_GameLogic.createCurrentGuessString();
            }
        }
        private void arrowButton_Clicked(object sender, EventArgs e)
        {
            bool isWin = true;
            if (r_GameLogic.CheckValidation(r_GameLogic.CurrentGuess))
            {
                r_GameLogic.BoardGame.InsertGuessToBoard(r_GameLogic.CurrentGuess, r_GameLogic.CurrentGuessNumber);
                String guessResult = r_GameLogic.StateOfGuess(r_GameLogic.CurrentGuess, ref isWin);
                r_ArrowButtonArray[r_GameLogic.CurrentGuessNumber].Enabled = false;
                colorAnswerSquares(guessResult);

                for (int i = 0; i < (int)eNumOfAnswers.numOfAnswers; i++)
                {
                    r_MatrixGuessButton[r_GameLogic.CurrentGuessNumber, i].Enabled = false;
                    if (r_GameLogic.CurrentGuessNumber + 1 < r_GamePropertiesForm.NumOfChances)
                    {
                        r_MatrixGuessButton[r_GameLogic.CurrentGuessNumber + 1, i].Enabled = true;
                    }
                }
                if(isWin)
                {
                    gameResult(ComputerBoardArray, "You Win!","Win");
                }
                else if (r_GameLogic.CurrentGuessNumber == (GamePropertiesForm.NumOfChances - 1))
                {
                    gameResult(ComputerBoardArray, "You Lose!", "Lose");
                }
                else
                {
                    r_GameLogic.CurrentGuessNumber++;
                }
            }
            else
            {
                MessageBox.Show("Your guess is not valid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gameResult(BoardButton[] i_ComputerBoardArray, string i_Message, string i_Caption)
        {
            makeComputerGuessInColor(ComputerBoardArray);
            DialogResult anotherGame = MessageBox.Show(string.Format("{0}{1}Would you like to play another game?", i_Message, Environment.NewLine), i_Caption,
                                                       MessageBoxButtons.YesNo);
            if (anotherGame == DialogResult.Yes)
            {
                clearBoard();
            }
            else
            {
                MessageBox.Show("Thank you for playing!");
                Environment.Exit(1);
            }
        }
        private void clearBoard()
        {
            r_GameLogic.clearBoard();
            for(int i = 0; i< r_GamePropertiesForm.NumOfChances; i++)
            {
                for(int j = 0; j < (int)eNumOfAnswers.numOfAnswers; j++)
                {
                    r_MatrixGuessButton[i, j].BackColor = Color.Transparent;
                    r_MatrixAnswerButton[i, j].BackColor = Color.Transparent;
                }
            }
            for(int i=0; i< (int)eNumOfAnswers.numOfAnswers; i++)
            {
                r_ComputerGuess[i].BackColor = Color.Black;
                r_MatrixGuessButton[0, i].Enabled = true;
            }
        }
        private void colorAnswerSquares(String i_GuessResult)
        {
            int i = 0;
            while (i < i_GuessResult.Length && i_GuessResult[i] == 'V')
            {
                r_MatrixAnswerButton[r_GameLogic.CurrentGuessNumber, i].BackColor = Color.Black;
                i++;
            }
            while (i < i_GuessResult.Length && i_GuessResult[i] == 'X')
            {
                r_MatrixAnswerButton[r_GameLogic.CurrentGuessNumber, i].BackColor = Color.Yellow;
                i++;
            }
        }
        private void makeComputerGuessInColor(Button[] i_ComputerGuess)
        {
            for (int i = 0; i < (int)eNumOfAnswers.numOfAnswers; i++)
            {
                i_ComputerGuess[i].BackColor = colorConverter(r_GameLogic.ComputerGuess[i]);
            }
        }
        // $G$ DSN-999 (-3) better use enumerations here
        private Color colorConverter(Char i_CurrentColorValueSymbol)
        {
            Color currColor = Color.Black;

            switch (i_CurrentColorValueSymbol)
            {
                case 'A':
                    currColor = Color.Purple;
                 break;
                case 'B':
                    currColor = Color.Red;
                    break;
                case 'C':
                    currColor = Color.Green;
                    break;
                case 'D':
                    currColor = Color.Cyan;
                    break;
                case 'E':
                    currColor = Color.Blue;
                    break;
                case 'F':
                    currColor = Color.Yellow;
                    break;
                case 'G':
                    currColor = Color.Chocolate;
                    break;
                case 'H':
                    currColor = Color.White; 
                    break;
            }
            return currColor;
        }
    }
}
