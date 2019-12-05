using System;
using System.Collections.Generic;
using Utils;
namespace Ex05_Othelo
{
    public class Player
    {
        bool m_HaveMoves = true;
        string m_Name;
        playerType m_Type;
        colorType m_Color;
        bool m_CurrentTurn;
        int m_RowStep = 0;
        int m_ColumnStep = 0;
        int m_CoinsCount = 2;
        int m_WinCounts = 0;
        Random m_Rnd = new Random();

        public bool HaveMoves
        {
            get { return m_HaveMoves; }
            set { m_HaveMoves = value; }
        }
        public int WinCounts
        {
            get { return m_WinCounts; }
            set { m_WinCounts = value; }
        }
        public bool Turn
        {
            get
            { return m_CurrentTurn;}
            set
            { m_CurrentTurn = value;}
        }
        public string Name
        {
            get
            { return m_Name;}
        }
        public colorType Color
        {
            get
            { return m_Color;}
        }
        public int RowStep
        {
            get
            { return m_RowStep; }
        }
        public int ColumnStep
        {
            get
            { return m_ColumnStep;}
        }
        public int CoinsCount
        {
            get
            { return m_CoinsCount;}
            set
            { m_CoinsCount = value;}
        }
        public playerType Type
        {
            get
            { return m_Type; }
        }
        public Player(string i_Name, playerType i_Type, colorType i_Color, bool i_CurrentTurn)
        {
            m_CurrentTurn = i_CurrentTurn;
            m_Name = i_Name;
            m_Type = i_Type;
            m_Color = i_Color;
        }
        public void GetStep(int i_BoardSize, int i_ColumnStep, int i_RowStep, colorType[,] i_BoardMatrix)
        {
            if (m_Type == playerType.Computer)
            {
                getComputerStep(i_BoardSize, i_BoardMatrix);
            }
            else
            {
                getManualStep(i_ColumnStep, i_RowStep);
            }
        }
        private void getManualStep(int i_ColumnStep, int i_RowStep)
        {
            m_ColumnStep = i_ColumnStep;
            m_RowStep = i_RowStep;
        }
        private void getComputerStep(int i_BoardSize, colorType[,] i_BoardMatrix)
        {
            List<int> possibilities = new List<int>();
            int cellIndex = 0;
            foreach (colorType cell in i_BoardMatrix)
            {
                if (cell == colorType.G)
                {
                    possibilities.Add(cellIndex);
                }
                cellIndex++;
            }
            int chosen = m_Rnd.Next(0, possibilities.Count);
            chosen = possibilities[chosen];
            m_ColumnStep = chosen % i_BoardSize;
            m_RowStep = chosen / i_BoardSize;
        }
    }
}
