using OperationResult.Tags;

namespace OperationResult
{
    public static class Helpers
    {
        private static readonly SuccessTag _successTag = new();

        /// <summary>
        /// Create "Success" Status or Result
        /// </summary>
        public static SuccessTag Ok()
        {
            return _successTag;
        }

        /// <summary>
        /// Create "Success" Status or Result
        /// </summary>
        public static SuccessTag<TResult> Ok<TResult>(TResult result)
        {
            return new SuccessTag<TResult>(result);
        }

        private static readonly ErrorTag _errorTag = new();

        /// <summary>
        /// Create "Error" Status or Result
        /// </summary>
        public static ErrorTag Error()
        {
            return _errorTag;
        }

        /// <summary>
        /// Create "Error" Status or Result
        /// </summary>
        public static ErrorTag<TError> Error<TError>(TError error)
        {
            return new ErrorTag<TError>(error);
        }
    }
}
