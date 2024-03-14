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

        // Pattern matching for Result<T>
        public static void Match<T>(this Result<T> result, Action<Result<T>> onSuccess, Action<Result<T>> onError)
        {
            if (result.IsSuccess)
                onSuccess(result);
            else
                onError(result);
        }

        // Pattern matching for Result<T, TError>
        public static void Match<T, TError>(this Result<T, TError> result, Action<Result<T, TError>> onSuccess, Action<Result<T, TError>> onError)
        {
            if (result.IsSuccess)
                onSuccess(result);
            else
                onError(result);
        }

        // Pattern matching for Result<T>
        public static TResult Match<T, TResult>(this Result<T> result, Func<Result<T>, TResult> onSuccess, Func<Result<T>, TResult> onError)
        {
            if (result.IsSuccess)
                return onSuccess(result);
            else
                return onError(result);
        }

        // Pattern matching for Result<T, TError>
        public static TResult Match<T, TError, TResult>(this Result<T, TError> result, Func<Result<T, TError>, TResult> onSuccess, Func<Result<T, TError>, TResult> onError)
        {
            if (result.IsSuccess)
                return onSuccess(result);
            else
                return onError(result);
        }
    }
}
