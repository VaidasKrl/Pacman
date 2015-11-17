using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moving_pacman_object;
using System.Drawing;

namespace UnitTestProject1
{
    [TestClass]
    public class EnemyTests
    {
        [TestMethod]
        public void Can_Get_Random_Direction()
        {
            Enemy enemy = new Enemy();
            enemy.DirectionList.Add(Direction.Right);

            var direction = enemy.GetRandomDirection();

            Assert.AreEqual(Direction.Right, direction);


        }
    }
}
