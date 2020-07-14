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

            var uid = Guid.NewGuid();

            var r = ResultFactory.Ok("given id for result", d);
            var r2 = ResultFactory.Ok<Guid, Object>(uid, new {Dt = d});


            Assert.True(r.OnError == false);
            Assert.True(r2.OnError == false);
            Assert.True(r2.Identifier is Guid);
            Assert.True(r.Content.Equals(d));

        }

        [Fact]
        public void FailResultIsOnError()
        {
            var r = ResultFactory.Fail<DateTime>("fake id", ResultFactory.BuildError("this is only a test", 1));

            var r2 = ResultFactory.Fail<DateTime>("fake id", DateTime.Now, ResultFactory.BuildError("this is a test"));

            var r3 = ResultFactory.FailFromResult<Guid,DateTime>(r2);

            var exc = new ArgumentNullException($"A fake exception");
            var excmain = new Exception("some exception", exc);

            var r4 = ResultFactory.Fail<object>("fake id", excmain);

            var r5 = ResultFactory.FailFromResult<Guid, Object>(r4);


            var dbg = r.Content;

            Assert.True(r.OnError);
            Assert.True(r.NullContent);
            Assert.True(r2.OnError);
            Assert.False(r2.NullContent);
            Assert.True(r3.OnError);
            Assert.True(r3.Content is Guid);
            Assert.True(r4.OnError);
            Assert.True(r5.OnError);
        }

    }
}
