namespace OperationResult.Tags
{
    public struct ErrorTag { }

    public readonly struct ErrorTag<TError>
    {
        internal readonly TError _error;

        internal ErrorTag(TError error)
        {
            _error = error;
        }
    }
}
