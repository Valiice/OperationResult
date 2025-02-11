﻿using OperationResult.Tags;

namespace OperationResult
{
    /// <summary>
    /// Result of operation (without Error field)
    /// </summary>
    /// <typeparam name="TResult">Type of Value field</typeparam>
    public readonly struct Result<TResult>
    {
        private readonly bool _isSuccess;

        public readonly TResult Value;

        public readonly bool IsSuccess => _isSuccess;
        public readonly bool IsError => !_isSuccess;

        private Result(bool isSuccess)
        {
            _isSuccess = isSuccess;
            Value = default!;
        }

        private Result(TResult result)
        {
            _isSuccess = true;
            Value = result;
        }

        public static implicit operator bool(Result<TResult> result)
        {
            return result._isSuccess;
        }

        public static implicit operator Result<TResult>(TResult result)
        {
            return new Result<TResult>(result);
        }

        public static implicit operator Result<TResult>(SuccessTag<TResult> tag)
        {
            return new Result<TResult>(tag._value);
        }

        private static readonly Result<TResult> _errorResult = new(false);

        public static implicit operator Result<TResult>(ErrorTag tag)
        {
            return _errorResult;
        }
    }

    /// <summary>
    /// Result of operation (with Error field)
    /// </summary>
    /// <typeparam name="TResult">Type of Value field</typeparam>
    /// <typeparam name="TError">Type of Error field</typeparam>
    public readonly struct Result<TResult, TError>
    {
        private readonly bool _isSuccess;

        public readonly TResult Value;
        public readonly TError Error;

        public readonly bool IsSuccess => _isSuccess;
        public readonly bool IsError => !_isSuccess;

        private Result(TResult result)
        {
            _isSuccess = true;
            Value = result;
            Error = default!;
        }

        private Result(TError error)
        {
            _isSuccess = false;
            Value = default!;
            Error = error;
        }

        public readonly void Deconstruct(out TResult result, out TError error)
        {
            result = Value;
            error = Error;
        }

        public static implicit operator bool(Result<TResult, TError> result)
        {
            return result._isSuccess;
        }

        public static implicit operator Result<TResult, TError>(TResult result)
        {
            return new Result<TResult, TError>(result);
        }

        public static implicit operator Result<TResult, TError>(SuccessTag<TResult> tag)
        {
            return new Result<TResult, TError>(tag._value);
        }

        public static implicit operator Result<TResult, TError>(ErrorTag<TError> tag)
        {
            return new Result<TResult, TError>(tag._error);
        }
    }

    /// <summary>
    /// Result of operation (with different Errors)
    /// </summary>
    /// <typeparam name="TResult">Type of Value field</typeparam>
    /// <typeparam name="TError1">Type of first Error</typeparam>
    /// <typeparam name="TError2">Type of second Error</typeparam>
    public readonly struct Result<TResult, TError1, TError2>
    {
        private readonly bool _isSuccess;

        public readonly TResult Value;
        public readonly object Error;

        public readonly bool IsSuccess => _isSuccess;
        public readonly bool IsError => !_isSuccess;

        public bool HasError<TError>() => Error is TError;
        public readonly TError GetError<TError>() => (TError)Error;

        private Result(TResult result)
        {
            _isSuccess = true;
            Value = result;
            Error = null!;
        }

        private Result(object error)
        {
            _isSuccess = false;
            Value = default!;
            Error = error;
        }

        public void Deconstruct(out TResult result, out object error)
        {
            result = Value;
            error = Error;
        }

        public static implicit operator bool(Result<TResult, TError1, TError2> result)
        {
            return result._isSuccess;
        }

        public static implicit operator Result<TResult, TError1, TError2>(TResult result)
        {
            return new Result<TResult, TError1, TError2>(result);
        }

        public static implicit operator Result<TResult, TError1, TError2>(SuccessTag<TResult> tag)
        {
            return new Result<TResult, TError1, TError2>(tag._value);
        }

        public static implicit operator Result<TResult, TError1, TError2>(ErrorTag<TError1> tag)
        {
            return new Result<TResult, TError1, TError2>(tag._error!);
        }

        public static implicit operator Result<TResult, TError1, TError2>(ErrorTag<TError2> tag)
        {
            return new Result<TResult, TError1, TError2>(tag._error!);
        }
    }

    /// <summary>
    /// Result of operation (with different Errors)
    /// </summary>
    /// <typeparam name="TResult">Type of Value field</typeparam>
    /// <typeparam name="TError1">Type of first Error</typeparam>
    /// <typeparam name="TError2">Type of second Error</typeparam>
    /// <typeparam name="TError3">Type of third Error</typeparam>
    public readonly struct Result<TResult, TError1, TError2, TError3>
    {
        private readonly bool _isSuccess;

        public readonly TResult Value;
        public readonly object Error;

        public readonly bool IsSuccess => _isSuccess;
        public readonly bool IsError => !_isSuccess;

        public readonly bool HasError<TError>() => Error is TError;
        public TError GetError<TError>() => (TError)Error;

        private Result(TResult result)
        {
            _isSuccess = true;
            Value = result;
            Error = null!;
        }

        private Result(object error)
        {
            _isSuccess = false;
            Value = default!;
            Error = error;
        }

        public void Deconstruct(out TResult result, out object error)
        {
            result = Value;
            error = Error;
        }

        public static implicit operator bool(Result<TResult, TError1, TError2, TError3> result)
        {
            return result._isSuccess;
        }

        public static implicit operator Result<TResult, TError1, TError2, TError3>(TResult result)
        {
            return new Result<TResult, TError1, TError2, TError3>(result);
        }

        public static implicit operator Result<TResult, TError1, TError2, TError3>(SuccessTag<TResult> tag)
        {
            return new Result<TResult, TError1, TError2, TError3>(tag._value);
        }

        public static implicit operator Result<TResult, TError1, TError2, TError3>(ErrorTag<TError1> tag)
        {
            return new Result<TResult, TError1, TError2, TError3>(tag._error!);
        }

        public static implicit operator Result<TResult, TError1, TError2, TError3>(ErrorTag<TError2> tag)
        {
            return new Result<TResult, TError1, TError2, TError3>(tag._error!);
        }

        public static implicit operator Result<TResult, TError1, TError2, TError3>(ErrorTag<TError3> tag)
        {
            return new Result<TResult, TError1, TError2, TError3>(tag._error!);
        }
    }
}
