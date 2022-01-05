namespace ChefSharp.Instructions
{
    public class FoldIntoBowl : ICookable
    {
        private string Name { get; }
        private int BowlId { get; }

        public FoldIntoBowl(string name, int? bowlId = null)
        {
            this.Name = name;
            this.BowlId = bowlId ?? 1;
        }

        public void Execute(Kitchen kitchen)
        {
            Ingredient ingredient = kitchen.TakeFromBowl(this.BowlId);
            kitchen.GetIngredient(this.Name).Amount = ingredient.Amount;
        }
    }
}
