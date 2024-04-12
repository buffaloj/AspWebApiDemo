using BufTools.DataStore.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Domain.Models
{
    /// <summary>
    /// A class representing the time a meal would typically be served
    /// </summary>
    [StoredData]
    public class MealTime
    {
        /// <summary>
        /// The unique ID
        /// </summary>
        /// <example>1</example>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of when to eat a meal
        /// </summary>
        /// <example>breakfast</example>
        public string Name { get; set; }
    }
}
