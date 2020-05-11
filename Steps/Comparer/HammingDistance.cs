using System.Linq;

namespace Steps.Comparer
{
    public static class HammingDistance
    {
        public static double FindDistance(string hash1, string hash2)
        {
            int distance = 
                hash1.ToCharArray()
                .Zip(hash2.ToCharArray(), (c1, c2) => new { c1, c2 })
                .Count(m => m.c1 != m.c2);
            return distance / hash1.Length;
        }
    }
}
