using System;
using System.Collections.Generic;
using Utils;

namespace Ex05_Othelo
{
    public class Game
    {
        protected Player m_Winner;
        protected Player m_FirstPlayer;
        protected Player m_SecondPlayer;
        protected Board m_Board;
        protected int m_BoardSize;
        protected statusGame m_Status;

        public Game(int i_BoardSize, playerType i_PlayerType)
        {
            m_FirstPlayer = getDataPlayer(colorType.X, playerType.Manual, true, false);
            m_SecondPlayer = getSecondPlayer(m_SecondPlayer, false, i_PlayerType);
            m_BoardSize = i_BoardSize;
            InitNewGame();
        }
        public void InitNewGame()
        {
            m_FirstPlayer.CoinsCount = 2;
            m_SecondPlayer.CoinsCount = 2;
            m_Board = new Board(m_BoardSize);
            m_Status = statusGame.Going;
        }
        private Player getDataPlayer(colorType i_color, playerType i_type, bool i_CurrentTurn, bool i_SecondPlayer)
        {
            return new Player(null, i_type, i_color, i_CurrentTurn);
        }

        private Player getSecondPlayer(Player i_SecondPlayer, bool i_CurrentTurn, playerType i_PlayerType)
        {
            bool inCorrectData = true;
            while (inCorrectData)
            {
                if (i_PlayerType == playerType.Manual)
                {
                    i_SecondPlayer = getDataPlayer(colorType.O, playerType.Manual, i_CurrentTurn, true);
                    inCorrectData = false;
                }
                else
                {
                    i_SecondPlayer = new Player(Utils.Constants.k_ComputerName, playerType.Computer, colorType.O, i_CurrentTurn);
                    inCorrectData = false;
                }
            }
            return i_SecondPlayer;
        }
        public playerColor GetPlayerTurn()
        {
            playerColor playerColorTurn;
            if (m_FirstPlayer.Turn == true)
            {
                playerColorTurn = playerColor.white;
            }
            else
            {
                playerColorTurn = playerColor.black;
                
            }
            return playerColorTurn;
        }
        public bool HaveMoves()
        {
            bool haveMoves = false;
            if (m_FirstPlayer.Turn == true)
            {
                haveMoves = m_Board.PlayerMovesOnBoard(m_FirstPlayer);
                m_FirstPlayer.HaveMoves = haveMoves;
            }
            else
            {
                haveMoves = m_Board.PlayerMovesOnBoard(m_SecondPlayer);
                m_SecondPlayer.HaveMoves = haveMoves;
            }
            return haveMoves;
        }
        public void StartTurns(int i_ColumnStep, int i_RowStep, bool i_QuittingTheGame , bool i_HaveMoves)
        {
            bool showMessageNoMoreOptions = false;
            bool haveMovesForFirstPlayer = true;
            if (m_FirstPlayer.Turn)
            { 
                if (i_HaveMoves)
                {
                    playerMakeStep(m_FirstPlayer, showMessageNoMoreOptions, m_SecondPlayer.Name, i_ColumnStep, i_RowStep, i_QuittingTheGame);
                    m_Board.SetBoard(m_FirstPlayer, m_SecondPlayer);
                    showMessageNoMoreOptions = false;
                }
                else
                {
                    showMessageNoMoreOptions = true;
                }
                switchPlayersTurns(m_SecondPlayer, m_FirstPlayer);
            }
            else if (m_SecondPlayer.Turn)
            {
                if (i_HaveMoves)
                {
                    playerMakeStep(m_SecondPlayer, showMessageNoMoreOptions, m_FirstPlayer.Name, i_ColumnStep, i_RowStep, i_QuittingTheGame);
                    m_Board.SetBoard(m_SecondPlayer, m_FirstPlayer);
                    showMessageNoMoreOptions = false;
                }
                else
                {
                    haveMovesForFirstPlayer = m_Board.PlayerMovesOnBoard(m_FirstPlayer);
                    if (haveMovesForFirstPlayer)
                    {
                        showMessageNoMoreOptions = true;
                    }
                    else
                    { 
                        UpdateGameStatus();
                        showMessageNoMoreOptions = false;
                    }
                }
                switchPlayersTurns(m_FirstPlayer, m_SecondPlayer);
            }
        }
        public void UpdateGameStatus()
        {
            if (m_FirstPlayer.CoinsCount > m_SecondPlayer.CoinsCount)
            {
                m_Status = statusGame.Winning;
                m_Winner = m_FirstPlayer;
                m_FirstPlayer.WinCounts++;
            }
            else if (m_FirstPlayer.CoinsCount < m_SecondPlayer.CoinsCount)
            {
                m_Status = statusGame.Winning;
                m_Winner = m_SecondPlayer;
                m_SecondPlayer.WinCounts++;
            }
            else
            {
                m_Status = statusGame.Tie;
            }
        }
        private void switchPlayersTurns(Player i_MekeOnPlayer, Player i_MakeOffPlayer)
        {
            i_MekeOnPlayer.Turn = true;
            i_MakeOffPlayer.Turn = false;
            cleanOptionMatrixBoard();
        }
        private void playerMakeStep(Player i_Player, bool i_ShowMessageNoMoreOptions, string i_RivalName, int i_ColumnStep, int i_RowStep, bool i_QuittingTheGame)
        {
            bool legalSquer;
            i_Player.GetStep(m_Board.Size, i_ColumnStep, i_RowStep, m_Board.MatrixBoard);
            if (i_QuittingTheGame)
            {
                m_Status = statusGame.Quit;  
            }
            legalSquer = m_Board.CheckLegalSquer(i_Player);
        }
        public colorType[,] MatrixBoard
        {
            get
            {
                return m_Board.MatrixBoard;
            }
        }
        public int BoardSize
        {
            get
            {
                return m_Board.Size;
            }
        }
        public statusGame statusGame
        {
            get
            {
                return m_Status;
            }
        }
        public Board Board
        {
            get
            {
                return m_Board;
            }
        }
        public Player Winner
        {
            get { return m_Winner; }
        }
        public Player FirstPlayer
        {
            get { return m_FirstPlayer; }
        }
        public Player SecondPlayer
        {
            get { return m_SecondPlayer; }
        }
        private void cleanOptionMatrixBoard()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (MatrixBoard[i, j] == colorType.G)
                    {
                        MatrixBoard[i, j] = colorType.nan;
                    }
                }
            }
        }  
    }
}
