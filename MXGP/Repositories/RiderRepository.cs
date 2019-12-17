using MXGP.Models.Riders.Contracts;
using System.Linq;

namespace MXGP.Repositories
{
    public class RiderRepository : Repository<IRider>
    {
        public override IRider GetByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
            //return this.models.Find(x => x.Model == name);
        }
    }
}
