using BufTools.DataStore.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DemoApi.Domain.Models
{
    [StoredData]
    public class Instruction
    {
        [Key]
        public int Id { get; set; }
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
        
        [JsonIgnore]
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; }

#endregion
    }
}
