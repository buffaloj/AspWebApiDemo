using BufTools.DataStore.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Domain.Models
{
    [StoredData]
    public class MealTime
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of when to eat a meal
        /// </summary>
        /// <example>breakfast</example>
        public string Name { get; set; }
    }
}
