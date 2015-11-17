using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moving_pacman_object;
using System.Web.Mvc;
using System.Drawing;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class GameLevelTests
    {
        [TestMethod]
        public void Can_Load_Next_Level()
        {
            GameLevel gameLevel = new GameLevel();


            int expectedValue = 2;

            gameLevel.LoadNextLevel();

            Assert.AreEqual(gameLevel.Level, expectedValue);

        }

        [TestMethod]

        public void Can_Increase_Level()
        {
            GameLevel gameLevel = new GameLevel();
            GameLogic gameLogic = new GameLogic();
            Enemy enemy = new Enemy(); 



            bool value = gameLevel.IncreaseLevel(gameLogic);

            Assert.AreEqual(value, false);
        }
    }
}
