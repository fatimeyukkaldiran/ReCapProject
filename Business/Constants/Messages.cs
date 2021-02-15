using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        //Car messages
        public static string CarAdded = "The car was added!";
        public static string CarDescriptionInvalid = "The car description is invalid";
        internal static string MaintenanceTime = "system is under maintenance";
        internal static string CarsListed = "Cars were listed";
        public static string CarNameInvalid = "The car name is invalid";
        public static string CarPriceInvalid = "The car price is invalid";
        public static string CarUpdatedFailed = "Update failed, check values";
        public static string CarUpdated = "The car was updated!";

        //Brand Messages
        public static string BrandAdded = "The brand was added!";
        public static string BrandDeleted = "The brand was deleted!";
        public static string BrandUpdated = "The brand was updated!";
        public static string BrandNameInvalid = "The brand name is invalid!!";

        //color messages
        public static string ColorAdded = "The Color was added!";
        public static string ColorDeleted = "The Color was deleted!";
        public static string ColorUpdated = "The Color was updated!";
        public static string ColorNameInvalid = "The Color name is invalid!!";

        //user messages
        public static string UserAdded = "The User was added!";
        public static string UserDeleted = "The User was deleted!";
        public static string UserUpdated = "The User was updated!";
        public static string UserInvalid = "The User informations are invalid!!";
        public static string UserUpdatedFailed= " Invalid value entered!";
       
        //customer messages
        public static string CustomerAdded = "The Customer was added!";
        public static string CustomerDeleted = "The Customer was deleted!";
        public static string CustomerUpdated = "The Customer was updated!";
        public static string CustomerNameInvalid = "The Customer name is invalid!!";

        //rental messages
        public static string RentalAdded = "The car rental has been completed successfully!";
        public static string RentalDeleted = "The Car rental was canceled!";
        public static string RentalUpdated = "The car rental was updated!";
        public static string FailedRental = "Can't rent this car as it hasn't been delivered yet!";
        public static string ReturnedRental = "The car has been delivered";
        public static string ReturnedRentalError = "The car already has been delivered";
    }
}
