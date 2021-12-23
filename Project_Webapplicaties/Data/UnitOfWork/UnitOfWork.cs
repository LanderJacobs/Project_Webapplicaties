using Project_Webapplicaties.Data.Repository;
using Project_Webapplicaties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly BitHeroesContext _context;

        public UnitOfWork(BitHeroesContext context)
        {
            _context = context;
        }

        private IRepository<Gear> gearRepository;
        private IRepository<BaseStatTotal> baseStatTotalRepository;
        private IRepository<Bonus> bonusRepository;
        private IRepository<Element> elementRepository;
        private IRepository<Gear_Bonus> gearBonusRepository;
        private IRepository<Geartype> geartypeRepository;
        private IRepository<Rank> rankRepository;

        public IRepository<Rank> RankRepository
        {
            get
            {
                if (rankRepository == null)
                {
                    rankRepository = new Repository<Rank>(_context);
                }
                return rankRepository;
            }
        }

        public IRepository<Geartype> GeartypeRepository
        {
            get
            {
                if (geartypeRepository == null)
                {
                    geartypeRepository = new Repository<Geartype>(_context);
                }
                return geartypeRepository;
            }
        }

        public IRepository<Gear_Bonus> GearBonusRepository
        {
            get
            {
                if (gearBonusRepository == null)
                {
                    gearBonusRepository = new Repository<Gear_Bonus>(_context);
                }
                return gearBonusRepository;
            }
        }

        public IRepository<Element> ElementRepository
        {
            get
            {
                if (elementRepository == null)
                {
                    elementRepository = new Repository<Element>(_context);
                }
                return elementRepository;
            }
        }

        public IRepository<Bonus> BonusRepository
        {
            get
            {
                if (bonusRepository == null)
                {
                    bonusRepository = new Repository<Bonus>(_context);
                }
                return bonusRepository;
            }
        }

        public IRepository<BaseStatTotal> BaseStatTotalRepository
        {
            get
            {
                if (baseStatTotalRepository == null)
                {
                    baseStatTotalRepository = new Repository<BaseStatTotal>(_context);
                }
                return baseStatTotalRepository;
            }
        }

        public IRepository<Gear> GearRepository
        {
            get 
            {
                if (gearRepository == null)
                {
                    gearRepository = new Repository<Gear>(_context);
                }
                return gearRepository;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
