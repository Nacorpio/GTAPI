using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GTATest.Crafting;
using GTATest.Items;

namespace GTATest.Utilities
{
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    public static class RecipeRepository
    {
        private readonly static List<Recipe> Recipes = new List<Recipe>();

        /// <summary>
        /// Initializes a static instance of the <see cref="RecipeRepository"/> class.
        /// </summary>
        static RecipeRepository()
        {
            
        }

        /// <summary>
        /// Determines whether the specified input is sufficient to craft a Recipe with the specified identifier.
        /// </summary>
        /// <param name="id">The unique recipe identifier.</param>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static bool IsValid(int id, ItemStack[] input)
        {
            return IsValid(Get(id), input);
        }

        /// <summary>
        /// Determines whether the specified input is sufficient to craft the specified Recipe.
        /// </summary>
        /// <param name="recipe">The recipe.</param>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static bool IsValid(Recipe recipe, ItemStack[] input)
        {
            return recipe.IsValid(input);
        }

        /// <summary>
        /// Adds a Recipe to this <see cref="RecipeRepository"/>.
        /// </summary>
        /// <param name="recipe">The recipe.</param>
        public static void Add(Recipe recipe)
        {
            if (Recipes.Any(r => r.Id == recipe.Id)) {
                return;
            }
            Recipes.Add(recipe);
        }

        /// <summary>
        /// Adds an array of recipes to this <see cref="RecipeRepository"/>.
        /// </summary>
        /// <param name="recipes"></param>
        public static void Add(params Recipe[] recipes)
        {
            recipes.ToList().ForEach(Add);
        }

        /// <summary>
        /// Gets recipes which contain the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static IEnumerable<Recipe> WhichContains(ItemStack input)
        {
            return Recipes.Where(r => r.Input.Contains(input));
        } 

        /// <summary>
        /// Gets recipes with the specified input needed to be crafted.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static IEnumerable<Recipe> With(ItemStack[] input)
        {
            return Recipes.Where(r => r.Input == input);
        }

        /// <summary>
        /// Gets a Recipe with the specified identifier from this <see cref="RecipeRepository"/>.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns></returns>
        public static Recipe Get(int id)
        {
            return Recipes.First(recipe => recipe.Id == id);
        }

        /// <summary>
        /// Gets the amount of recipes within this <see cref="RecipeRepository"/>.
        /// </summary>
        public static int Count => Recipes.Count;
    }
}
