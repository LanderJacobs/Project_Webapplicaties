using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Webapplicaties.Data.UnitOfWork; //anders werkt het niet in dit project
using Project_Webapplicaties.ViewModels;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.Controllers
{
    public class GearController : Controller
    {
        private readonly IUnitOfWork _uow;
        public GearController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            OverviewListViewModel vm = new OverviewListViewModel();
            vm.Gears = _uow.GearRepository.GetAllWithIncludes(x => x.Rank, x => x.Geartype).ToList();
            vm.Ranks = _uow.RankRepository.Getall().ToList();
            vm.Geartypes = _uow.GeartypeRepository.Getall().ToList();
            vm.SearchResult = "";
            vm.RankSelection = "";
            vm.TierSelection = "";
            vm.TypeSelection = "";
            return View(vm);
        }

        public IActionResult Details(DetailsViewModel vm, int id)
        {
            vm.gear = _uow.GearRepository.GetbyQuestionWithIncludes(x => x.GearID == id, x => x.Rank, x => x.Geartype, x => x.Element, x => x.BaseStatTotal);
            List<Gear_Bonus> lijst = _uow.GearBonusRepository.GetAllWithQuestionAndIncludes(x => x.GearID == id, x => x.Bonus).ToList();
            foreach (var item in lijst)
            {
                vm.Bonussen.Add(item.Bonus);
            }
            return View(vm);
        }

        public IActionResult Edit()
        {
            EditViewModel vm = new EditViewModel();
            return View(vm);
        }

        public IActionResult Create()
        {
            CreateViewModel vm = new CreateViewModel();
            vm.ElementList = _uow.ElementRepository.Getall().ToList();
            vm.GeartypeList = _uow.GeartypeRepository.Getall().ToList();
            vm.RankList = _uow.RankRepository.Getall().ToList();
            return View(vm);
        }

        public IActionResult AddProperties()
        {
            AddPropertiesViewModel vm = new AddPropertiesViewModel();
            return View(vm);
        }

        public IActionResult AddPropertiesUsed(AddPropertiesViewModel vm)
        {
            return View(vm);
        }

        public IActionResult AddGearType(AddPropertiesViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.GearType) == false)
            {
                Geartype geartype = new Geartype();
                geartype.Name = vm.GearType;
                _uow.GeartypeRepository.Create(geartype);
                _uow.Save();
                vm.GearType = "";
            }

            return RedirectToAction(nameof(AddProperties));
        }

        public IActionResult AddRank(AddPropertiesViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.Rank) == false)
            {
                Rank rank = new Rank();
                rank.Name = vm.Rank;
                _uow.RankRepository.Create(rank);
                _uow.Save();
                vm.Rank = "";
            }

            return RedirectToAction(nameof(AddProperties));
        }

        public IActionResult AddElement(AddPropertiesViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.Element) == false &&
                string.IsNullOrEmpty(vm.WeakTo) == false &&
                string.IsNullOrEmpty(vm.StrongTo) == false)
            {
                Element element = new Element();
                element.Name = vm.Element;
                element.WeakTo = vm.WeakTo;
                element.StrongTo = vm.StrongTo;
                _uow.ElementRepository.Create(element);
                _uow.Save();
                vm.Element = "";
                vm.WeakTo = "";
                vm.StrongTo = "";
            }

            return RedirectToAction(nameof(AddProperties));
        }

        public IActionResult VoegToe(CreateViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.Naam) == false)
            {
                Gear gear = new Gear();
                gear.Name = vm.Naam;

                if (string.IsNullOrEmpty(vm.Tier) == false)
                {
                    gear.Tier = int.Parse(vm.Tier);
                }

                #region BaseStats
                if (string.IsNullOrEmpty(vm.BaseAttack) == false &&
                    string.IsNullOrEmpty(vm.BaseHealth) == false &&
                    string.IsNullOrEmpty(vm.BaseSpeed) == false)
                {
                    gear.BaseAttack = int.Parse(vm.BaseAttack);
                    gear.BaseHealth = int.Parse(vm.BaseHealth);
                    gear.BaseSpeed = int.Parse(vm.BaseSpeed);

                    if (string.IsNullOrEmpty(vm.Upgrade1) == false)
                    {
                        BaseStatTotal basis = new BaseStatTotal();
                        basis.Base = gear.BaseAttack.GetValueOrDefault() + gear.BaseSpeed.GetValueOrDefault() + gear.BaseHealth.GetValueOrDefault();
                        basis.Upgrade1 = int.Parse(vm.Upgrade1);

                        if (string.IsNullOrEmpty(vm.Upgrade2) == false)
                        {
                            basis.Upgrade2 = int.Parse(vm.Upgrade2);

                            if (string.IsNullOrEmpty(vm.Upgrade3) == false)
                            {
                                basis.Upgrade3 = int.Parse(vm.Upgrade3);

                                if (string.IsNullOrEmpty(vm.Upgrade4) == false)
                                {
                                    basis.Upgrade4 = int.Parse(vm.Upgrade4);
                                }
                            }
                        }
                        _uow.BaseStatTotalRepository.Create(basis);
                        gear.BaseStatTotalID = basis.BaseStatTotalID;
                    }
                }
                #endregion

                if (string.IsNullOrEmpty(vm.Element) == false)
                {
                    //Element element = _uow.ElementRepository.GetByIdWithQuestion(x => x.Name == vm.Element);
                    Element element = new Element();
                    foreach (Element item in vm.ElementList)
                    {
                        if (item.Name == vm.Element)
                        {
                            element = item;
                        }
                    }
                    gear.ElementID = element.ElementID;
                }

                if (string.IsNullOrEmpty(vm.Rank) == false)
                {
                    //Rank rank = _uow.RankRepository.GetByIdWithQuestion(x => x.Name == vm.Rank);
                    Rank rank = new Rank();
                    foreach (Rank item in vm.RankList)
                    {
                        if (item.Name == vm.Rank)
                        {
                            rank = item;
                        }
                    }
                    gear.RankID = rank.RankID;
                }

                if (string.IsNullOrEmpty(vm.GearType) == false)
                {
                    //Geartype geartype = _uow.GeartypeRepository.GetByIdWithQuestion(x => x.Name == vm.GearType);
                    Geartype geartype = new Geartype();
                    foreach (Geartype item in vm.GeartypeList)
                    {
                        if (item.Name == vm.GearType)
                        {
                            geartype = item;
                        }
                    }
                    gear.GeartypeID = geartype.GeartypeID;
                }

                //checken of bonus al bestaat of moet aangemaakt worden + aanmaken

                //int bonusID = 0;
                //if (string.IsNullOrEmpty(vm.bonus) == false)
                //{
                //    List<Bonus> bonussen = _uow.BonusRepository.Getall().ToList();
                //    Bonus bonus = new Bonus();
                //    foreach (var item in bonussen)
                //    {
                //        if (item.Explanation == vm.bonus)
                //        {
                //            bonus = item;
                //        }
                //    }

                //    if (string.IsNullOrEmpty(bonus.Explanation))
                //    {
                //        bonus.Explanation = vm.bonus;
                //        _uow.BonusRepository.Create(bonus);
                //        bonus = _uow.BonusRepository.GetByIdWithQuestion(x => x.Explanation == bonus.Explanation);
                //        bonusID = bonus.BonusID;
                //    }
                //}

                //maak gear aan

                _uow.GearRepository.Create(gear);
                _uow.Save();

                //connectie leggen tussen gear en bonus

                //if (bonusID != 0)
                //{
                //    gear = _uow.GearRepository.GetByIdWithQuestion(x => x.Name == gear.Name);
                //    Gear_Bonus gb = new Gear_Bonus { BonusID = bonusID, GearID = gear.GearID };
                //    _uow.GearBonusRepository.Create(gb);
                //    _uow.Save();
                //}

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Create));
        }

        public IActionResult Filter(OverviewListViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.SearchResult) == false)
            {
                vm.Gears = vm.Gears.Where(x => x.Name.Contains(vm.SearchResult)).ToList();

            }

            if (string.IsNullOrEmpty(vm.RankSelection) == false)
            {
                vm.Gears = vm.Gears.Where(x => x.Rank.Name == vm.RankSelection).ToList();
            }

            if (string.IsNullOrEmpty(vm.TypeSelection) == false)
            {
                vm.Gears = vm.Gears.Where(x => x.Geartype.Name == vm.TypeSelection).ToList();
            }

            if (vm.TierSelection != null)
            {
                vm.Gears = vm.Gears.Where(x => x.Tier == int.Parse(vm.TierSelection)).ToList();
            }

            return View("Index", vm);
        }

        public async Task<ActionResult> Delete(OverviewListViewModel vm, int id)
        {
            if (id == null)
            {
                return View("Index", vm);
            }
            
            Gear gear = await _uow.GearRepository.GetById(id);
            if (gear != null)
            {
                _uow.GearRepository.Delete(gear);
                await _uow.Save();
            }
            return View("Index", vm);
        }
    }
}
