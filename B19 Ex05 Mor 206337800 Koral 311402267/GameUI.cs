using System;
using Utils;


namespace Ex05_Othelo
{
    public class GameUI
    {
        int m_ColumnStep = 0;
        int m_RowStep = 0;
        bool m_QuittingTheGame = false;

        public void GetInput()
        {
            Console.WriteLine("plase select squer ");
            string squer = Console.ReadLine();
            if (squer.Length == 1 && squer == "Q")
            {
                m_QuittingTheGame = true;
            }
            else
            {
                m_ColumnStep = squer[0] - 'A' - 1;
                m_RowStep = squer[1] - 'A' - 1;
            }
        }
        public int ColumnStep
        {
            get { return m_ColumnStep; }
        }
        public int RowStep
        {
            get { return m_RowStep; }
        }
        public bool QuittingTheGame
        {
            get { return m_QuittingTheGame; }
        }
        public static string GetPlayerName(bool i_SecondPlayer)
        {
            if (i_SecondPlayer)
            {
                Console.Write("Hello Second player ");
            }
            Console.WriteLine("Please enter your first name and press enter");
            return Console.ReadLine();
        }
        public static string GetRivalType()
        {
            Console.WriteLine("Pleas press 1 for manual player or press 2 for computer player and press enter");
            return Console.ReadLine();
        }
        public static void MessageOfWrongInput()
        {
            Console.WriteLine("your input is illegal please try again");
        }
        public static string ChooseBoardSize()
        {
            Console.WriteLine("Pleas press 6 or 8 for the board size and press enter");
            return Console.ReadLine();
        }
        public static void ShowPlayersColors(string i_FistPlayerName, colorType i_FirstPlayerColor, string i_SecondPlayerName, colorType i_SecondPlayerColor)
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("{0} you play with: {1}", i_FistPlayerName, i_FirstPlayerColor));
            Console.WriteLine(String.Format("{0} you play with: {1}", i_SecondPlayerName, i_SecondPlayerColor));
        }
        public static void MessageNoMoreOptions(string i_RivalName)
        {
            Console.WriteLine(string.Format("{0} - you have no more options to play", i_RivalName));
        }
        public static void MessageShowCoinsStatus(string i_WinnerName, int i_WinnerCount, string i_LosserName, int i_LosserCount)
        {
            Console.WriteLine(String.Format("{0} your coins is: {1}", i_WinnerName, i_WinnerCount));
            Console.WriteLine(String.Format("{0} your coins is: {1}", i_LosserName, i_LosserCount));
        }
        public static void MessageWinning(string i_WinnerName)
        {
            Console.WriteLine(String.Format("{0} you are the winner!", i_WinnerName));
        }
        public static void MessageTie()
        {
            Console.WriteLine("It is a tie");
        }
        public static string CheckResumeGame()
        {
            Console.WriteLine("To play again press 1 to exit press 2 after please press enter");
            return Console.ReadLine();
        }
        public static void FinishGame()
        {
            System.Environment.Exit(-1);
        }
        public static void ShowPlayerHisTurn(string i_PlayerName, bool i_ShowMessageNoMoreOptions, string i_RivalName)
        {
            if (i_ShowMessageNoMoreOptions)
            {
                MessageNoMoreOptions(i_RivalName);
            }
            Console.WriteLine(string.Format("Hello {0} it is your turn: ", i_PlayerName));
        }
        private static void printBoardHeaders(int i_BoardSize)
        {
            if (i_BoardSize == 8)
            {
                Console.Write("    A   B   C   D   E   F   G   H ");
            }
            else
            {
                Console.Write("    A   B   C   D   E   F ");
            }
        }
        private static void printBoardSpaces(int i_BoardSize)
        {
            if (i_BoardSize == 8)
            {
                Console.WriteLine("  =================================");
            }
            else
            {
                Console.WriteLine("  ========================");
            }
        }
    }
}