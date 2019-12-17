using MXGP.Models.Races.Contracts;
using System.Linq;

namespace MXGP.Repositories
{
    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
            //return this.models.Find(x => x.Model == name);
        }
    }
}
