using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaserUppgift1VSTuanMinhLuu
{
    public class ActiveRentals
    {
        public int RentalId { get; set; }
        public int RenterId { get; set; }
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }

        public ActiveRentals(int rentalId, int renterId, int carId, string carBrand, string carModel)
        {
            this.RentalId = rentalId;
            this.RenterId = renterId;
            this.CarId = carId;
            this.CarBrand = carBrand;
            this.CarModel = carModel;
        }
    }
}
