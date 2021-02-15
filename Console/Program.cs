 using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Repository;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());


            bool exit = true;
            while (exit)
            {
                Console.WriteLine("WELCOME TO RENTAL SYSTEM \n ---------------------------------------------" +
                    "\n\n 1. Add a new Car \n" +
                    "2. Delete car \n" +
                    "3. Update Car \n" +
                    "4. List Cars \n" +
                    "5. List Car Details \n" +
                    "6. Add a new Brand \n" +
                    "7. Add a new Customer \n" +
                    "8. Add a new User \n" +
                    "9. Add a rental Car \n" +
                    "10. List all the customers \n" +
                    "11. Update a rental car \n" +
                    "12. List Users \n" +
                    "13. List Rental Cars \n" +
                    "14. List brands \n" +
                    "15. List cars by price \n" +
                    "16. List Cars by model year \n" +
                    "17. Check return date \n" +
                    "18. Update return date \n" +
                    "19. Get cars by Id \n" +
                    "20. exit \n"

                    );

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n ------------------------------------------");

                switch (choice)
                {
                    case 1:
                        AddCar(carManager);
                        break;
                    case 2:
                        DeleteCar(carManager);
                        break;
                    case 3:
                        UpdateCar(carManager);
                        break;
                    case 4:
                        ListCars(carManager);
                        break;
                    case 5:
                        ListCarDetails(carManager);
                        break;
                    case 6:
                        AddBrand(brandManager);
                        break;
                    case 7:
                        AddCustomer(customerManager);
                        break;
                    case 8:
                        AddUser(userManager);
                        break;
                    case 9:
                        AddRental(rentalManager, carManager);
                        break;
                    case 10:
                        GetAllCustomerList(customerManager);
                        break;
                    case 11:
                        UpdateRental(rentalManager);
                        break;
                    case 12:
                        GetAllUserList(userManager);
                        break;
                    case 13:
                        ListRentalDetails(rentalManager);
                        break;
                    case 14:
                        ListBrands(brandManager);
                        break;
                    case 15:
                        ListCarsByPrice(carManager, brandManager);
                        break;
                    case 16:
                        ListCarsByModelYear(carManager, brandManager);
                        break;
                    case 17:
                        CheckReturnRental(rentalManager);
                        break;
                    case 18:
                        UpdateReturnedRental(rentalManager, customerManager, carManager);
                        break;
                    case 19:
                        CarsById(carManager,colorManager,brandManager);
                        break;
                    case 20:
                        exit = false;
                        Console.WriteLine("Exitted");
                        break;
                }
            }
        }

        private static void AddCar(CarManager carManager)
        {
            Console.WriteLine("Enter car brand id :");
            int BrandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter car car id:");
            int ColorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter car model year:");
            int ModelYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter car daily price:");
            decimal DailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter car description:");
            string Description = Console.ReadLine();
            Console.WriteLine("Enter car name:");
            string Name = Console.ReadLine();
            Console.Clear();
            carManager.Add(new Car
            {
                BrandId = BrandId,
                ColorId = ColorId,
                DailyPrice = DailyPrice,
                Description = Description,
                ModelYear = ModelYear,
                Name = Name
            });
            Console.WriteLine("New car was added");
        }

        private static void DeleteCar(CarManager carManager)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Enter id that you want to delete car:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            carManager.Delete(new Car { Id = id });
            Console.WriteLine("Car was deleted");
            ListCars(carManager);
        }
        private static void ListCarDetails(CarManager carManager)
        {
            Console.WriteLine("--------------------------------------------------------");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{ car.Id.ToString()}\t {car.CarName}\t {car.BrandName}\t {car.ColorName}\t {car.DailyPrice}\t {car.ModelYear}\t {car.Description}");
            }

            Console.WriteLine("Car details Listed");

        }

        private static void UpdateCar(CarManager carManager)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Enter id that you want to update car");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Enter car brand id :");
            int BrandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter car car id:");
            int ColorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter car model year:");
            int ModelYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter car daily price:");
            decimal DailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter car description:");
            string Description = Console.ReadLine();
            Console.WriteLine("Enter car name:");
            string Name = Console.ReadLine();
            Console.Clear();
            carManager.Update(new Car {
                Id = id, BrandId = BrandId,
                ColorId = ColorId,
                Name = Name,
                DailyPrice = DailyPrice,
                ModelYear = ModelYear,
                Description = Description });

            ListCars(carManager);
        }
        private static void AddBrand(BrandManager brandManager)
        {
            Console.WriteLine("Enter brand name:");
            string BrandName = Console.ReadLine();
            Console.Clear();
            brandManager.Add(new Brand { Name = BrandName });

        }
        private static void ListBrands(BrandManager brandManager) {
            Console.WriteLine("------------------------------");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.Id}\t {brand.Name}");
            }

        }

        private static void ListCars(CarManager carManager)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Cars were Listed");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.Id}\t {car.Name}\t {car.ModelYear}\t {car.DailyPrice}\t {car.Description}");
            }
        }


        private static void AddCustomer(CustomerManager customerManager)
        {
            Console.WriteLine("Enter customer name:");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter user id:");
            int UserId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            customerManager.Add(new Customer { UserId = UserId, CompanyName = Name });
        }

        private static void AddUser(UserManager userManager)
        {
            Console.WriteLine("Enter user First Name:");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Enter user Last Name:");
            string LastName = Console.ReadLine();
            Console.WriteLine("Enter user email:");
            string Email = Console.ReadLine();
            Console.WriteLine("Enter user paasword:");
            string Password = Console.ReadLine();
            Console.Clear();
            userManager.Add(new User{ FirstName = FirstName, LastName = LastName, Email = Email, Password = Password });

        }

        private static void AddRental(RentalManager rentalManager, CarManager carManager)
        {
            Console.Clear();
            Console.WriteLine("Enter car informations that to rent a car:");
            ListCarDetails(carManager);
            Console.Write("Enter rental car Id: ");
            int CarId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter customer Id : ");
            int CustomerId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(rentalManager.Add(new Rental { CarId = CarId, CustomerId = CustomerId, RentDate = Convert.ToDateTime(null), ReturnDate = Convert.ToDateTime(null) }));
        }
        private static void ListRentalDetails(RentalManager rentalManager)
        {
            Console.Clear();
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {

                Console.WriteLine($"{rental.CarId}\t {rental.Id}\t {rental.CustomerName}\t {rental.CarName}\t {rental.RentDate}\t {rental.ReturnDate}\t {rental.UserFirstName}\t{rental.UserLastName}");
            }
        }

        private static void UpdateRental(RentalManager rentalManager)
        {
            Console.Clear();
            ListRentalDetails(rentalManager);
            Console.Write(" Enter car Id: ");
            int RentId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(rentalManager.Update(new Rental { Id = RentId, RentDate = DateTime.Now }));
        }

        private static void CheckReturnRental(RentalManager rentalManager)
        {
            Console.WriteLine("Check car id that you rented");
            int carId = Convert.ToInt32(Console.ReadLine());
            var returnedRental = rentalManager.GetRentalDetails(r => r.CarId == carId);
            foreach (var rental in returnedRental.Data)
            {
                rental.ReturnDate = DateTime.Now;
                Console.WriteLine(returnedRental.Messages);
            }
        }
        private static void UpdateReturnedRental(RentalManager rentalManager, CustomerManager customerManager, CarManager carManager)
        {
            Console.Clear();
            ListRentalDetails(rentalManager);
            Console.Write("Enter id that you want to deliver car:");
            int RentId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(rentalManager.Update(new Rental { Id = RentId, ReturnDate = DateTime.Now }));
        }

        private static void ListCarsByPrice(CarManager carManager, BrandManager brandManager)
        {
            foreach (var car in carManager.GetAll().Data)
            {
                foreach (var brand in brandManager.GetAll().Data.Where(c => c.Id == car.BrandId))
                {
                    Console.WriteLine("Brand:{0} Model year:{1} Price:{2}\n", brand.Name, car.ModelYear, car.DailyPrice);
                }
            }
        }
        private static void ListCarsByModelYear(CarManager carManager, BrandManager brandManager)
        {
            foreach (var car in carManager.GetAll().Data)
            {
                foreach (var brand in brandManager.GetAll().Data.Where(c => c.Id == car.BrandId))
                {
                    Console.WriteLine("Brand:{0} Model year:{1} Price:{2}\n", brand.Name, car.ModelYear, car.DailyPrice);
                }
            }
        }

        private static void CarsById(CarManager carManager, ColorManager colorManager, BrandManager brandManager)
        {
            Console.WriteLine("Enter car id:");
            int carId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nId'si {carId} olan araba: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            Car carById = carManager.GetById(carId).Data;
            Console.WriteLine($"{carById.Id}\t{colorManager.GetById(carById.ColorId).Data.Name}\t\t{brandManager.GetById(carById.BrandId).Data.Name}\t\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Description}");
        }

        private static void GetAllCustomerList(CustomerManager customerManager)
        {
            Console.WriteLine("Customer lists: \nId\t User Id\tCustomer Name");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{customer.Id}\t{customer.UserId}\t{customer.CompanyName}");
            }
        }
        private static void GetAllUserList(UserManager userManager)
        {
            Console.WriteLine("Users list: \nId\tFirst Name\tLast Name\tEmail\tPassword");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.LastName}\t{user.Password}");
            }
        }
    }
}