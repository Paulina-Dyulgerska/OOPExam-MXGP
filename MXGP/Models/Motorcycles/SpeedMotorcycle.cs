using System;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        //public SpeedMotorcycle(string model, int horsePower) : base(model, horsePower, cubicCentimeters)
        //{
        //    if (horsePower < 50 || horsePower > 69)
        //    {
        //        throw new ArgumentException($"Invalid horse power: {horsePower}.");
        //    }
        //}


        private const double cubicCentimeters = 125;
        private const int minHP = 50;
        private const int maxHP = 69;
        private int horsePower;
        public SpeedMotorcycle(string model, int horsePower) : base(model, horsePower, cubicCentimeters)
        {
            this.HorsePower = horsePower;
        }
        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < minHP || value > maxHP)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                this.horsePower = value;
            }
        }
    }




    //public class SpeedMotorcycle : Motorcycle
    //{
    //    private const double cubicCentimeters = 125;

    //    public SpeedMotorcycle(string model, int horsePower) : this()
    //    {
    //        base.Model = model;
    //        base.HorsePower = horsePower;
    //        base.CubicCentimeters = cubicCentimeters;
    //    }

    //    private SpeedMotorcycle() : base()
    //    {
    //        base.MinHorsePower = 50;
    //        base.MaxHorsePower = 69;
    //    }
    //}
}
