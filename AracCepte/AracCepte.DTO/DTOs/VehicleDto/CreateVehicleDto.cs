using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracCepte.DTO.DTOs.VehicleDtos
{
    public class CreateVehicleDto
    {   public  int Id { get; set; }  
        public string Brand { get; set; } //Veichle's Brand
        public string Model { get; set; } //Veihle's Model
        public int Year { get; set; } // Veihle's Year
        public string Type { get; set; } //Veichle's Type
        public float DailyPrice { get; set; } //Veichle's Daily Price
        public int VehilclesOwnerID { get; set; } //Veichle's Owner ID
        public bool Availability { get; set; } // Veichle's Availability
        public string Description { get; set; } // Veichle's Description
        public string MapUrl { get; set; } // Veichle's Location
        public string ImageURL1 { get; set; }
        public string ImageURL2 { get; set; }
        public string ImageURL3 { get; set; }
        public string ImageURL4 { get; set; }
        public string ImageURL5 { get; set; }
        public string ImageURL6 { get; set; }
        public string ImageURL7 { get; set; }
        public string ImageURL8 { get; set; }
        public string ImageURL9 { get; set; }
        public string ImageURL10 { get; set; }
    }
}
