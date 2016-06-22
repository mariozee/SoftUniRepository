namespace MinesweeperGame
{
    public class Stats
    {
        private string playerName;

        private int playerPoints;

        public string PlayerName
        {
            get
            {
                return playerName;
            }

            set
            {
                playerName = value;
            }
        }

        public int PlayerPoints
        {
            get
            {
                return playerPoints;
            }

            set
            {
                playerPoints = value;
            }
        }

        public Stats()
        {
        }

        public Stats(string playerName, int playerPoints)
        {
            this.PlayerName = playerName;
            this.PlayerPoints = playerPoints;
        }
    }
}
