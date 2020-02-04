using System;
using PH.Results.Internals;
using Xunit;

namespace PH.Results.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void OkResultIsNotOnError()
        {
            DateTime d = DateTime.UtcNow;
            

            var r = ResultFactory.Ok(d, d);


            Assert.True(r.OnError == false);
            Assert.True(r.Content.Equals(d));

        }

        [Fact]
        public void FailResultIsOnError()
        {
            var r = ResultFactory.Fail<DateTime>("fake id", new Error("this is only a test", 1));

            var r2 = ResultFactory.Fail<DateTime>("fake id", DateTime.Now, new Error("this is a test"));

            var r3 = ResultFactory.FailFromResult<object,DateTime>(r2);

            var dbg = r.Content;

            Assert.True(r.OnError);
            Assert.True(r.NullContent);
            Assert.True(r2.OnError);
            Assert.False(r2.NullContent);
        }

    }
}
