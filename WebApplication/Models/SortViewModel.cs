using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class SortViewModel
    {
        public SortState IdSort { get; private set; } // значение для сортировки по имени
        public SortState CountrySort { get; private set; }    // значение для сортировки по возрасту
        public SortState CitySort { get; private set; }   // значение для сортировки по компании
        public SortState StereetSort { get; private set; }   // значение для сортировки по компании
        public SortState BuildingNumberSort { get; private set; }   // значение для сортировки по компании
        public SortState PostIDSort { get; private set; }   // значение для сортировки по компании
        public SortState DateTimeSort { get; private set; }   // значение для сортировки по компании
        public SortState Current { get; private set; }     // текущее значение сортировки
        public bool Up { get; set; }  // Сортировка по возрастанию или убыванию

        public SortViewModel(SortState sortOrder)
        {
            // значения по умолчанию
            IdSort = SortState.IdAsc;
            CountrySort = SortState.CountryAsc;
            CitySort = SortState.CityAsc;
            StereetSort = SortState.StereetAsc;
            BuildingNumberSort = SortState.BuildingNumberAsc;
            PostIDSort = SortState.PostIDAsc;
            DateTimeSort = SortState.DateTimeAsc;
            Up = true;

            if (sortOrder == SortState.IdDesc 
                || sortOrder == SortState.CountryDesc 
                || sortOrder == SortState.CityDesc
                || sortOrder == SortState.StereetDesc 
                || sortOrder == SortState.BuildingNumberDesc 
                || sortOrder == SortState.PostIDDesc 
                || sortOrder == SortState.DateTimeDesc)
            {
                Up = false;
            }

            switch (sortOrder)
            {
                case SortState.CountryAsc:
                    Current = CountrySort = SortState.CountryDesc;
                    break;
                case SortState.CountryDesc:
                    Current = CountrySort = SortState.CountryAsc;
                    break;
                case SortState.CityAsc:
                    Current = CitySort = SortState.CityDesc;
                    break;
                case SortState.CityDesc:
                    Current = CitySort = SortState.CityAsc;
                    break;
                case SortState.StereetAsc:
                    Current = StereetSort = SortState.StereetDesc;
                    break;
                case SortState.StereetDesc:
                    Current = StereetSort = SortState.StereetAsc;
                    break;
                case SortState.BuildingNumberAsc:
                    Current = BuildingNumberSort = SortState.BuildingNumberDesc;
                    break;
                case SortState.BuildingNumberDesc:
                    Current = BuildingNumberSort = SortState.BuildingNumberAsc;
                    break;
                case SortState.PostIDAsc:
                    Current = PostIDSort = SortState.PostIDDesc;
                    break;
                case SortState.PostIDDesc:
                    Current = PostIDSort = SortState.PostIDAsc;
                    break;
                case SortState.DateTimeAsc:
                    Current = DateTimeSort = SortState.DateTimeDesc;
                    break;
                case SortState.DateTimeDesc:
                    Current = DateTimeSort = SortState.DateTimeAsc;
                    break;
                case SortState.IdDesc:
                    Current = IdSort = SortState.IdAsc;
                    break;
                case SortState.IdAsc:
                    Current = IdSort = SortState.IdDesc;
                    break;
                default:
                    Current = IdSort = SortState.IdAsc;
                    break;
            }
        }
    }
}  