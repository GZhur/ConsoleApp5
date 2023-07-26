public class AnagrammEqualityComparer : IEqualityComparer<string>
{
    private readonly bool _ignoreCase;
    public AnagrammEqualityComparer(bool ignoreCase = false)
    {
        _ignoreCase = ignoreCase;
    }

    public bool Equals(string? x, string? y)
    {
        if (x == null && y == null) return true;
        if (x == null && y != null) return false;
        if (y == null && x != null) return false;

        if (x.Length != y.Length) return false;

        if (_ignoreCase)
        {
            x = x.ToLower();
            y = y.ToLower();
        }
        return x.All(c => y.Contains(c));
    }

    public int GetHashCode(string obj)
    {
        if (_ignoreCase)
            obj = obj.ToLower();
        unchecked
        {
            int hash = 0;
            foreach (char c in obj)
            {
                hash += c * c;
            }
            return hash;
        }
    }
}