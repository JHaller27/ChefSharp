namespace ChefSharp.Instructions
{
    public class PutIntoBowl : ICookable
    {
        private string Name { get; }
        private int BowlId { get; }

        public PutIntoBowl(string name, int? bowlId = null)
        {
            this.Name = name;
            this.BowlId = bowlId ?? 1;
        }

        public void Execute(Kitchen kitchen)
        {
            Ingredient ingredient = kitchen.GetIngredient(this.Name);
            kitchen.AddToBowl(this.BowlId, ingredient);
        }
    }
}
