using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisProject;

namespace TetrisUnitTest
{
    [TestClass]
    public class ScoreTest
    {
        [TestMethod]
        public void ScoreLevelTest()
        {
            IBoard board = new Board();
            Score sc = new Score(board);

            int lvl = sc.Level;

            Assert.AreEqual(lvl, 1);

        }

        [TestMethod]
        public void ScoreLinesTest()
        {
            IBoard board = new Board();
            Score sc = new Score(board);

            int lines = sc.Lines;

            Assert.AreEqual(lines, 0);
        }

        [TestMethod]
        public void ScoreGameScoreTest()
        {
            IBoard board = new Board();
            Score sc = new Score(board);

            int gameScore = sc.GameScore;

            Assert.AreEqual(gameScore, 0);
        }
    }
}
