using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moving_pacman_object;
using System.Drawing;

namespace UnitTestProject1
{
    [TestClass]
    public class PelletTests
    {
        [TestMethod]
        public void Can_Generate_Pellets()
        {
            Pellet pellet = new Pellet { };

            pellet.GeneratePellets();

            int pelletsSum = 241;
            int superPelletsSum = 4;

            Assert.AreEqual(pellet.Pellets.Count, pelletsSum);
            Assert.AreEqual(pellet.SuperPellets.Count, superPelletsSum);

        }

        [TestMethod]
        public void Can_Remove_Pellets()
        {
            Pellet pellet = new Pellet { };
            pellet.GeneratePellets();

            Point point = new Point(23, 48);

            pellet.RemovePellet(point);

            Assert.AreEqual(pellet.SuperPellets.Count, 3);
        }
    }
}
