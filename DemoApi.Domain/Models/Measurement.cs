using BufTools.DataStore.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Domain.Models
{
    [StoredData]
    public class Measurement
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// A human readable version of the measurement
        /// </summary>
        /// <example>1 tbsp</example>
        public string Description { get; set; }
    }
}
