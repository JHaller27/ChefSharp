namespace ChefSharp.Instructions
{
    public class CombineIntoBowl : ArithmeticInstruction
    {
        public CombineIntoBowl(string name, int? bowlId = null) : base(name, bowlId) {}

        protected override int Combine(int op1, int op2) => op1 * op2;
    }
}
