using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Threading.Tasks;

namespace Ex05_Othelo
{
    public class GameControl
    {
        Game m_StartGame;
        GameForm m_GameForm;
        PictureBoxClick m_PictureBoxClick;

        public GameControl(Game i_Game)
        {
            m_StartGame = i_Game;
            m_GameForm = new GameForm(m_StartGame.Board, m_PictureBoxClick);
            m_GameForm.SizeBoard = m_StartGame.BoardSize;
        }
        public  Game StartGame
        {
            set
            {
                m_StartGame = value;
            }
            get
            {
                return m_StartGame;
            }
        }
        public void SetButtonClick()
        {
            m_PictureBoxClick = new PictureBoxClick(this);
        }
        public void FirstRound(GameForm i_GameForm)
        {
            i_GameForm.SizeBoard = m_StartGame.BoardSize;
            i_GameForm.StartGameFrom();

            bool haveMoves = m_StartGame.HaveMoves();
            while ((!haveMoves) && (m_StartGame.FirstPlayer.HaveMoves == true || m_StartGame.SecondPlayer.HaveMoves == true))
            {
                switchPlayersTurn();
                haveMoves = m_StartGame.HaveMoves();
            }
            if (!(m_StartGame.FirstPlayer.HaveMoves == true || m_StartGame.SecondPlayer.HaveMoves == true))
            {
                m_StartGame.UpdateGameStatus();
            }
            playerColor playerColorTurn = m_StartGame.GetPlayerTurn();
            i_GameForm.ChangeTitle(playerColorTurn);
            i_GameForm.SetGameFrom();
            i_GameForm.ShowDialog();
        }
        public void Round(GameForm i_GameForm)
        {
            i_GameForm.SizeBoard = m_StartGame.BoardSize;
            i_GameForm.StartGameFrom();
            bool haveMoves = m_StartGame.HaveMoves();
            while ((!haveMoves) && (m_StartGame.FirstPlayer.HaveMoves == true || m_StartGame.SecondPlayer.HaveMoves == true))
            {
                switchPlayersTurn();
                haveMoves = m_StartGame.HaveMoves();
            }
            if (!(m_StartGame.FirstPlayer.HaveMoves == true || m_StartGame.SecondPlayer.HaveMoves == true))
            {
                m_StartGame.UpdateGameStatus();
            }
            playerColor playerColorTurn = m_StartGame.GetPlayerTurn();
            i_GameForm.ChangeTitle(playerColorTurn);
            i_GameForm.SetGameFrom();
            i_GameForm.Refresh();
        }
        public void RunGame()
        {
            SetButtonClick();
            GameForm gameForm = new GameForm(m_StartGame.Board,m_PictureBoxClick);
            FirstRound(gameForm);
            while (m_StartGame.statusGame == statusGame.Going)
            {
                Round(gameForm);
            }
            ShowStatusAfterRunning();
        }
        public void ShowStatusAfterRunning()
        {
            string outputStringData = getNextGameStatus();
            m_StartGame.InitNewGame();
            m_GameForm.EndMessge(outputStringData);
            m_GameForm.Board = m_StartGame.Board;
            m_GameForm.SetGameFrom();
            RunGame();
        }
        private void switchPlayersTurn()
        {
            if (m_StartGame.FirstPlayer.Turn)
            {
                m_StartGame.FirstPlayer.Turn = false;
                m_StartGame.SecondPlayer.Turn = true;
            }
            else
            {
                m_StartGame.SecondPlayer.Turn = false;
                m_StartGame.FirstPlayer.Turn = true;
            }
        }
        private string getNextGameStatus()
        {
            string outputStringData = null;
            Player loserPlayer;
            Player winPlayer;
            if (m_StartGame.Winner == m_StartGame.FirstPlayer)
            {
                loserPlayer = m_StartGame.SecondPlayer;
                winPlayer = m_StartGame.FirstPlayer;
            }
            else
            {
                loserPlayer = m_StartGame.FirstPlayer;
                winPlayer = m_StartGame.SecondPlayer;
            }
            switch (m_StartGame.statusGame)
            {
                case statusGame.Winning:
                    outputStringData = string.Format("{0} Won!! ({1}/{2}) ({3}/{4})\n Would you like another round ?", getColor(winPlayer), winPlayer.CoinsCount, loserPlayer.CoinsCount, winPlayer.WinCounts, loserPlayer.WinCounts);
                    break;
                case statusGame.Tie:
                    outputStringData = string.Format("It's a Tie!! ({1}/{2}) ({3}/{4})\n Would you like another round ?", getColor(winPlayer), winPlayer.CoinsCount, loserPlayer.CoinsCount, winPlayer.WinCounts, loserPlayer.WinCounts);
                    break;
            }
            return outputStringData;
        }
        private string getColor(Player i_Player)
        {
            string playerColor = null;
            if (i_Player.Color == colorType.X)
            {
                playerColor = "Yellow";
            }
            else
            {
                playerColor = "Red";
            }
            return playerColor;
        }
    }
}