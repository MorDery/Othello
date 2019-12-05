using System;
using System.Collections.Generic;
using Utils;

namespace Ex05_Othelo
{
    public class Board
    {
        protected int m_Size;
        protected Dictionary<int, int> m_StartSteps = new Dictionary<int, int>();
        protected colorType[,] m_MatrixBoard = null;

        public Board(int i_Size)
        {
            m_Size = i_Size;
            m_MatrixBoard = new colorType[m_Size, m_Size];
            initBegginingBoard();
        }
       
        private void initBegginingBoard()
        {
            int firstValueIndex = (m_Size / 2) - 1;
            m_MatrixBoard[firstValueIndex, firstValueIndex] = colorType.O;
            m_MatrixBoard[firstValueIndex + 1, firstValueIndex + 1] = colorType.O;
            m_MatrixBoard[firstValueIndex, firstValueIndex + 1] = colorType.X;
            m_MatrixBoard[firstValueIndex + 1, firstValueIndex] = colorType.X;
           
        }
        public colorType[,] MatrixBoard
        {
            get
            {
                return m_MatrixBoard;
            }
        }
        public int Size
        {
            get
            {
                return m_Size;
            }
        }
        public colorType GetSquereDate(int i_row, int i_column)
        {
            return m_MatrixBoard[i_row, i_column];
        }
        public bool CheckIfInLimitBoard(int i_row, int i_column)
        {
            return ((i_row <= (m_Size - 1)) && (i_column <= (m_Size - 1)) && (i_row >= Utils.Constants.k_MinSquere) && (i_column >= Utils.Constants.k_MinSquere));
        }
        public void SetBoard(Player i_Player, Player i_PlayerRival)
        {
            int indexOfColumnStep, endLoop;
            colorType color = i_Player.Color;
            int columnStep = i_Player.ColumnStep;
            int rowStep = i_Player.RowStep;
            foreach(KeyValuePair<int, int> entry in m_StartSteps)
            {
                int i_ColumnStepStart = entry.Key;
                int i_RowStepStart = entry.Value;
                if(rowStep == i_RowStepStart)
                {
                    if(columnStep < i_ColumnStepStart)
                    {
                        endLoop = i_ColumnStepStart;
                        i_Player.CoinsCount += i_ColumnStepStart - columnStep;
                        i_PlayerRival.CoinsCount -= i_ColumnStepStart - columnStep - 1;
                        indexOfColumnStep = columnStep++;
                    }
                    else
                    {
                        endLoop = columnStep;
                        i_Player.CoinsCount += columnStep - i_ColumnStepStart;
                        i_PlayerRival.CoinsCount -= columnStep - i_ColumnStepStart - 1;
                        indexOfColumnStep = i_ColumnStepStart++;
                    }
                    while(indexOfColumnStep <= endLoop)
                    {
                        m_MatrixBoard[rowStep, indexOfColumnStep] = color;
                        indexOfColumnStep++;
                    }
                }
                else
                {
                    if(rowStep < i_RowStepStart)
                    {
                        endLoop = i_RowStepStart;
                        i_Player.CoinsCount += i_RowStepStart - rowStep;
                        i_PlayerRival.CoinsCount -= i_RowStepStart - rowStep - 1;
                        indexOfColumnStep = rowStep++;
                    }
                    else
                    {
                        endLoop = rowStep;
                        i_Player.CoinsCount += rowStep - i_RowStepStart;
                        i_PlayerRival.CoinsCount -= rowStep - i_RowStepStart - 1;
                        indexOfColumnStep = i_RowStepStart++;
                    }
                    while(indexOfColumnStep <= endLoop)
                    {
                        m_MatrixBoard[indexOfColumnStep, columnStep] = color;
                        indexOfColumnStep++;
                    }
                }
            }
        }
        private int[] playerBoard(Player i_Player)
        {
            List<int> playerBoard = new List<int>();
            int indexBoard = 0;
            foreach(colorType cell in m_MatrixBoard)
            {
                if(cell == i_Player.Color)
                {
                    playerBoard.Add(indexBoard);
                }
                indexBoard++;
            }
            return playerBoard.ToArray();
        }
        public bool PlayerMovesOnBoard(Player i_Player)
        {
            int row = 0;
            int column = 0;
            int[] playerBoard = this.playerBoard(i_Player);
            bool checkMove = false;
            bool haveMoves = false;
            colorType color;

            if(i_Player.Color == colorType.O)
            {
                color = colorType.X;
            }
            else
            {
                color = colorType.O;
            }
            foreach(int index in playerBoard)
            {
                row = index / m_Size;
                column = index % m_Size;
                checkMove = checkMovePlayer(row, column, color);
                if(checkMove)
                {
                    haveMoves = true;
                }
                
            }
            return haveMoves;
        }
        private bool checkMovePlayer(int i_Row, int i_Column, colorType i_ColorRival)
        {
            bool haveMoves = false;
            bool checkMove = false;
            List<direction> directions = new List<direction>();
            getSearchingDirections(directions, i_Row, i_Column, m_Size, i_ColorRival);
            foreach(direction index in directions)
            {
                if(index == direction.Up)
                {
                    checkMove = checkColumn(i_Row - 1, 0, i_Column, i_ColorRival);
                    if (checkMove)
                    {
                        
                        haveMoves = true;
                    }
                }
                else if(index == direction.Down)
                {
                    checkMove = checkColumn(i_Row + 1, m_Size, i_Column , i_ColorRival);
                    if (checkMove)
                    {
                        
                        haveMoves = true;
                    }
                }
                else if(index == direction.Right)
                {
                    checkMove = checkRow(i_Row, i_Column + 1,m_Size , i_ColorRival);
                    if (checkMove)
                    {
                        
                        haveMoves = true;
                    }
                }
                else
                {
                    checkMove = checkRow(i_Row, i_Column - 1 ,0 , i_ColorRival);
                    if (checkMove)
                    {
                       
                        haveMoves = true;
                    }
                }
            }
            return haveMoves;
        }
        private bool checkRow(int i_Row, int i_ColumnStart, int i_ColumnEnd, colorType i_ColorRival)
        {
            int startLoop = i_ColumnStart;
            bool haveMove = false;
            if(i_ColumnStart > i_ColumnEnd)
            {
                while(startLoop >= i_ColumnEnd && !haveMove)
                {
                    if(m_MatrixBoard[i_Row, startLoop] == i_ColorRival)
                    {
                        startLoop--;
                    }
                    else if(m_MatrixBoard[i_Row, startLoop] == colorType.nan)
                    {
                        haveMove = true;
                        m_MatrixBoard[i_Row, startLoop] = colorType.G;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                while(startLoop < i_ColumnEnd && !haveMove)
                {
                    if(m_MatrixBoard[i_Row, startLoop] == i_ColorRival)
                    {
                        startLoop++;
                    }
                    else if(m_MatrixBoard[i_Row, startLoop] == colorType.nan)
                    {
                        haveMove = true;
                        m_MatrixBoard[i_Row, startLoop] = colorType.G;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return haveMove;
        }
        private bool checkColumn(int i_RowStart, int i_RowEnd, int i_Column, colorType i_ColorRival)
        {
            int startLoop = i_RowStart;
            bool haveMove = false;
            if(i_RowStart > i_RowEnd)
            {
                while(startLoop >= i_RowEnd && !haveMove)
                {
                    if(m_MatrixBoard[startLoop, i_Column] == i_ColorRival)
                    {
                        startLoop--;
                    }
                    else if(m_MatrixBoard[startLoop, i_Column] == colorType.nan)
                    {
                        haveMove = true;
                        m_MatrixBoard[startLoop, i_Column] = colorType.G;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                while(startLoop < i_RowEnd && !haveMove)
                {
                    if(m_MatrixBoard[startLoop, i_Column] == i_ColorRival)
                    {
                        startLoop++;
                    }
                    else if(m_MatrixBoard[startLoop, i_Column] == colorType.nan)
                    {
                        haveMove = true;
                        m_MatrixBoard[startLoop, i_Column] = colorType.G;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return haveMove;
        }
        public bool CheckLegalSquer(Player i_Player)
        {
            bool checkLegalSquer = (checkLegalSizeSquer(i_Player) && checkLegalLogicalSquer(i_Player));
            return checkLegalSquer;
        }
        private bool checkLegalSizeSquer(Player i_Player)
        {
            int boardSize = m_Size;
            int width = i_Player.RowStep;
            int length = i_Player.ColumnStep;
            return ((width <= boardSize && width >= Utils.Constants.k_MinSquere) && (length <= boardSize && length >= Utils.Constants.k_MinSquere));
        }
        private bool checkLegalLogicalSquer(Player i_Player)
        {
            m_StartSteps = new Dictionary<int, int>();
            bool findData = false;
            int row = i_Player.RowStep;
            int column = i_Player.ColumnStep;
            int boardSize = m_Size;
            colorType rivalColor = colorType.O;
            colorType chosenSquer = GetSquereDate(row, column);
            if(chosenSquer != colorType.G)
            {
                return false;
            }
            if(i_Player.Color == colorType.O)
            {
                rivalColor = colorType.X;
            }
            List<direction> directions = new List<direction>();
            getSearchingDirections(directions, row, column, boardSize, rivalColor);
            foreach(direction direction in directions)
            {
                row = i_Player.RowStep;
                column = i_Player.ColumnStep;
                movingOnBoardBasedDirection(direction, ref row, ref column);
                while((CheckIfInLimitBoard(row, column) && (GetSquereDate(row, column) == rivalColor)))
                {
                    movingOnBoardBasedDirection(direction, ref row, ref column);
                }
                if((CheckIfInLimitBoard(row, column)) && (GetSquereDate(row, column) == i_Player.Color)) // finding the relevant squere
                {
                    m_StartSteps.Add(column, row);
                    findData = true;
                }
            }
            return findData;
        }
        private void movingOnBoardBasedDirection(direction i_Direction, ref int io_Row, ref int io_Column)
        {
            switch (i_Direction)
            {
                case direction.Down:
                    io_Row++;
                    break;
                case direction.Up:
                    io_Row--;
                    break;
                case direction.Left:
                    io_Column--;
                    break;
                case direction.Right:
                    io_Column++;
                    break;
            }
        }
        private void getSearchingDirections(List<direction> i_Directions, int i_Row, int i_Column, int i_BoardSize, colorType i_ColorRival)
        {
            if(i_Row != Utils.Constants.k_MinSquere && GetSquereDate(i_Row - 1, i_Column) == i_ColorRival)
            {
                i_Directions.Add(direction.Up);
            }
            if(i_Row != (i_BoardSize - 1) && GetSquereDate(i_Row + 1, i_Column) == i_ColorRival)
            {
                i_Directions.Add(direction.Down);
            }
            if(i_Column != Utils.Constants.k_MinSquere && GetSquereDate(i_Row, i_Column - 1) == i_ColorRival)
            {
                i_Directions.Add(direction.Left);
            }
            if(i_Column != (i_BoardSize - 1) && GetSquereDate(i_Row, i_Column + 1) == i_ColorRival)
            {
                i_Directions.Add(direction.Right);
            }
        }
    }
}