Building Supportable Systems
----------------------------

Part 1 - Package Management
---------------------------
http://shawinnes.com/building-supportable-systems/

```powershell
Install-Package Humanizer
```

```csharp
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

We can also create our own NuGet packages.  I'm going to create a package to contain all the dependencies for the rest of these samples:
 
```xml
<?xml version="1.0"?>
<package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
  <metadata>
    <id>Supportable</id>
    <version>1.0.0</version>
    <title>Supportable</title>
    <authors>Shaw Innes</authors>
    <owners>Shaw Innes</owners>
    <description>Some NuGet dependencies for supportable software systems</description>
    <language>en-US</language>
	<dependencies>
		<dependency id="Autofac" version="3.5.2" />
		<dependency id="Humanizer" version="1.31.0" />
		<dependency id="Serilog" version="1.4.39" />
		<dependency id="Serilog.Sinks.Seq" version="1.4.39" />
		<dependency id="Metrics.NET" version="0.2.12" />
	</dependencies>
  </metadata>
  <files>
	<file src="SupportableBootstrapper.txt" target="content" /> 
  </files>
</package>
```

Then you can build a package using

```
Microsoft Windows [Version 6.3.9600]
(c) 2013 Microsoft Corporation. All rights reserved.

C:\SupportableSoftware> nuget pack Supportable.nuspec
Attempting to build package from 'Supportable.nuspec'.
Successfully created package 'C:\SupportableSoftware\Supportable.1.0.0.nupkg'.
```

This package can then be uploaded to a nuget feed server, or just placed into a local folder and consumed in other projects:

```
Install-Package Supportable
```

Part 2 - Logging
----------------

```powershell
Install-Package Serilog
```

```csharp
Log.Logger = new LoggerConfiguration()
    .WriteTo.ColoredConsole()
    .CreateLogger();

// ...

Log.Information("Processed order {@order}", order);
```

Part 3 - Log Management
-----------------------

```powershell
Install-Package Serilog
Install-Package Serilog.Sinks.Seq
```

```csharp
Log.Logger = new LoggerConfiguration()
    .WriteTo.ColoredConsole()
    .WriteTo.Seq("http://localhost:5341/")
    .Enrich.WithProperty("ComputerName", System.Net.Dns.GetHostName())
    .Enrich.FromLogContext()
    .CreateLogger();

// ...

using (LogContext.PushProperty("CorrelationId", Guid.NewGuid()))
{
	Log.Information("Processed order {@order}", order);
}
```

Part 4 - Metrics
----------------

```powershell
Install-Package Metrics.Net
```

```csharp
Metric.Config
    .WithHttpEndpoint("http://localhost:1234/metrics/")
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

```powershell
Install-Package Metrics.Net
```

```csharp
Metric.Config
    .WithHttpEndpoint("http://localhost:1234/metrics/")
    .WithAllCounters();

HealthChecks.RegisterHealthCheck(new FileHealthCheck());
HealthChecks.RegisterHealthCheck(new DiskSpaceHealthCheck());
```

```csharp
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

Part 6 - Debugging & Diagnostics
--------------------

```powershell
Install-Package Glimpse
Install-Package Glimpse.AspNet
Install-Package Glimpse.Mvc5
Install-Package Glimpse.EF6
Install-Package Glimpse-Knockout
```

Part 7 - Modularity & Testability
---------------------------------

```powershell
Install-Package Autofac
```

```csharp
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

```csharp
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

```csharp
using (var container = builder.Build())
{
  var controller = container.Resolve<MissileController>();
  controller.FireZeMissiles();
}
```

Part 8 - Unit Tests
-------------------

```powershell
Install-Package NUnit
Install-Package Shouldly
```

```csharp
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

Part 9 - Convention Tests
--------------------------

```powershell
Install-Package TestStack.ConventionTests
Install-Package Enforcer
```

Part 10 - Acceptance Tests
--------------------------

```powershell
Install-Package Specflow
```

Part 11 - Approval Tests
-----------------------

```powershell
Install-Package ApprovalTests
```

Part 12 - Automation Tests
--------------------------

```powershell
Install-Package AFrame.Web
Install-Package AFrame.Desktop
```

http://aframe.github.io/


Part 13 - Exception Handling
----------------------------

```powershell
Install-Package Polly
```

Part 14 - Service Stubs
----------------------

```powershell
Install-Package Stubby
```

```csharp
class Program
{
    static void Main(string[] args)
    {
        Stubby stubby = new Stubby(new Arguments
        {
            Data = "stubby.yaml",
            Mute = false
        });

        stubby.Start();
    }
}
```

```yaml
- request:
    url: /hello
    method: GET
  response:
      status: 200
      latency: 1800
      headers:
         content-type: application/xml
         server: stubbedServer/4.2
      body: >
         <!xml >
         <responseXML>
            <content></content>
         </responseXML>
-  request:
      url: /json
      method: GET
   response:
      status: 200
      latency: 120
      headers:
         content-type: application/json
         server: IIS/8.5
      body: > 
        { "response" : "OK" }

```

Part 15 - API Documentation
---------------------------

```powershell
Install-Package Swashbuckle.Core
```

OWIN Startup.cs
```csharp
    config
    .EnableSwagger(c =>
    {
        c.SingleApiVersion("v1", "API Name");

        c.BasicAuth("basic")
            .Description("Basic HTTP Authentication");

        c.ApiKey("apiKey")
            .Description("API Key Authentication")
            .Name("apiKey")
            .In("header");

        c.IncludeXmlComments(@"SwaggerDemo.XML");
    })
    .EnableSwaggerUi();
```