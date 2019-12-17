using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IRider> riders;
        private readonly IRepository<IRace> races;
        private readonly IRepository<IMotorcycle> motorcycles;

        public ChampionshipController()
        {
            this.riders = new RiderRepository();
            this.races = new RaceRepository();
            this.motorcycles = new MotorcycleRepository();
        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riders.GetByName(riderName);
            var motorcycle = this.motorcycles.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motorcycle);

            return $"Rider {riderName} received motorcycle {motorcycleModel}.";

        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var rider = this.riders.GetByName(riderName);
            var race = this.races.GetByName(raceName);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            race.AddRider(rider);

            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.motorcycles.GetAll().Any(x => x.Model == model))
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }

            IMotorcycle motorcycle = null;

            switch (type)
            {
                case "Speed":
                    motorcycle = new SpeedMotorcycle(model, horsePower);
                    break;
                case "Power":
                    motorcycle = new PowerMotorcycle(model, horsePower);
                    break;
            }

            this.motorcycles.Add(motorcycle);

            return $"{type}Motorcycle {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetAll().Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            this.races.Add(new Race(name, laps));

            return $"Race {name} is created.";
        }

        public string CreateRider(string riderName)
        {
            if (this.riders.GetAll().Any(x => x.Name == riderName))
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }

            IRider rider = new Rider(riderName);

            this.riders.Add(rider);

            return $"Rider {riderName} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            List<IRider> riders = race.Riders.ToList();

            var winners = riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)).Take(3).ToList();

            var first = winners[0];
            var second = winners[1];
            var third = winners[2];

            var str = new StringBuilder();
            str.AppendLine($"Rider {first.Name} wins {race.Name} race.");
            str.AppendLine($"Rider {second.Name} is second in {race.Name} race.");
            str.AppendLine($"Rider {third.Name} is third in {race.Name} race.");

            this.races.Remove(race);

            return str.ToString().TrimEnd();
        }
    }
}
