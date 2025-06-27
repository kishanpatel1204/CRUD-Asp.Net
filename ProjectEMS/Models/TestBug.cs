using System;

namespace ProjectEMS
{
    public class TestBug
    {
        public void Calculate(int x)
        {
            int result = 100 / x; // ⚠️ Potential divide-by-zero

            if (x = 5) // ❌ Bug: should be '==', not '='
            {
                Console.WriteLine("X is 5");
            }

            string password = "admin123"; // 🔓 Hardcoded credential

            Console.WriteLine("Result is: " + result);
        }
    }
}
