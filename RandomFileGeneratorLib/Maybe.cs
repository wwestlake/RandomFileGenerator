namespace RandomFileGeneratorLib
{
    public class Maybe<T>
    {
        public T? Value { get; set; }
        public bool HasValue { get; set; }

        public static Maybe<T> Some(T value)
        {
            return new Maybe<T> { HasValue = true, Value = value };
        }
        public static Maybe<T> None()
        {
            return new Maybe<T> { HasValue = false, Value = default };
        }
    }
}