using static OperationResult.Helpers;

namespace OperationResult.Tests
{

    public class ResultTests
    {
        private static Result<int> GetResult(int arg)
        {
            if (arg == 1)
            {
                return arg;
            }
            if (arg == 2)
            {
                return Ok(arg);
            }
            return Error();
        }

        [Fact]
        public void TestResultWithoutError()
        {
            var res1 = GetResult(1);

            Assert.True(res1);
            Assert.True(res1.IsSuccess);
            Assert.False(res1.IsError);
            Assert.Equal(1, res1.Value);

            var res2 = GetResult(2);

            Assert.True(res2);
            Assert.True(res2.IsSuccess);
            Assert.False(res2.IsError);
            Assert.Equal(2, res2.Value);

            var res3 = GetResult(3);

            Assert.False(res3);
            Assert.False(res3.IsSuccess);
            Assert.True(res3.IsError);
            Assert.Equal(default, res3.Value);
        }

        [Fact]
        public void TestResultWithoutErrorImplicitToBool()
        {
            bool isSuccess;

            isSuccess = GetResult(1);
            Assert.True(isSuccess);

            isSuccess = GetResult(2);
            Assert.True(isSuccess);

            isSuccess = GetResult(3);
            Assert.False(isSuccess);
        }

        private static Result<int, string> GetResultOrError(int arg)
        {
            if (arg == 1)
            {
                return arg;
            }
            if (arg == 2)
            {
                return Ok(arg);
            }
            return Error("Invalid Operation");
        }

        [Fact]
        public void TestResultWithError()
        {
            var res1 = GetResultOrError(1);

            Assert.True(res1);
            Assert.True(res1.IsSuccess);
            Assert.False(res1.IsError);
            Assert.Equal(1, res1.Value);
            Assert.Null(res1.Error);

            var res2 = GetResultOrError(2);

            Assert.True(res2);
            Assert.True(res2.IsSuccess);
            Assert.False(res2.IsError);
            Assert.Equal(2, res2.Value);
            Assert.Null(res2.Error);

            var res3 = GetResultOrError(3);

            Assert.False(res3);
            Assert.False(res3.IsSuccess);
            Assert.True(res3.IsError);
            Assert.Equal(default, res3.Value);
            Assert.Equal("Invalid Operation", res3.Error);
        }

        [Fact]
        public void TestResultWithErrorImplicitToBool()
        {
            bool isSuccess;

            isSuccess = GetResultOrError(1);
            Assert.True(isSuccess);

            isSuccess = GetResultOrError(2);
            Assert.True(isSuccess);

            isSuccess = GetResultOrError(3);
            Assert.False(isSuccess);
        }

        [Fact]
        public void TestResultWithErrorDeconstruction()
        {
            int result;
            string error;

            (result, error) = GetResultOrError(1);
            Assert.Equal(1, result);
            Assert.Null(error);

            (result, error) = GetResultOrError(2);
            Assert.Equal(2, result);
            Assert.Null(error);

            (result, error) = GetResultOrError(3);
            Assert.Equal(default, result);
            Assert.Equal("Invalid Operation", error);
        }

        private static Result<int, string, int> GetResultOrMultipleErrors(int arg)
        {
            if (arg == 1)
            {
                return arg;
            }
            if (arg == 2)
            {
                return Ok(arg);
            }
            if (arg == 3)
            {
                return Error(404);
            }
            return Error("Invalid Operation");
        }

        [Fact]
        public void TestResultWithMultipleErrors()
        {
            var res1 = GetResultOrMultipleErrors(1);

            Assert.True(res1);
            Assert.True(res1.IsSuccess);
            Assert.False(res1.IsError);
            Assert.Equal(1, res1.Value);
            Assert.Null(res1.Error);

            var res2 = GetResultOrMultipleErrors(2);

            Assert.True(res2);
            Assert.True(res2.IsSuccess);
            Assert.False(res2.IsError);
            Assert.Equal(2, res2.Value);
            Assert.Null(res2.Error);

            var res3 = GetResultOrMultipleErrors(3);

            Assert.False(res3);
            Assert.False(res3.IsSuccess);
            Assert.True(res3.IsError);
            Assert.True(res3.HasError<int>());
            Assert.Equal(default, res3.Value);
            Assert.Equal(404, res3.Error);
            Assert.Equal(404, res3.GetError<int>());

            var res4 = GetResultOrMultipleErrors(4);

            Assert.False(res4);
            Assert.False(res4.IsSuccess);
            Assert.True(res4.IsError);
            Assert.True(res4.HasError<string>());
            Assert.Equal(default, res4.Value);
            Assert.Equal("Invalid Operation", res4.Error);
            Assert.Equal("Invalid Operation", res4.GetError<string>());
        }

        [Fact]
        public void TestResultWithMultipleErrorsImplicitToBool()
        {
            bool isSuccess;

            isSuccess = GetResultOrMultipleErrors(1);
            Assert.True(isSuccess);

            isSuccess = GetResultOrMultipleErrors(2);
            Assert.True(isSuccess);

            isSuccess = GetResultOrMultipleErrors(3);
            Assert.False(isSuccess);

            isSuccess = GetResultOrMultipleErrors(4);
            Assert.False(isSuccess);
        }
    }
}
