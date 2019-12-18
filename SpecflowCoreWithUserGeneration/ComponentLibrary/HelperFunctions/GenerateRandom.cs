using System;
using System.Text;

namespace ComponentLibrary.HelperFunctions
{
    public class GenerateRandom
    {

        public static string StringOfLength(int length)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                Random rand = new Random();
                var c = pool[rand.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
    }
}
