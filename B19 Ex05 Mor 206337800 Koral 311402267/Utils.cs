namespace Utils
{
    static class Constants
    {
        public const string k_ComputerRival = "2";
        public const string k_ManualRival = "1";
        public const string k_ComputerName = "computer";
        public const string k_ResumeGame = "1";
        public const string k_FinishGame = "2";
        public const string k_QuittingTheGame = "Q";
        public const int k_MinBoardSize = 6;
        public const int k_MaxBoardSize = 8;
        public const int k_MinSquere = 0;
        public const int k_LegalLenInput = 2;
    }
    public enum playerType
    {
        Manual, Computer
    }
    public enum colorType
    {
        nan, X, O , G
    }
    public enum statusGame
    {
        Going, Winning, Quit, Tie
    }
    public enum direction
    {
        Up, Down, Left, Right
    }
    public enum playerColor
    {
        black, white
    }
}