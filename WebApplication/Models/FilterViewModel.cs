using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Address> addreses, int? buildnum, string street)// int? id, int? postid, string city,  string country)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            addreses.Insert(0, new Address
            {
                Id = 0,
                Country = "Все",
                Stereet = "Все",
                City = "Все",
                BuildingNumber = 0,
                PostID = 0,
                DateTime = new DateTime(1900, 1, 1, 1, 1, 1)
            });        
            Addresses = new SelectList(addreses, "Id", "City", buildnum);
            SelectedBuildingNumber = buildnum;
            SelectedStereet = street;
        }
        public SelectList Addresses { get; private set; } // список адресов
        public int? SelectedId { get; private set; }   // выбранн Id
        public int? SelectedBuildingNumber { get; private set; }   // выбранн BuildingNumber
        public int? SelectedPostID { get; private set; }   // выбранн PostID
        public DateTime SelectedDateTime { get; private set; }   // выбранн DateTime
        public string SelectedCountry { get; private set; }    // введенное Country
        public string SelectedCity { get; private set; }    // введенное City
        public string SelectedStereet { get; private set; }    // введенное Stereet

    }
}
