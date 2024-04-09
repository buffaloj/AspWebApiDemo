
namespace DemoApi.DomainServices.Procedures
{
    /// <summary>
    /// A convenience class to hold SPROCs.  Any sproc in the class will be registered with data storage
    /// </summary>
    internal static partial class Procs
    {
        //public static IQueryable<Owner> GetOwnersOfVehicle(this IRunStoredProcedures<Owner> proc,
        //                                                        string vin)
        //{
        //    return proc.WithParam("@Vin", vin)
        //               .Run("[dbo].[get_owners]");
        //}
    }
}
