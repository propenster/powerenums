# Power Enums - a simple Option<Type> implementation for C#
Power enums lets you have Some<T> and None in C# as a representation of optional types. This is like Rust's Option<T> enum type which I think it's brilliant.

### Where can I get it?

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [PowerEnums](https://www.nuget.org/packages/PowerEnums/) from the package manager console:

```
PM> Install-Package PowerEnums
```
Or from the .NET CLI as:
```
dotnet add package PowerEnums
```

### How do I get started?

The library supports .NET Core 3.1 and above. Install the NUGET package as directed above, then you can use it like below:

**Simple Option - Some<T>**
```csharp
int value = 50;
var option = new Some<int>(value);
Console.WriteLine(option?.ValueOrDefault());

Assert.Equal(value, option?.ValueOrDefault());
Assert.NotNull(option);
Assert.IsType<Some<int>>(option);
Assert.IsType<int>(option?.ValueOrDefault());
```

**Simple Option - None<T>**
```csharp
var noneReturningOption = new None<int>();
Assert.NotNull(noneReturningOption);
Assert.Equal(0, noneReturningOption?.ValueOrDefault());
Assert.Equal(0, noneReturningOption?.Value);
Assert.Equal(false, noneReturningOption?.IsSome());
Assert.Equal(true, noneReturningOption?.IsNone());
Assert.IsType<None<int>>(noneReturningOption);
//it doesn't lose it's enclosed primitive type though it still came as None
Assert.IsType<int>(noneReturningOption?.ValueOrDefault()); 
Assert.IsAssignableFrom<int>(noneReturningOption?.ValueOrDefault()); 
```

**Option-returning methods Option<T>**
```csharp
private static Option<decimal> DecimalReturningOptionMethod()
{
decimal d = decimal.MaxValue;
return new Some<decimal>(d);
}

private Option<Person> GetPerson_Some_Or_None()
{
var person = new Person { Name = "Willelm Rudenmalm", Age = 28 };
return new Some<Person>(person) ?? new None<Person>();
}
```

**Option<T>().ValueOrError() with error message**
```csharp
var option = new None<int>();
Assert.Throws<Exception>(() => option.ValueOrError("Error could not retrieve item , item is null or default"));
```

**Option<T>().ValueOrError() with error callback**
```csharp
var option = new None<int>();
Assert.Throws<MyCustomException>(() => option.ValueOrError(() => throw new MyCustomException("Error could not find item")));
```

**Check IsSome() or IsNone()**
```csharp
var option = new Some<double>(2.58);
if(option.IsSome()){
Console.WriteLine($"Option is Some and it's value is {option.ValueOrDefault()}");
//OR destroy everything.
var valueOrMakeAMess = option.ValueOrError("This double is supposed to be here now I'm going to have to throw an exception"); //without saying, this throws a bomb (an Exception)
//OR pass an Exception callback with your own customer Exception
var valueOrMakeAMess = option.ValueOrError(() => throw new YourMessyCustomException("You must never not have this double")); //without saying, this throws a bomb (a YourMessyCustomException)
}else{
Console.WriteLine("Option is None");
}
```



