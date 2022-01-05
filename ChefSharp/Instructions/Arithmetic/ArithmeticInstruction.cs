namespace ChefSharp.Instructions
{
    public abstract class ArithmeticInstruction : ICookable
    {
        private string Name { get; }
        private int BowlId { get; }

        public ArithmeticInstruction(string name, int? bowlId = null)
        {
            this.Name = name;
            this.BowlId = bowlId ?? 1;
        }

        protected abstract int Combine(int op1, int op2);

        public void Execute(Kitchen kitchen)
        {
            Ingredient ingredient1 = kitchen.GetIngredient(this.Name);
            Ingredient ingredient2 = kitchen.PeekInBowl(this.BowlId).Copy();

            ingredient2.Amount = this.Combine((int)ingredient1.Amount!, (int)ingredient2.Amount!);

            kitchen.AddToBowl(this.BowlId, ingredient2);
        }
    }
}
