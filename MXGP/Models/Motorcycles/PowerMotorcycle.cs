using System;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {

        //public PowerMotorcycle(string model, int horsePower) : base(model, horsePower, cubicCentimeters)
        //{
        //    if (horsePower < 70 || horsePower > 100)
        //    {
        //        throw new ArgumentException($"Invalid horse power: {horsePower}.");
        //    }
        //}

        private const double cubicCentimeters = 450;
        private const int minHP = 70;
        private const int maxHP = 100;
        private int horsePower;
        public PowerMotorcycle(string model, int horsePower) : base(model, horsePower, cubicCentimeters)
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



    //public class PowerMotorcycle : Motorcycle
    //{
    //    private const double cubicCentimeters = 450;
    //    private int horsePower;
    //    private const int minHP = 70;
    //    private const int maxHP = 100;

    //    public PowerMotorcycle(string model, int horsePower) : this()
    //    {
    //        base.Model = model;
    //        base.HorsePower = horsePower;
    //        base.CubicCentimeters = cubicCentimeters;
    //    }

    //    private PowerMotorcycle() : base()
    //    {
    //        base.MinHorsePower = 70;
    //        base.MaxHorsePower = 100;
    //    }
    //}
}
