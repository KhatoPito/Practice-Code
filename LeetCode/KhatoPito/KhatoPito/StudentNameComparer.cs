using System.Collections.Generic;

namespace KhatoPito
{
    internal class StudentNameComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x.CompareTo(y);
        }
    }
}