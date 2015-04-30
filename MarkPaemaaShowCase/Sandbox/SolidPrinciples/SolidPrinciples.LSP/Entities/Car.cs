using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SolidPrinciples.LSP.Entities
{
    public class Car
    {
        private bool _hasFuel = true;

        public Car(Color color)
        {

        }

        public virtual void StartEngine()
        {
            if (!_hasFuel)
                throw new OutOfFuelException("Can't start a car without gas in tank.");
            IsEngineRunning = true;
        }

        public virtual void StopEngine()
        {
            IsEngineRunning = false;
        }

        public bool IsEngineRunning { get; private set; }
        public Color Color { get; protected set; }
    }

    public class BrokenCar : Car 
    {
        public BrokenCar(Color color) : base(color)
        {

        }

        public override void StartEngine()
        {
            throw new NotImplementedException();
        }
    }

    public class CrimeBossCar : Car 
    {
        private readonly bool _boobyTrapped;

        public CrimeBossCar(Color color, bool boobyTrap) : base(color)
        {
            _boobyTrapped = boobyTrap;
        }

        public override void StartEngine()
        {
            if (_boobyTrapped)
                throw new MeetYourMakerException("Boom! You are dead!");
            base.StartEngine();
        }

    }

    public class ElectricHoldenAstra : Car 
    { 
        public ElectricHoldenAstra(Color color) : base(color)
        {

        }
        public override void StartEngine()
        {
            // base.StartEngine();  // Electric Car so it doenst Start
        }
        public override void StopEngine()
        {
            base.StopEngine();
        }
    }

    public class StolenCar : Car 
    {
        private bool _ignitionWiresStripped;

        public StolenCar(Color color): base(color)
        {

        }

        public void StripIgnitionWires()
        {
            _ignitionWiresStripped = true;
        }

        public override void StartEngine()
        {
            if (!_ignitionWiresStripped) return;

            base.StartEngine();
        }
    }


    public class PimpedOutCar : Car
    {
        private readonly Color _color;

        public PimpedOutCar(Color color)
            : base(color)
        {

        }

        public void SetTemperature(int temp)
        {
            if (temp > 20)  // One of those fancy new paint jobs that changes color based on temperature - make cars more visible in snow.
                Color = _color;
            else
                Color = Color.Black;
        }
    }

}
