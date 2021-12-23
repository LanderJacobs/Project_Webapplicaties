using Project_Webapplicaties.Data.Repository;
using Project_Webapplicaties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Gear> GearRepository { get; }
        IRepository<BaseStatTotal> BaseStatTotalRepository { get; }
        IRepository<Bonus> BonusRepository { get; }
        IRepository<Element> ElementRepository { get; }
        IRepository<Gear_Bonus> GearBonusRepository { get; }
        IRepository<Geartype> GeartypeRepository { get; }
        IRepository<Rank> RankRepository { get; }

        Task Save();
    }
}
