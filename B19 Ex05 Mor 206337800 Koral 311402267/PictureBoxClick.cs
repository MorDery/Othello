using Utils;

namespace Ex05_Othelo
{
    public class PictureBoxClick
    {
        GameUI m_GameUI = new GameUI();
        Game m_Game;
        GameControl m_GameControl;
        public PictureBoxClick(GameControl i_GameControl)
        {
            m_GameControl = i_GameControl;
            m_Game = i_GameControl.StartGame;
        }
        public void Round(GameForm i_GameForm)
        {
            m_Game.StartTurns(i_GameForm.ColumnClicked, i_GameForm.RowClicked, m_GameUI.QuittingTheGame, true);
            i_GameForm.Board = m_Game.Board;
            i_GameForm.SetGameFrom();
            i_GameForm.Refresh();
            bool haveMoves = m_Game.HaveMoves();
            while ((!haveMoves) && (m_Game.FirstPlayer.HaveMoves == true || m_Game.SecondPlayer.HaveMoves == true))
            {
                switchPlayersTurn();
                haveMoves = m_Game.HaveMoves();
            }
            if (!(m_Game.FirstPlayer.HaveMoves == true || m_Game.SecondPlayer.HaveMoves == true))
            {
                m_GameControl.StartGame.UpdateGameStatus();
                m_GameControl.ShowStatusAfterRunning();
                i_GameForm.Close();
                
            }
            playerColor playerColorTurn = m_Game.GetPlayerTurn();
            i_GameForm.ChangeTitle(playerColorTurn);
            i_GameForm.SetGameFrom();
            i_GameForm.Refresh();
            if (m_Game.SecondPlayer.Turn && m_Game.SecondPlayer.Type == playerType.Computer)
            {
                Round(i_GameForm);
            }
        }
        private void switchPlayersTurn()
        {
            if (m_Game.FirstPlayer.Turn)
            {
                m_Game.FirstPlayer.Turn = false;
                m_Game.SecondPlayer.Turn = true;
            }
            else
            {
                m_Game.SecondPlayer.Turn = false;
                m_Game.FirstPlayer.Turn = true;
            }
        }
    }
}