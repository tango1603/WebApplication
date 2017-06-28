using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Address
    {
        // ID 
        public int Id { get; set; }
        // Страна
        public string Country { get; set; }
        // Город
        public string City { get; set; }
        // Улица
        public string Stereet { get; set; }
        // Номер дома
        public int BuildingNumber { get; set; }
        // Индекс
        public int PostID { get; set; }
        // Дата и время
        public DateTime DateTime { get; set; }
    }
}
