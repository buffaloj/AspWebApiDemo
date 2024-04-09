using BufTools.DataStore.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DemoApi.Domain.Models
{
    [StoredData]
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int FoodTypeId { get; set; }
        public int MeasurementId { get; set; }

#region Nav Properties
        [JsonIgnore]
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(FoodTypeId))]
        public virtual FoodType FoodType { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(RecipeId))]
        public virtual Measurement Measurement { get; set; }
#endregion
    }
}
