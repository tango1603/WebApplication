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

        public SortViewModel(SortState sortOrder)
        {
            IdSort = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            CountrySort = sortOrder == SortState.CountryAsc ? SortState.CountryDesc : SortState.CountryAsc;
            CitySort = sortOrder == SortState.CityAsc ? SortState.CityDesc : SortState.CityAsc;
            StereetSort = sortOrder == SortState.StereetAsc ? SortState.StereetDesc : SortState.StereetAsc;
            BuildingNumberSort = sortOrder == SortState.BuildingNumberAsc ? SortState.BuildingNumberDesc : SortState.BuildingNumberAsc;
            PostIDSort = sortOrder == SortState.PostIDAsc ? SortState.PostIDDesc : SortState.PostIDAsc;
            DateTimeSort = sortOrder == SortState.DateTimeAsc ? SortState.DateTimeDesc : SortState.DateTimeAsc;
            Current = sortOrder;
        }
    }
}  