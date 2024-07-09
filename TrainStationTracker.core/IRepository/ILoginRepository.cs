using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationTracker.core.Data;
using TrainStationTracker.core.DTO;

namespace TrainStationTracker.core.IRepository
{
    public interface ILoginRepository
    {
        UserLogin User(UserLogin user);
        
    }
}
