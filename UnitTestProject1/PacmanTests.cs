using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moving_pacman_object;
using System.Web.Mvc;
using System.Drawing;
using System.Collections.Generic;



namespace UnitTestProject1
{
    [TestClass]
    public class PacmanTests
    {
        [TestMethod]
        public void Can_Check_My_Weight()
        {
            TESTforUnitTest target = new TESTforUnitTest { Name = "Vardas", Weight = 115 };

            int result = target.Weightx2();

            Assert.AreEqual(result, 230);
        }

       

         [TestMethod]
        public void Can_Pacman_Move()
         {
             Pacman pacman = new Pacman();
             pacman.CurrentDirection = Direction.Right;
             pacman.ImageCurrentLocation = new Point(9, 10);

             Point point = new Point(10, 10);
             List<Point> _pathPoints = new List<Point>();
             _pathPoints.Add(point);

             Assert.IsTrue(pacman.CanMove( pacman.ImageCurrentLocation, pacman.CurrentDirection, _pathPoints));
             
         }

         [TestMethod]
        public void Move_Pacman()
         {
             Pacman pacman = new Pacman();
             pacman.CurrentDirection = Direction.Right;
             pacman.ImageCurrentLocation = new Point(9, 10);

             pacman.Move(Direction.Right);

             Assert.AreEqual(pacman.ImageCurrentLocation, new Point(10, 10));
         }

       

    }
}
