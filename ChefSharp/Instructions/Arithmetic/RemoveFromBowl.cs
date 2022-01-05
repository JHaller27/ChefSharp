namespace ChefSharp.Instructions
{
    public class RemoveFromBowl : ArithmeticInstruction
    {
        public RemoveFromBowl(string name, int? bowlId = null) : base(name, bowlId) {}

        protected override int Combine(int op1, int op2) => op1 - op2;
    }
}
