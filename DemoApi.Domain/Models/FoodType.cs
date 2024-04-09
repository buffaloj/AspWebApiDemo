using BufTools.DataStore.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Domain.Models
{
    [StoredData]
    public class FoodType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
