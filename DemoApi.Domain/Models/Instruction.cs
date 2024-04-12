using BufTools.DataStore.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DemoApi.Domain.Models
{
    /// <summary>
    /// Represents an individual instruction used in a recipe
    /// </summary>
    [StoredData]
    public class Instruction
    {
        /// <summary>
        /// The unique ID
        /// </summary>
        /// <example>1</example>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The ID of the recipe the instruction is included in
        /// </summary>
        /// <example>1</example>
        public int RecipeId { get; set; }

        /// <summary>
        /// The body of the instruction
        /// </summary>
        /// <example>Dice onions and other vegitables.</example>
        public string Description { get; set; }

        /// <summary>
        /// The order in which to display the steps
        /// </summary>
        /// <example>1</example>
        public int Step { get; set; }

        #region Nav Properties

        /// <summary>
        /// Nav property used only during LINQ queries
        /// </summary>
        [JsonIgnore]
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; }

        #endregion
    }
}
