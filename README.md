Building Supportable Systems
----------------------------

Part 1 - Package Management
---------------------------

```
Install-Package Humanizer
```

```
int someNumber = 1234;
Console.WriteLine(someNumber.ToWords());
Console.WriteLine();

DateTime now = DateTime.Now;
DateTime nowish = now.AddSeconds(-4);

Console.WriteLine(now.Humanize(false));
Console.WriteLine(nowish.Humanize(false));
Console.WriteLine();

string elephant = "Elephant";
Console.WriteLine(elephant.Pluralize());
Console.WriteLine();

string errorText = "errors";

Console.WriteLine(errorText.ToQuantity(0));
Console.WriteLine(errorText.ToQuantity(1));
Console.WriteLine(errorText.ToQuantity(2));

Console.WriteLine(errorText.ToQuantity(3, ShowQuantityAs.Words));
```

Part 2 - Logging
----------------

```
Install-Package Serilog
```

```
Log.Logger = new LoggerConfiguration()
    .WriteTo.ColoredConsole()
    .WriteTo.RollingFile(@”C:\Jobs\Logs\Log-{Date}.txt")
    .CreateLogger();

var order = new { Id = 123, CustomerId = "JG”, Total = 123.5 };

var customer = new Customer { Id = "JG", Name = "John" };
 
Log.Information("Processed order {orderId} by {@customer}", order.Id, customer);
```

Part 3 - Log Management
-----------------------

```
Install-Package Serilog
Install-Package Serilog.Sinks.Seq
```


Part 4 - Metrics
----------------

```
Install-Package Metrics.Net
```

```
Metric.Config
    .WithHttpEndpoint("http://localhost:1234/")
    .WithAllCounters();

private readonly Timer timer = Metric.Timer("Requests", Unit.Requests);
private readonly Counter counter = 	Metric.Counter("ConcurrentRequests", Unit.Requests);

public void Process(string inputString)
{
    this.counter.Increment();
    using (this.timer.NewContext())
    {
        // do something to time
		System.Threading.Thread.Sleep(1230);
    }
    this.counter.Decrement();
}
```

Part 5 - Monitoring
-------------------

```
Install-Package Metrics.Net
```

```
public class DatabaseHealthCheck : HealthCheck
{
    private readonly IDatabase database;
    public DatabaseHealthCheck(IDatabase database)
        : base("DatabaseCheck")
    {
        this.database = database;
        HealthChecks.RegisterHealthCheck(this);
    }

    protected override HealthCheckResult Check()
    {
        // exceptions will be caught and 
        // the result will be unhealthy
        this.database.Ping();
        return HealthCheckResult.Healthy();
    }
}
```

Part 6 - Diagnostics
--------------------

```
Install-Package Glimpse
Install-Package Glimpse.AspNet
Install-Package Glimpse.Mvc5
Install-Package Glimpse.EF6
Install-Package Glimpse-Knockout
```


Part 7 - Unit Testing
---------------------

```
Install-Package NUnit
Install-Package Shouldly
```

```
[TestFixture]
public class TestClass
{
    [TestCase]
    public void AddTest()
    {
        MathsHelper helper = new MathsHelper();
        int result = helper.Add(20, 10);
        Assert.AreEqual(30, result);
    }

    [TestCase]
    public void SubtractTest()
    {
        MathsHelper helper = new MathsHelper();
        int result = helper.Subtract(20, 10);
        Assert.AreEqual(10, result);
    }
}

[Test]
public void ShouldBe()
{
    var theSimpsonsCat = new Cat() { Name = "Santas… helper" };
    theSimpsonsCat.Name.ShouldBe("Snowball 2");
}
```

Part 8 - Testability (IOC)
--------------------------

```
Install-Package Autofac
```

```
var builder = new ContainerBuilder();
 
// Register individual components
builder.RegisterInstance(new TaskRepository)
       .As<ITaskRepository>();

builder.RegisterType<TaskController>();

builder.Register(c => new LogManager())
       .As<ILogger>();
 
// Scan an assembly for components
builder.RegisterAssemblyTypes(myAssembly)
       .Where(t => t.Name.EndsWith("Repository"))
       .AsImplementedInterfaces();
 
var container = builder.Build();
```

```
public class MissileController
{
  private IMissileSilo _silo;
  private ILogger _logger;

  // These ctor parameters will be automatically injected 
  public MissileController(
    IMissileSilo silo,
    ILogger logger)
  {
    this._silo = silo;
    this._logger = logger;
  }
}
```

```
using (var container = builder.Build())
{
  var controller = container.Resolve<MissileController>();
  controller.FireZeMissiles();
}
```
