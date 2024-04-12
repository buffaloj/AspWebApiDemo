using BufTools.DataStore.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DemoApi.Domain.Models
{
    /// <summary>
    /// Details about an ingredient that is in a recipe
    /// </summary>
    [StoredData]
    public class Ingredient
    {
        /// <summary>
        /// The unique ID
        /// </summary>
        /// <example>1</example>
        [Key]
        public int Id { get; set; }

        // TODO: Why is the ingredient tied to the recipe?
        /// <summary>
        /// The id of the recipe this ingredient is used in
        /// </summary>
        /// <example>Black beans</example>
        /// <example>1</example>
        public int RecipeId { get; set; }

        /// <summary>
        /// The id of the type of food this is
        /// </summary>
        public int FoodTypeId { get; set; }

        /// <summary>
        /// The Id of the measurement
        /// </summary>
        public int MeasurementId { get; set; }

#region Nav Properties
        /// <summary>
        /// Nav property used only during LINQ queries to reference the related <see cref="Recipe"/>
        /// </summary>
        [JsonIgnore]
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; }

        /// <summary>
        /// Nav property used only during LINQ queries to reference the related <see cref="FoodType"/>
        /// </summary>
        [JsonIgnore]
        [ForeignKey(nameof(FoodTypeId))]
        public virtual FoodType FoodType { get; set; }

        /// <summary>
        /// Nav property used only during LINQ queries to reference the related <see cref="Measurement"/>
        /// </summary>
        [JsonIgnore]
        [ForeignKey(nameof(RecipeId))]
        public virtual Measurement Measurement { get; set; }
#endregion
    }
}
