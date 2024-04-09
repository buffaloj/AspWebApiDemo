using System.Linq;
using System;
using DemoApi.Domain.Models;

namespace DemoApi.DomainServices.Functions
{
    /// <summary>
    /// A convenience class to hold funcs.  Any func in the class will be registered with data storage
    /// </summary>
    internal static partial class Funcs
    {
        //[StoredFunction("number_of_cars_owned", "dbo")]
        //public static int NumberOfCarsOwned(int personId)
        //    => throw new NotSupportedException();

        //[StoredFunction("owners_of_vehicle", "dbo")]
        //public static IQueryable<Owner> OwnersOfVehicle(string vin)
        //    => throw new NotSupportedException();
    }
}
