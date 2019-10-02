namespace Lab4_DungeonCrawler
{
    internal class Player
    {
        public Player()
        {
        }

        public static void MovePlayer(char[,] mapArray, int y, int x)
        {
            int rowIndex = 0;
            int columnIndex = 0;
            for (int i = 0; i < mapArray.GetLength(0); i++)
            {
                for (int j = 0; j < mapArray.GetLength(1); j++)
                {
                    if (mapArray[i, j].Equals('@'))
                    {
                        rowIndex = i;
                        columnIndex = j;
                        break;
                    }
                }
            }

            if(mapArray[rowIndex + y, columnIndex + x] != '#')
            {
                mapArray[rowIndex, columnIndex] = '-';
                mapArray[rowIndex + y, columnIndex + x] = '@';
            }
        }
    }
}