using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Utils;
using System.IO;


namespace Ex05_Othelo
{ 
    public partial class GameForm : Form
    {
        private int m_RowClicked;
        private int m_ColumnClicked;
        private int m_SizeBoard;
        Board m_Board;
        List<PictureBox> m_BoardButtons = new List<PictureBox>();
        PictureBoxClick m_PictureBoxClick;
        
        public int SizeBoard
        {
            set
            {
                m_SizeBoard = value;
            }
        }
        public Board Board
        {
            get { return m_Board; }
            set { m_Board = value; }
        }
        public int RowClicked
        {
            get { return m_RowClicked; }
        }
        public int ColumnClicked
        {
            get { return m_ColumnClicked; }
        }
        public GameForm(Board i_Board ,PictureBoxClick i_ButtonClick)
        {
            m_PictureBoxClick = i_ButtonClick;
            m_Board = i_Board;
            InitializeComponent();
        }
        private void GameForm_Load(object sender, EventArgs e)
        {
            start();
        }
        PictureBox PictureBoxButton(colorType i_Color, int i_IndexButton)
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory());
            PictureBox button = new PictureBox();
            button.Height = 40;
            button.Width = 40;
            button.Click += (sender, args) => button_click(i_IndexButton);
            if(i_Color == colorType.O)
            {
                button.Image = Properties.Resources.CoinRed;
                button.SizeMode = PictureBoxSizeMode.StretchImage;
                button.Enabled = false;
            }
            else if(i_Color == colorType.X)
            {
                button.Image = Properties.Resources.CoinYellow;
                button.SizeMode = PictureBoxSizeMode.StretchImage;
                button.Enabled = false;
            }
            else if(i_Color == colorType.G)
            {
                button.BackColor = System.Drawing.Color.Green;
                button.Enabled = true;
            }
            else
            {
                button.Enabled = false;
            }
            return button;
        }
        public void ChangeTitle(playerColor i_PlayerColorTurn)
        {
            string colorTurn;
            if (i_PlayerColorTurn == playerColor.black)
            {
                colorTurn = "Red";
            }
            else
            {
                colorTurn = "Yellow";
            }
            this.Text = string.Format("Othello - {0}'s Turn", colorTurn);
        }
        private void button_click(int i_IndexButton)
        {
            m_RowClicked = i_IndexButton / m_SizeBoard;
            m_ColumnClicked = i_IndexButton % m_SizeBoard;
            m_PictureBoxClick.Round(this);
        }
        public void EndMessge(string i_Text)
        {
            DialogResult result = MessageBox.Show(i_Text, "Othelo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.No)
            {
                System.Environment.Exit(-1);
            }
            else
            {
                start();
            }
        }
        private void start()
        {
            int heightFormSize = (40 * m_SizeBoard) + (15 * m_SizeBoard);
            int widthtFormSize = (40 * m_SizeBoard) + (13 * m_SizeBoard);
            int heightBoardMatrix = 40 * (m_SizeBoard + 2);
            int widthtBoardMatrix = 40 * (m_SizeBoard + 2);
            this.Height = heightFormSize;
            this.Width = widthtFormSize;
            boardMatrix.Height = heightBoardMatrix;
            boardMatrix.Width = widthtBoardMatrix;
            int indexButton = 0;
            foreach (colorType button in m_Board.MatrixBoard)
            {
                PictureBox addButton = PictureBoxButton(button, indexButton);
                boardMatrix.Controls.Add(addButton);
                m_BoardButtons.Add(addButton);
                indexButton++;
            }
        }
        public void SetGameFrom()
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory());
            int indexBoardButtons = 0;
            foreach (colorType cell in m_Board.MatrixBoard)
            {
                if (cell == colorType.O)
                {
                    m_BoardButtons[indexBoardButtons].BackColor = System.Drawing.Color.Gainsboro;
                    m_BoardButtons[indexBoardButtons].Image = Properties.Resources.CoinRed;
                    m_BoardButtons[indexBoardButtons].SizeMode = PictureBoxSizeMode.StretchImage;
                    m_BoardButtons[indexBoardButtons].Enabled = false;
                }
                else if (cell == colorType.X)
                {
                    m_BoardButtons[indexBoardButtons].BackColor = System.Drawing.Color.Gainsboro;
                    m_BoardButtons[indexBoardButtons].Image = Properties.Resources.CoinYellow;
                    m_BoardButtons[indexBoardButtons].SizeMode = PictureBoxSizeMode.StretchImage;
                    m_BoardButtons[indexBoardButtons].Enabled = false;
                }
                else if (cell == colorType.G)
                {
                    m_BoardButtons[indexBoardButtons].BackColor = System.Drawing.Color.Green;
                    m_BoardButtons[indexBoardButtons].Enabled = true;
                }
                else
                {
                    m_BoardButtons[indexBoardButtons].BackColor = System.Drawing.Color.Gainsboro;
                    m_BoardButtons[indexBoardButtons].Enabled = false; 
                }
                indexBoardButtons++;
            }
        }
        public void StartGameFrom()
        {
            start();  
        }
    }
}