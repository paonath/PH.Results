# PH.Results - [![NuGet Badge](https://buildstats.info/nuget/PH.Results)](https://www.nuget.org/packages/PH.Results/)
small package to encapsulate results or errors avoiding the use of exceptions

## Code Examples

**Return a OK result**
```c#
DateTime d = DateTime.UtcNow;
var r = ResultFactory.Ok("given id for result", d);

```

**Return a Fail result**

```c#
var r0 = ResultFactory.Fail<DateTime>("fake id", ResultFactory.BuildError("this is only a test", 1));
```

**Return a Fail result starting from another failure**
```c#
Result<DateTime> r2 = ResultFactory.Fail<DateTime>("fake id", DateTime.Now, ResultFactory.BuildError("this is a test"));
Result<object> r3 = ResultFactory.FailFromResult<object,DateTime>(r2);
```

