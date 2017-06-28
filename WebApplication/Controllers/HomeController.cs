using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        AddressContext db;
        public HomeController(AddressContext context)
        {
            this.db = context;
        }
        public async Task<IActionResult> Index(int? buildnum, string street, int page = 1,
            SortState sortOrder = SortState.IdAsc)
        {
            int pageSize = 100;

            //фильтрация
            IQueryable<Address> addresses = db.Addreses;  //users

            if (buildnum != null && buildnum != 0)
            {
                addresses = addresses.Where(p => p.BuildingNumber == buildnum);
            }
            if (!String.IsNullOrEmpty(street))
            {
                addresses = addresses.Where(p => p.Stereet.Contains(street));
            }

            // сортировка
            switch (sortOrder)
            {
                case SortState.CountryAsc:
                    addresses = addresses.OrderBy(s => s.Country);
                    break;
                case SortState.CountryDesc:
                    addresses = addresses.OrderByDescending(s => s.Country);
                    break;
                case SortState.CityAsc:
                    addresses = addresses.OrderBy(s => s.City);
                    break;
                case SortState.CityDesc:
                    addresses = addresses.OrderByDescending(s => s.City);
                    break;
                case SortState.StereetAsc:
                    addresses = addresses.OrderBy(s => s.Stereet);
                    break;
                case SortState.StereetDesc:
                    addresses = addresses.OrderByDescending(s => s.Stereet);
                    break;
                case SortState.BuildingNumberAsc:
                    addresses = addresses.OrderBy(s => s.BuildingNumber);
                    break;
                case SortState.BuildingNumberDesc:
                    addresses = addresses.OrderByDescending(s => s.BuildingNumber);
                    break;
                case SortState.PostIDAsc:
                    addresses = addresses.OrderBy(s => s.PostID);
                    break;
                case SortState.PostIDDesc:
                    addresses = addresses.OrderByDescending(s => s.PostID);
                    break;
                case SortState.DateTimeAsc:
                    addresses = addresses.OrderBy(s => s.DateTime);
                    break;
                case SortState.DateTimeDesc:
                    addresses = addresses.OrderByDescending(s => s.DateTime);
                    break;
                case SortState.IdAsc:
                    addresses = addresses.OrderBy(s => s.Id);
                    break;
                default:
                    addresses = addresses.OrderBy(s => s.Id);
                    break;
            }
            
            // пагинация
            var count = await addresses.CountAsync();
            var items = await addresses.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Addreses.ToList(), buildnum,  street),
                Addresses = items
            };
            return View(viewModel);
        }
    }
}