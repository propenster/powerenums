using Newtonsoft.Json.Linq;

namespace PowerEnums.Test
{
    public class TestClass
    {
        [Fact]
        public void Test_Option()
        {
            int value = 50;
            var option = new Some<int>(value);
            Console.WriteLine(option?.ValueOrDefault());


            Assert.Equal(value, option?.ValueOrDefault());
            Assert.NotNull(option);
            Assert.IsType<Some<int>>(option);
            Assert.IsType<int>(option?.ValueOrDefault());

        }
        [Fact]
        public void Test_Option_Returns_Int()
        {
            var callOption = IntReturningOptionMethod();
            Console.WriteLine($"Value from Option-returning method call >>> {callOption.ValueOrDefault()}");


            var decimalOption = DecimalReturningOptionMethod();
            Console.WriteLine($"Decimal-returning Option >>> {decimalOption?.ValueOrDefault()}");
            Console.WriteLine($"DecimalOption is Some Type == {decimalOption?.IsSome()}");

            
            //var valueOrError = noneReturning.ValueOrError("Could not retrieve item value");

            Assert.NotNull(callOption);
            Assert.Equal(59, callOption?.ValueOrDefault());
            Assert.Equal(59, callOption?.Value);
            Assert.Equal(true, callOption?.IsSome());
            Assert.Equal(false, callOption?.IsNone());
            Assert.IsType<Some<int>>(callOption);
            Assert.IsType<int>(callOption?.ValueOrDefault());




        }
        [Fact]
        public void Test_Option_Returns_Decimal()
        {
            var decimalOption = DecimalReturningOptionMethod();
            Console.WriteLine($"Decimal-returning Option >>> {decimalOption?.ValueOrDefault()}");
            Console.WriteLine($"DecimalOption is Some Type == {decimalOption?.IsSome()}");

            var noneReturning = NoneReturningMethod();
            if (noneReturning.IsNone())
            {
                Console.WriteLine("No value... Option variant is None");
            }
            //var valueOrError = noneReturning.ValueOrError("Could not retrieve item value");


            Assert.NotNull(decimalOption);
            Assert.Equal(decimal.MaxValue, decimalOption?.ValueOrDefault());
            Assert.Equal(decimal.MaxValue, decimalOption?.Value);
            Assert.Equal(true, decimalOption?.IsSome());
            Assert.Equal(false, decimalOption?.IsNone());
            Assert.IsType<Some<decimal>>(decimalOption);
            Assert.IsType<decimal>(decimalOption?.ValueOrDefault());
        }
        [Fact]
        public void TestOption_None()
        {
            var noneReturningOption = NoneReturningMethod();
            if (noneReturningOption.IsNone())
            {
                Console.WriteLine("No value... Option variant is None");
            }

            Assert.NotNull(noneReturningOption);
            Assert.Equal(0, noneReturningOption?.ValueOrDefault());
            Assert.Equal(0, noneReturningOption?.Value);
            Assert.Equal(false, noneReturningOption?.IsSome());
            Assert.Equal(true, noneReturningOption?.IsNone());
            Assert.IsType<None<int>>(noneReturningOption);
            //it doesn't lose it's enclosed primitive type though it still came as None
            Assert.IsType<int>(noneReturningOption?.ValueOrDefault()); 
            Assert.IsAssignableFrom<int>(noneReturningOption?.ValueOrDefault()); 
        }
        [Fact]
        public void Test_Option_With_More_Complex_Types_Some()
        {
            var personOption = GetPerson_Some();
            Assert.NotNull(personOption);
            Assert.Equal(28, personOption?.ValueOrDefault()?.Age);
            Assert.Contains("Will", personOption?.ValueOrDefault()?.Name);
            Assert.Equal(true, personOption?.IsSome());
            Assert.Equal(false, personOption?.IsNone());
            Assert.IsType<Some<Person>>(personOption);
            Assert.IsType<Person>(personOption?.ValueOrDefault());

        }
        [Fact]
        public void Test_Option_With_More_Complex_Types_None()
        {
            var personOption = GetPerson_None();
            Assert.NotNull(personOption);        
            Assert.Equal(false, personOption?.IsSome());
            Assert.Equal(true, personOption?.IsNone());
            Assert.IsType<None<Person>>(personOption);
            //it came as None
            Assert.IsNotType<Person>(personOption?.ValueOrDefault());

        }
        [Fact]
        public void Test_Option_Value_Or_Error()
        {
            var option = new None<int>();

            Assert.Throws<Exception>(() => option.ValueOrError("Error could not retrieve item , item is null or default"));
        }
        [Fact]
        public void Test_Option_Value_Or_Error_Callback()
        {
            var option = new None<int>();
            Assert.Throws<MyCustomException>(() => option.ValueOrError(() => throw new MyCustomException("Error could not find item")));
        }
        private static Option<int> IntReturningOptionMethod()
        {
            return new Some<int>(59);
        }
        private static Option<decimal> DecimalReturningOptionMethod()
        {
            decimal d = decimal.MaxValue;
            return new Some<decimal>(d);
        }
        private static Option<int> NoneReturningMethod()
        {
            return new None<int>();
        }
        private Option<Person> GetPerson_Some()
        {
            var person = new Person { Name = "Willelm Ruddenmalm", Age = 28 };
            return new Some<Person>(person);
        }
        private Option<Person> GetPerson_None()
        {
            return new None<Person>();
        }
    }
}