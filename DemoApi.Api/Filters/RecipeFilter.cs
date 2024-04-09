﻿using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Api.Filters
{
    public class RecipeFilter
    {
        /// <summary>
        /// Limits a recipe list by meal time
        /// </summary>
        /// <example>1</example>
        [FromQuery(Name = "mealtime")]
        public string MealTime { get; set; }
    }
}
