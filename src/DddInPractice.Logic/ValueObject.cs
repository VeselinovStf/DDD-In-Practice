namespace DddInPractice.Logic
{
    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        public override bool Equals(object? obj)
        {
            var other = obj as T;

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return EqualsStructural(other);
        }

        protected abstract bool EqualsStructural(T obj);

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return GetHashCodeInternal();
        }

        protected abstract int GetHashCodeInternal();
    }
}
