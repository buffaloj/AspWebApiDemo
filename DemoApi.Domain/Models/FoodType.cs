using BufTools.DataStore.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Domain.Models
{
    /// <summary>
    /// The type a food is
    /// </summary>
    [StoredData]
    public class FoodType
    {
        /// <summary>
        /// The unique ID
        /// </summary>
        /// <example>1</example>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the type
        /// </summary>
        /// <example>Breakfast</example>
        public string Name { get; set; }
    }
}
