using OperationResult.Tags;

namespace OperationResult
{
    /// <summary>
    /// Status of operation (without Value and Error fields)
    /// </summary>
    public readonly struct Status
    {
        private readonly bool _isSuccess;

        public readonly bool IsSuccess => _isSuccess;
        public bool IsError => !_isSuccess;

        private Status(bool isSuccess)
        {
            _isSuccess = isSuccess;
        }

        public static implicit operator bool(Status status)
        {
            return status._isSuccess;
        }

        private static readonly Status _successStatus = new(true);

        public static implicit operator Status(SuccessTag tag)
        {
            return _successStatus;
        }

        private static readonly Status _errorStatus = new(false);

        public static implicit operator Status(ErrorTag tag)
        {
            return _errorStatus;
        }
    }

    /// <summary>
    /// Status of operation (without Value but with Error field)
    /// </summary>
    /// <typeparam name="TError">Type of Error field</typeparam>
    public readonly struct Status<TError>
    {
        private readonly bool _isSuccess;

        public readonly TError Error;

        public readonly bool IsSuccess => _isSuccess;
        public readonly bool IsError => !_isSuccess;

        private Status(bool isSuccess)
        {
            _isSuccess = isSuccess;
            Error = default!;
        }

        private Status(TError error)
        {
            _isSuccess = false;
            Error = error;
        }

        public static implicit operator bool(Status<TError> status)
        {
            return status._isSuccess;
        }

        private static readonly Status<TError> _successStatus = new(true);

        public static implicit operator Status<TError>(SuccessTag tag)
        {
            return _successStatus;
        }

        public static implicit operator Status<TError>(ErrorTag<TError> tag)
        {
            return new Status<TError>(tag._error);
        }
    }

    /// <summary>
    /// Status of operation (without Value but with different Errors)
    /// </summary>
    /// <typeparam name="TError1">Type of first Error</typeparam>
    /// <typeparam name="TError2">Type of second Error</typeparam>
    public readonly struct Status<TError1, TError2>
    {
        private readonly bool _isSuccess;

        public readonly object Error;

        public readonly bool IsSuccess => _isSuccess;
        public bool IsError => !_isSuccess;

        public readonly bool HasError<TError>() => Error is TError;
        public readonly TError GetError<TError>() => (TError)Error;

        private Status(bool isSuccess)
        {
            _isSuccess = isSuccess;
            Error = null!;
        }

        private Status(object error)
        {
            _isSuccess = false;
            Error = error;
        }

        public static implicit operator bool(Status<TError1, TError2> status)
        {
            return status._isSuccess;
        }

        private static readonly Status<TError1, TError2> _successStatus = new(true);

        public static implicit operator Status<TError1, TError2>(SuccessTag tag)
        {
            return _successStatus;
        }

        public static implicit operator Status<TError1, TError2>(ErrorTag<TError1> tag)
        {
            return new Status<TError1, TError2>(tag._error!);
        }

        public static implicit operator Status<TError1, TError2>(ErrorTag<TError2> tag)
        {
            return new Status<TError1, TError2>(tag._error!);
        }
    }


    /// <summary>
    /// Status of operation (without Value but with different Errors)
    /// </summary>
    /// <typeparam name="TError1">Type of first Error</typeparam>
    /// <typeparam name="TError2">Type of second Error</typeparam>
    /// <typeparam name="TError3">Type of third Error</typeparam>
    public readonly struct Status<TError1, TError2, TError3>
    {
        private readonly bool _isSuccess;

        public readonly object Error;

        public readonly bool IsSuccess => _isSuccess;
        public bool IsError => !_isSuccess;

        public readonly bool HasError<TError>() => Error is TError;
        public readonly TError GetError<TError>() => (TError)Error;

        private Status(bool isSuccess)
        {
            _isSuccess = isSuccess;
            Error = null!;
        }

        private Status(object error)
        {
            _isSuccess = false;
            Error = error;
        }

        public static implicit operator bool(Status<TError1, TError2, TError3> status)
        {
            return status._isSuccess;
        }

        private static readonly Status<TError1, TError2, TError3> _successStatus = new(true);

        public static implicit operator Status<TError1, TError2, TError3>(SuccessTag tag)
        {
            return _successStatus;
        }

        public static implicit operator Status<TError1, TError2, TError3>(ErrorTag<TError1> tag)
        {
            return new Status<TError1, TError2, TError3>(tag._error!);
        }

        public static implicit operator Status<TError1, TError2, TError3>(ErrorTag<TError2> tag)
        {
            return new Status<TError1, TError2, TError3>(tag._error!);
        }

        public static implicit operator Status<TError1, TError2, TError3>(ErrorTag<TError3> tag)
        {
            return new Status<TError1, TError2, TError3>(tag._error!);
        }
    }
}
