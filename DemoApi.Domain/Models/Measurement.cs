using BufTools.DataStore.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Domain.Models
{
    /// <summary>
    /// Represents a unit of measure for an ingredient
    /// </summary>
    [StoredData]
    public class Measurement
    {
        /// <summary>
        /// The unique ID
        /// </summary>
        /// <example>1</example>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// A human readable version of the measurement
        /// </summary>
        /// <example>1 tbsp</example>
        public string Description { get; set; }
    }
}
