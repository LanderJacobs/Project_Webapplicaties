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

        public async Task<IActionResult> Details(DetailsViewModel vm, int id)
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
            //deze pagina is niet aangemaakt door een slechte inschatting van tijd
            return View();
        }

        public IActionResult Create()
        {
            CreateViewModel vm = new CreateViewModel();
            vm.ElementList = _uow.ElementRepository.Getall().ToList();
            vm.GeartypeList = _uow.GeartypeRepository.Getall().ToList();
            vm.RankList = _uow.RankRepository.Getall().ToList();
            return View(vm);
        }

        public IActionResult VoegToe(CreateViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.Naam) != false)
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

                    if (string.IsNullOrEmpty(vm.Upgrade1) != false)
                    {
                        gear.BaseStatTotal.Base = gear.BaseAttack.GetValueOrDefault() + gear.BaseSpeed.GetValueOrDefault() + gear.BaseHealth.GetValueOrDefault();
                        gear.BaseStatTotal.Upgrade1 = int.Parse(vm.Upgrade1);

                        if (string.IsNullOrEmpty(vm.Upgrade2) != false)
                        {
                            gear.BaseStatTotal.Upgrade2 = int.Parse(vm.Upgrade2);

                            if (string.IsNullOrEmpty(vm.Upgrade3) != false)
                            {
                                gear.BaseStatTotal.Upgrade3 = int.Parse(vm.Upgrade3);

                                if (string.IsNullOrEmpty(vm.Upgrade4) != false)
                                {
                                    gear.BaseStatTotal.Upgrade4 = int.Parse(vm.Upgrade4);
                                }
                            }
                        }

                    }
                }
                #endregion

                if (string.IsNullOrEmpty(vm.Element) != false)
                {
                    gear.Element.Name = vm.Element;
                }

                if (string.IsNullOrEmpty(vm.Rank) != false)
                {
                    gear.Rank.Name = vm.Rank;
                }

                if (string.IsNullOrEmpty(vm.GearType) != false)
                {
                    gear.Geartype.Name = vm.GearType;
                }

                int bonusID = 0;
                if (string.IsNullOrEmpty(vm.bonus) != false)
                {
                    List<Bonus> bonussen = _uow.BonusRepository.Getall().ToList();
                    Bonus bonus = new Bonus();
                    foreach (var item in bonussen)
                    {
                        if (item.Explanation == vm.bonus)
                        {
                            bonus = item;
                        }
                    }
                    if (string.IsNullOrEmpty(bonus.Explanation))
                    {
                        bonus.Explanation = vm.bonus;
                        _uow.BonusRepository.Create(bonus);
                        bonus = _uow.BonusRepository.GetByIdWithQuestion(x => x.Explanation == bonus.Explanation);
                        bonusID = bonus.BonusID;
                    }

                }

                _uow.GearRepository.Create(gear);
                _uow.Save();

                if (bonusID != 0)
                {
                    gear = _uow.GearRepository.GetByIdWithQuestion(x => x.Name == gear.Name);
                    Gear_Bonus gb = new Gear_Bonus { BonusID = bonusID, GearID = gear.GearID };
                    _uow.GearBonusRepository.Create(gb);
                    _uow.Save();
                }

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Create));
        }

        public IActionResult Filter(OverviewListViewModel vm)
        {
            if (vm.SearchResult != "" && vm.RankSelection != "" && vm.TypeSelection != "" && vm.TierSelection != "")
            {
                vm.Gears = vm.Gears.Where(x => x.Name.Contains(vm.SearchResult)).ToList();
                vm.Gears = vm.Gears.Where(x => x.Rank.Name == vm.RankSelection).ToList();
                vm.Gears = vm.Gears.Where(x => x.Geartype.Name == vm.TypeSelection).ToList();
                if (vm.TierSelection != null)
                {
                    vm.Gears = vm.Gears.Where(x => x.Tier == int.Parse(vm.TierSelection)).ToList();
                }
            }
            else
            {
                return RedirectToAction(nameof(Index));
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
                vm.Gears = vm.Gears.Where(x => x.GearID != id).ToList();
                await _uow.Save();
            }
            return View("Index", vm);
        }
    }
}
