using BufTools.DataStore.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DemoApi.Domain.Models
{
    /// <summary>
    /// A class that represents
    /// </summary>
    [StoredData]
    public class Recipe
    {
        /// <summary>
        /// The unique ID
        /// </summary>
        /// <example>1</example>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the recipe
        /// </summary>
        /// <example>Enchiladas</example>
        public string Name { get; set; }

        /// <summary>
        /// A description of the recipe
        /// </summary>
        /// <example>A classic recipe for enchiladas</example>
        public string Description { get; set; }

        /// <summary>
        /// How long it takes to prep to make the meal
        /// </summary>
        /// <example>30</example>
        public DateTimeOffset PrepTime {  get; set; }

        /// <summary>
        /// How lnog it takes to cook the meal
        /// </summary>
        /// <example>60</example>
        public DateTimeOffset CookTime {  get; set; }

        /// <summary>
        /// How many servings the recipe makes
        /// </summary>
        /// <example>4</example>
        public float ServingYield {  get; set; }

        /// <summary>
        /// The id of the time the meal is typcally eaten
        /// </summary>
        /// <example>3</example>
        public int MealTimeId { get; set; }

        #region Nav Properties

        /// <summary>
        /// Nav property used only during LINQ queries
        /// </summary>
        public ICollection<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Nav property used only during LINQ queries
        /// </summary>
        public ICollection<Instruction> Instructions { get; set; }

        /// <summary>
        /// Nav property used only during LINQ queries
        /// </summary>
        [JsonIgnore]
        [ForeignKey(nameof(MealTimeId))]
        public virtual MealTime MealTime { get; set; }

        #endregion
    }
}
