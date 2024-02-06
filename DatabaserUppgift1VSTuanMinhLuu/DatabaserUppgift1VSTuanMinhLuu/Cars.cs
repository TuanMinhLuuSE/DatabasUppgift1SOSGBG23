using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaserUppgift1VSTuanMinhLuu
{
    public class Cars
    {
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarType { get; set; }
        public string CarFuelType { get; set; }
        public int CarNumberOfSeats { get; set; }
        public bool CarAvailable { get; set; }

        public Cars(int carId, string carBrand, string carModel, string carType, string carFuelType, int carNumberOfSeats, bool carAvailable)
        {
            this.CarId = carId;
            this.CarBrand = carBrand;
            this.CarModel = carModel;
            this.CarType = carType;
            this.CarFuelType = carFuelType;
            this.CarNumberOfSeats = carNumberOfSeats;
            this.CarAvailable = carAvailable;
        }
    }
}
