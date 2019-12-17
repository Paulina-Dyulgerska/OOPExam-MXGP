using MXGP.Models.Motorcycles.Contracts;
using System;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        private string model;

        public Motorcycle(string model, int horsePower, double cubicCentimeters)
        {

            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }
                this.model = value;
            }
        }

        public virtual int HorsePower { get; protected set; }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / (this.HorsePower * laps);
        }
    }


    //public abstract class Motorcycle : IMotorcycle
    //{
    //    private string model;
    //    private int horsePower;

    //    protected Motorcycle()
    //    {
    //    }

    //    public Motorcycle(string model, int horsePower, double cubicCentimeters) : this()
    //    {

    //        this.Model = model;
    //        this.HorsePower = horsePower;
    //        this.CubicCentimeters = cubicCentimeters;
    //    }

    //    public string Model
    //    {
    //        get => this.model;
    //        protected set
    //        {
    //            if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
    //            {
    //                throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
    //            }
    //            this.model = value;
    //        }
    //    }

    //    protected int MinHorsePower { get; set; }

    //    protected int MaxHorsePower { get; set; }

    //    public int HorsePower
    //    {
    //        get => this.horsePower;
    //        protected set
    //        {
    //            if (value < this.MinHorsePower || value > this.MaxHorsePower)
    //            {
    //                throw new ArgumentException($"Invalid horse power: {value}.");
    //            }
    //            this.horsePower = value;
    //        }
    //    }

    //    public double CubicCentimeters { get; protected set; }

    //    public double CalculateRacePoints(int laps)
    //    {
    //        return this.CubicCentimeters / (this.HorsePower * laps);
    //    }
    //}

}
