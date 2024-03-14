using static OperationResult.Helpers;
using Assert = Xunit.Assert;

namespace OperationResult.Tests
{
    public class StatusTests
    {
        private static Status GetStatus(int arg)
        {
            if (arg == 1)
            {
                return Ok();
            }
            return Error();
        }

        [Fact]
        public void TestStatusWithoutError()
        {
            var res1 = GetStatus(1);

            Assert.True(res1);
            Assert.True(res1.IsSuccess);
            Assert.False(res1.IsError);

            var res2 = GetStatus(2);

            Assert.False(res2);
            Assert.False(res2.IsSuccess);
            Assert.True(res2.IsError);
        }

        [Fact]
        public void TestStatusWithoutErrorImplicitToBool()
        {
            bool isSuccess;

            isSuccess = GetStatus(1);
            Assert.True(isSuccess);

            isSuccess = GetStatus(2);
            Assert.False(isSuccess);
        }

        private static Status<string> GetStatusOrError(int arg)
        {
            if (arg == 1)
            {
                return Ok();
            }
            return Error("Invalid Operation");
        }

        [Fact]
        public void TestStatusWithError()
        {
            var res1 = GetStatusOrError(1);

            Assert.True(res1);
            Assert.True(res1.IsSuccess);
            Assert.False(res1.IsError);
            Assert.Null(res1.Error);

            var res2 = GetStatusOrError(2);

            Assert.False(res2);
            Assert.False(res2.IsSuccess);
            Assert.True(res2.IsError);
            Assert.Equal("Invalid Operation", res2.Error);
        }

        [Fact]
        public void TestStatusWithErrorImplicitToBool()
        {
            bool isSuccess;

            isSuccess = GetStatusOrError(1);
            Assert.True(isSuccess);

            isSuccess = GetStatusOrError(2);
            Assert.False(isSuccess);
        }

        private static Status<string, int> GetStatusOrMultipleErrors(int arg)
        {
            if (arg == 1)
            {
                return Ok();
            }
            if (arg == 2)
            {
                return Error(404);
            }
            return Error("Invalid Operation");
        }

        [Fact]
        public void TestStatusWithMultipleErrors()
        {
            var res1 = GetStatusOrMultipleErrors(1);

            Assert.True(res1);
            Assert.True(res1.IsSuccess);
            Assert.False(res1.IsError);
            Assert.Null(res1.Error);

            var res2 = GetStatusOrMultipleErrors(2);

            Assert.False(res2);
            Assert.False(res2.IsSuccess);
            Assert.True(res2.IsError);
            Assert.True(res2.HasError<int>());
            Assert.Equal(404, res2.Error);
            Assert.Equal(404, res2.GetError<int>());

            var res3 = GetStatusOrMultipleErrors(3);

            Assert.False(res3);
            Assert.False(res3.IsSuccess);
            Assert.True(res3.IsError);
            Assert.True(res3.HasError<string>());
            Assert.Equal("Invalid Operation", res3.Error);
            Assert.Equal("Invalid Operation", res3.GetError<string>());
        }

        [Fact]
        public void TestStatusWithMultipleErrorsImplicitToBool()
        {
            bool isSuccess;

            isSuccess = GetStatusOrMultipleErrors(1);
            Assert.True(isSuccess);

            isSuccess = GetStatusOrMultipleErrors(2);
            Assert.False(isSuccess);

            isSuccess = GetStatusOrMultipleErrors(3);
            Assert.False(isSuccess);
        }
    }
}
