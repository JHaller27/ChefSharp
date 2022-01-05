using System.Collections.Generic;

namespace ChefSharp
{
    public class Kitchen
    {
        private Dictionary<string, Ingredient> Ingredients { get; }
        private List<Stack<Ingredient>> BowlList { get; }

        public Kitchen()
        {
            this.Ingredients = new();
            this.BowlList = new();
        }

        public Ingredient GetIngredient(string name)
        {
            return this.Ingredients[name];
        }

        public void AddIngredient(Ingredient ingredient)
        {
            this.Ingredients[ingredient.Name] = ingredient;
        }

        private Stack<Ingredient> GetBowl(int bowlId)
        {
            while (this.BowlList.Count < bowlId)
            {
                this.BowlList.Add(new());
            }

            return this.BowlList[bowlId - 1];
        }

        public void AddToBowl(int bowlId, Ingredient ingredient)
        {
            this.GetBowl(bowlId).Push(ingredient);
        }

        public Ingredient TakeFromBowl(int bowlId)
        {
            return this.GetBowl(bowlId).Pop();
        }

        public IEnumerable<Ingredient> EmptyBowl(int bowlId)
        {
            Stack<Ingredient> bowl = this.GetBowl(bowlId);
            while (bowl.Count > 0)
            {
                yield return bowl.Pop();
            }
        }
    }

    public interface ICookable
    {
        public void Execute(Kitchen kitchen);
    }

    public class Recipe : ICookable
    {
        public IEnumerable<Ingredient> Ingredients { get; }
        public IEnumerable<ICookable> Instructions { get; }
        public int Serves { get; }

        public void Execute(Kitchen kitchen)
        {
            // Add Ingredients to Pantry
            foreach (Ingredient ingredient in this.Ingredients)
            {
                kitchen.AddIngredient(ingredient.Copy());
            }

            // Execute recipe instructions
            foreach (ICookable instruction in this.Instructions)
            {
                instruction.Execute(kitchen);
            }
        }
    }

    public enum MeasureType
    {
        Liquid,
        Dry,
        Undefined,
    }

    public class Ingredient
    {
        public int? Amount { get; init; }
        public MeasureType MeasureType { get; init; } = MeasureType.Undefined;
        public string Name { get; init; }

        public Ingredient Copy()
        {
            return new()
            {
                Amount = this.Amount,
                MeasureType = this.MeasureType,
                Name = this.Name,
            };
        }
    }
}
