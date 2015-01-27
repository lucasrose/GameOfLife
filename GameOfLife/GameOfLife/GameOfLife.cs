using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameOfLife
    {
        public static Int32 AliveCell = 1;
        public static Int32 DeadCell = 0;
        Int32[,] grid;
        Int32 lengthOfGrid;
        Int32 heightOfGrid;


        public GameOfLife(Int32 lengthOfGrid, Int32 heightOfGrid)
        {
            grid = new Int32 [lengthOfGrid, heightOfGrid];
            this.lengthOfGrid = lengthOfGrid;
            this.heightOfGrid = heightOfGrid;

            SetupDeadCells(lengthOfGrid, heightOfGrid);
            SetupLiveCells(lengthOfGrid, heightOfGrid);
        }

        private void SetupLiveCells(Int32 lengthOfGrid, Int32 heightOfGrid)
        {
            var midX = lengthOfGrid / 2;
            var midY = heightOfGrid / 2;
            grid[midX, midY] = AliveCell;
            grid[midX, midY - 1] = AliveCell;
            grid[midX + 1, midY] = AliveCell;
            grid[midX + 1, midY + 1] = AliveCell;
        }

        private void SetupDeadCells(Int32 lengthOfGrid, Int32 heightOfGrid)
        {

            for (var cellX = 0; cellX < lengthOfGrid; cellX++)
                for (var cellY = 0; cellY < lengthOfGrid; cellY++)
                    grid[cellX, cellY] = DeadCell;
               
        }

        public String GetCellValue(Int32 locationX, Int32 locationY)
        {
            if (grid[locationX, locationY] == 1)
                return "Alive";
            return "Dead";
        }

        private void KillCellWithLessThanTwoLiveNeighbors()
        {
            
        }

        private void SaveCellWithTwoOrThreeLiveNeighbors()
        {

        }

        private void KillCellWithMoreThanThreeNeighbors()
        {

        }

        private void SaveDeadCellWithThreeLiveNeighbors()
        {

        }
    }
}
