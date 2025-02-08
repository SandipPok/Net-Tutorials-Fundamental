using System.Reflection;

namespace GenericsConstriants
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Accept Reference Type
            GenericConstraintClass<Country> genericClass = new GenericConstraintClass<Country>(new Country()
            {
                Name = "Nepal",
                Continent = "Asia"
            });
            genericClass.Execute();

            // Accept Value Type
            GenericConstraintStruct<int> genericStruct = new GenericConstraintStruct<int>(40);
            genericStruct.Execute();

            // Accept Default Parameters Only
            GenericConstraintNew<Country> genericNew = new GenericConstraintNew<Country>();

            var obj1 = new Country()
            {
                Name = "Nepal",
                Continent = "Asia"
            };
            genericNew.Execute(obj1, obj1);

            // Use type of inherit baseClase
            GenericConstraintBaseClass<Country> genericConstraintBaseClass = new GenericConstraintBaseClass<Country>();
            var obj2 = new Country()
            {
                Name = "Nepal",
                Continent = "Asia"
            };
            genericConstraintBaseClass.Execute(obj2, obj2);

            // Use type of interface
            GenericConstraintInherit<Country> genericConstraintInherit = new GenericConstraintInherit<Country>();
            genericConstraintInherit.Execute(obj2, obj2);

            // Implement the IEmployee Interface i.e. T Implements U
            GenericConstraintTU<Country, ICountry> genericClassTU = new GenericConstraintTU<Country, ICountry>();
            genericClassTU.Execute(obj2, obj2);

            // Implement with multiple generic constraint
            GenericConstraintMultiple<Country, int> genericConstraintMultiple = new GenericConstraintMultiple<Country, int>();
            genericConstraintMultiple.Execute(obj2, 6);
        }
    }

    interface ICountry { }

    class BaseCountry { }

    class Country : BaseCountry, ICountry
    {
        public string Name { get; set; }
        public string Continent { get; set; }
    }
    class People
    {
        public People(string lang, int popu)
        {
            Language = lang;
            Population = popu;
        }
        public string Language { get; set; }
        public int Population { get; set; }
    }

    class GenericConstraintClass<T> where T : class
    {
        public T _message;
        public GenericConstraintClass(T message)
        {
            _message = message;
        }

        public void Execute()
        {
            //Console.WriteLine(_message);

            Type messageType = _message.GetType();

            PropertyInfo[] properties = messageType.GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(_message);
                Console.WriteLine($"{property.Name}: {value}");
            }
        }
    }

    class GenericConstraintStruct<T> where T : struct
    {
        public T _message;
        public GenericConstraintStruct(T message)
        {
            _message = message;
        }

        public void Execute()
        {
            Console.WriteLine(_message);
        }
    }

    class GenericConstraintNew<T> where T : new()
    {
        public T _message;
        public void Execute(T Param1, T Param2)
        {
            Console.WriteLine($"Message: {_message}");
            Console.WriteLine($"Param1: {Param1}");
            Console.WriteLine($"Param2: {Param2}");
        }
    }

    class GenericConstraintBaseClass<T> where T : BaseCountry
    {
        public T _message;
        public void Execute(T param1, T param2)
        {
            Console.WriteLine($"Message: {_message}");
            Console.WriteLine($"Param1: {param1}");
            Console.WriteLine($"Param2: {param2}");
        }
    }

    class GenericConstraintInherit<T> where T : ICountry
    {
        public T _message;
        public void Execute(T param1, T param2)
        {
            Console.WriteLine($"Message: {_message}");
            Console.WriteLine($"Param1: {param1}");
            Console.WriteLine($"Param2: {param2}");
        }
    }

    class GenericConstraintTU<T, U> where T : U
    {
        public T _message;
        public void Execute(T param1, T param2)
        {
            Console.WriteLine($"Message: {_message}");
            Console.WriteLine($"Param1: {param1}");
            Console.WriteLine($"Param2: {param2}");
        }
    }

    class GenericConstraintMultiple<T, X> where T : class where X : struct
    {
        public T _message;
        public void Execute(T param1, X param2)
        {
            Console.WriteLine($"Message: {_message}");
            Console.WriteLine($"Param1: {param1}");
            Console.WriteLine($"Param2: {param2}");
        }
    }
}