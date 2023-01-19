using BandIT.Models.Entities.Abstract;
using System.Diagnostics.CodeAnalysis;

namespace BandIT.Helpers
{
    public class BandEntityComparer<T> : IEqualityComparer<T> where T : BandEntity<T>
    {
        public bool Equals(T? x, T? y)
        {
            if (x is null || y is null)
                return false;

            if (ReferenceEquals(x, y))
                return true;

            if (x.Id == y.Id && x.BandId == y.BandId)
                return true;

            return false;
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            return obj is null
                ? 0
                : obj.Id.GetHashCode();
        }
    }
}
