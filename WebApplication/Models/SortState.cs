using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public enum SortState
    {
            IdAsc,    // по Id по возрастанию
            IdDesc,   // по Id по убыванию
            CountryAsc, // по Country по возрастанию
            CountryDesc,    // по Country по убыванию
            CityAsc, // по City по возрастанию
            CityDesc, // по City по убыванию
            StereetAsc, // по Stereet по возрастанию
            StereetDesc, // по Stereet по убыванию
            BuildingNumberAsc, // по BuildingNumber по возрастанию
            BuildingNumberDesc, // по BuildingNumber по убыванию
            PostIDAsc, // по PostID по возрастанию
            PostIDDesc, // по PostID по убыванию
            DateTimeAsc, // по DateTime по возрастанию
            DateTimeDesc // по DateTime по убыванию    
    }
}