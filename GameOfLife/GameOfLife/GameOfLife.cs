using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameOfLife
    {
        public static Int32 LivingCell = 1;
        public static Int32 DeadCell = 0;
        private Int32[,] ecosystem;
        private Int32 lengthOfecosystem;
        private Int32 heightOfecosystem;
        private Int32 midX;
        private Int32 midY;

        private Stopwatch timer;

        public GameOfLife(Int32 lengthOfecosystem, Int32 heightOfecosystem)
        {
            ecosystem = new Int32[lengthOfecosystem, heightOfecosystem];
            this.lengthOfecosystem = lengthOfecosystem;
            this.heightOfecosystem = heightOfecosystem;
            midX = lengthOfecosystem / 2;
            midY = heightOfecosystem / 2;

            SetupDeadCells();
            SetupLiveCells();
            timer = new Stopwatch();
        }
        public void runEcosystem()
        {
            timer.Start();
            while (timer.Elapsed < TimeSpan.FromSeconds(30000))
            {
                ChangeEcosystem(midX, midY);
            }
            timer.Stop();
        }
        private void ChangeEcosystem(Int32 X, Int32 Y)
        {
            SaveOrKillCell(X, Y);
            if (X < midX + 20)
                ChangeEcosystem(X + 1, Y);
            if (X > midX - 20)
                ChangeEcosystem(X - 1, Y);
            if (Y < midY + 20)
                ChangeEcosystem(X, Y + 1);
            if (Y > midY - 20)
                ChangeEcosystem(X, Y - 1);
        }

        private void SetupLiveCells()
        {

            ecosystem[midX, midY] = LivingCell;
            ecosystem[midX, midY - 1] = LivingCell;
            ecosystem[midX + 1, midY] = LivingCell;
        }

        private void SetupDeadCells()
        {

            for (var cellX = 0; cellX < lengthOfecosystem; cellX++)
                for (var cellY = 0; cellY < lengthOfecosystem; cellY++)
                    ecosystem[cellX, cellY] = DeadCell;

        }

        private Int32 GetCellValue(Int32 locationX, Int32 locationY)
        {
            return ecosystem[locationX, locationY];
        }

        public String GetCellStringValue(Int32 locationX, Int32 locationY)
        {
            var value = GetCellValue(locationX, locationY);
            if (value == LivingCell)
                return "Alive";
            return "Dead";
        }

        private Int32 GetTheNumberOfCellsAliveAroundCurrentCell(Int32 X, Int32 Y)
        {
            var count = 0;
            if (GetCellValue(X - 1, Y + 1) == LivingCell)
                count++;
            if (GetCellValue(X - 1, Y) == LivingCell)
                count++;
            if (GetCellValue(X - 1, Y - 1) == LivingCell)
                count++;
            if (GetCellValue(X, Y - 1) == LivingCell)
                count++;
            if (GetCellValue(X + 1, Y - 1) == LivingCell)
                count++;
            if (GetCellValue(X + 1, Y) == LivingCell)
                count++;
            if (GetCellValue(X + 1, Y + 1) == LivingCell)
                count++;
            if (GetCellValue(X, Y + 1) == LivingCell)
                count++;

            return count;

        }

        private void SaveOrKillCell(Int32 X, Int32 Y)
        {
            var AliveCells = GetTheNumberOfCellsAliveAroundCurrentCell(X, Y);
            if (ecosystem[X, Y] == LivingCell)
            {
                if (AliveCells < 2)
                    setDead(X, Y);
                else if (AliveCells <= 3)
                    setAlive(X, Y);
                else if (AliveCells > 3)
                    setDead(X, Y);
            }
            else if (ecosystem[X, Y] == DeadCell && AliveCells == 3)
                setAlive(X, Y);
        }

        private void setAlive(Int32 X, Int32 Y)
        {
            ecosystem[X, Y] = LivingCell;
        }

        private void setDead(Int32 X, Int32 Y)
        {
            ecosystem[X, Y] = DeadCell;
        }
    }
}
