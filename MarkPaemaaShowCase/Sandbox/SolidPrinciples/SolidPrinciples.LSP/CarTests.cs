using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolidPrinciples.LSP.Entities;
using System.Drawing;

namespace SolidPrinciples.LSP
{
    [TestClass]
    public class CarTests
    {
        // Covariance of method arguments is not possible in C#
        // Contravariance of method return values is not possible in C#

        [TestMethod]
        public void Make_sure_car_can_start()
        {
            //var car = new Car(Color.Red);
            // var car = new BrokenCar(Color.Red);  // Postconditions weakened
             var car = new CrimeBossCar(Color.Black, true); // Throws new type of exceptions

            try
            {
                car.StartEngine();
            }
            catch (OutOfFuelException)
            {
                Assert.Fail("Car had no gas.");
            }
            Assert.IsTrue(car.IsEngineRunning);
        }

        [TestMethod]
        public void Make_sure_engine_is_running_after_start()
        {
             var car = new Car(Color.Red);
            // var car = new ElectricHoldenAstra(Color.Red);  // Changing invariants
            // var car = new StolenCar(Color.Red);    // Changing preconditions

            car.StartEngine();

            Assert.IsTrue(car.IsEngineRunning);
        }

        [TestMethod]
        public void Make_sure_car_is_painted_correctly()
        {
            //var car = new Car(Color.Red);
            var car = new PimpedOutCar(Color.Red); // Violating history contraint
            car.SetTemperature(10);

            Assert.AreEqual(Color.Red, car.Color);
        }

    }
}
