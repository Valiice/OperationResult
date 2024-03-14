namespace OperationResult.Tags
{
    public struct SuccessTag { }

    public readonly struct SuccessTag<TResult>
    {
        internal readonly TResult _value;

        internal SuccessTag(TResult result)
        {
            _value = result;
        }
    }
}
