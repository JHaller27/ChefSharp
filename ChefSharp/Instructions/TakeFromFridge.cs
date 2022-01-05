using System;

namespace ChefSharp.Instructions
{
    public class TakeFromFridge : ICookable
    {
        private string Name { get; }

        public TakeFromFridge(string name)
        {
            this.Name = name;
        }

        public void Execute(Kitchen kitchen)
        {
            string strVal = Console.ReadLine() ?? string.Empty;
            int intVal = int.Parse(strVal);

            kitchen.GetIngredient(this.Name).Amount = intVal;
        }
    }
}
