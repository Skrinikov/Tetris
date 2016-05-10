using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisProject
{
    public class Score
    {

        private int lvl;
        private int lines;
        private int score;

        public int Level
        {
            get
            {
                return lvl;
            }
        }

        public int Lines
        {
            get
            {
                return lines;
            }
        }

        public int GameScore
        {
            get
            {
                return score;
            }
        }


        public Score(IBoard board)
        {
            board.LinesCleared += incrementLinesCleared;
            lvl = 1;
        }

        private void incrementLinesCleared(int num)
        {
            lines += num;
            score += num * num;
            lvl = lines / 10 + 1;
        }

    }
}
