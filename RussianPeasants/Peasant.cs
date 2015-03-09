namespace RussianPeasants
{
    using System.Collections.Generic;
    using System.Linq;

    public class Peasant
    {
        public PeasantResults Multiply(int left, int right)
        {
            // The Growths is the list of divisions/multiplications
            var growths = new Dictionary<int, int> { { left, right } };

            while (left != 1)
            {
                // Divide the left by two, ignore remainders
                left = left / 2;
                // Double the right
                right = right * 2;

                growths.Add(left, right);
            }

            // Store each growth pair that didn't have an even number on the left
            var additions = growths.Where(growth => growth.Key % 2 != 0).ToDictionary(addition => addition.Key, addition => addition.Value);

            // Add up all the addition values
            var result = additions.Sum(addition => addition.Value);

            // Return a class containing all our workings so we can see how the peasants reached their conclusions
            return new PeasantResults(growths, additions, result);
        }
    }
    
    public class PeasantResults
    {
        public readonly Dictionary<int, int> Growths;

        public readonly Dictionary<int, int> Additions;

        public readonly int Result;

        public PeasantResults(Dictionary<int, int> growths, Dictionary<int, int> additions, int result)
        {
            this.Growths = growths;
            this.Additions = additions;
            this.Result = result;
        }
    }
}
