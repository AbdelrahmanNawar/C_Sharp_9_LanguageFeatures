using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

#region Top Level Calls
//// top level statements feature is useful for running scripts as it's .cs file to compile and there are no need for a project.
//// everything at the top level is inside the main method.
//var method = MethodBase.GetCurrentMethod();
//Console.WriteLine(method.DeclaringType.Namespace); // Nothing / Empty
//Console.WriteLine(method.DeclaringType.Name); // <Program>$ , it's not attached to the class's name or project's, and only one compilation unit can have top level statements
//Console.WriteLine(method.Name); // <Main>$

//Console.WriteLine("Hello World!");

//var x = 5;
//var y = 5;

//int Add(int x, int y)
//{
//return x + y;
//}

//Console.WriteLine(Add(x, y));

//Console.WriteLine(args.Length); // we have access to the args in this case: 0 

//await Task.CompletedTask; // it's normal

//return 1; // exited with code 1.

//public struct Person
//{
//    public int ID { get; set; }
//}

//public class Employee
//{
//    public string Name { get; set; }
//}

//public record FreeLancer(int age);

//// Add(x, y); // syntax error as top level instructions have to go before types
#endregion

namespace C_Sharp_9_LanguageFeatures
{
    #region Record Types
    // records turn into classes not structs
    //public record Address
    //{
    //    public int HouseNumber { get; set; }
    //    public string Street { get; set; }

    //    public Address() { }
    //    public Address(int houseNumber, string street)
    //    {
    //        HouseNumber = houseNumber;
    //        Street = street;
    //    }
    //}

    //public record Person
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //    public Address Address { get; set; }
    //    public List<int> PhoneNumbers { get; set; }
    //}

    //public record Math(int x, int y)
    //{
    //    public int Add()
    //    {
    //        return x + y;
    //    }
    //    public int Sub()
    //    {
    //        return x - y;
    //    }
    //    public int Mul()
    //    {
    //        return x * y;
    //    }
    //    public int Div()
    //    {
    //        return x / y;
    //    }
    //}

    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var p = new Person { Name = "Abdelrahman", Age = 26 };
    //        var p2 = new Person { Name = "Abdelrahman", Age = 26 };

    //        Console.WriteLine(p); // Person { Name = Abdelrahman, Age = 26, Address = , PhoneNumbers =  }
    //        Console.WriteLine(p == p2); // True, as it compares using its properties not the reference.

    //        p.Address = new(12345, "Sahrawy");
    //        p2.Address = new(12345, "Sahrawy");
    //        Console.WriteLine(p == p2); // True, even if properties are record types.
    //        p.PhoneNumbers = new List<int> { 111, 222 };
    //        p2.PhoneNumbers = new List<int> { 111, 222 };
    //        Console.WriteLine(p == p2); // false for properties of reference types.
    //        Console.WriteLine(typeof(Person).GetInterfaces()[0].Name);

    //        Math calculate = new Math(6, 2);
    //        Console.WriteLine(calculate.Add()); // 8
    //        Console.WriteLine(calculate.Sub()); // 4
    //        Console.WriteLine(calculate.Mul()); // 12
    //        Console.WriteLine(calculate.Div()); // 3
    //    }
    //}
    #endregion

    #region Positional Records
    //public record Point(int X, int Y);

    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var origin = new Point(2, 3);
    //        //positional records you can deconstruct them
    //        // Ex:
    //        var (x, y) = origin; // using Tuples

    //    }
    //}
    #endregion

    #region Change Properties In Records
    //public record Unchangeable(string name); // implicit syntax

    //public record Changeable // explicit syntax to define all properties with getters and setters
    //{
    //    public string Name { get; set; }
    //    public Changeable() { }
    //    public Changeable(string name)
    //    {
    //        Name = name;
    //    }
    //}

    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Unchangeable unchangeable = new Unchangeable("Value");
    //        // unchangeable.name = "Value"; // syntax error

    //        Changeable changeable = new Changeable("Value");
    //        Console.WriteLine(changeable.Name); // Value
    //        changeable.Name = "Another Value";
    //        Console.WriteLine(changeable.Name); // Another Value

    //        // unchangeable = new Unchangeable { name = "Name"}; 
    //        // syntax error as we can not use object initializer syntax with record types

    //        changeable = new Changeable { Name = "Name" };
    //        Console.WriteLine(changeable.Name); // Name

    //    }
    //}
    #endregion

    #region Record Inheritance
    //public record UnchangeableParent(string name);

    //public record ChangeableParent
    //{
    //    public string Name { get; set; }
    //    public ChangeableParent() { }
    //    public ChangeableParent(string name)
    //    {
    //        Name = name;
    //    }
    //}
    //public record UnchangeableInheritedFromUnchangeable(int age, string name) : UnchangeableParent(name);
    //public record UnchangeableInheritedFromChangeable(int age, string name) : ChangeableParent(name);
    //public record ChangeableInheritedFromUnchangeable : UnchangeableParent
    //{
    //    public int Age { get; set; }
    //    // public InheritedFromUnchangeable2() { } 
    //    // won't allow empty constructor cause parent property needs to be initialized
    //    public ChangeableInheritedFromUnchangeable(int age, string name)
    //    : base(name)
    //    {
    //        Age = age;
    //    }
    //}
    //public record ChangeableInheritedFromChangeable : ChangeableParent
    //{
    //    public int Age { get; set; }
    //    public ChangeableInheritedFromChangeable() { }
    //    public ChangeableInheritedFromChangeable(int age, string name)
    //    : base(name)
    //    {
    //        Age = age;
    //    }
    //}

    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        UnchangeableInheritedFromUnchangeable record1 = new UnchangeableInheritedFromUnchangeable(25, "Aly");
    //        // record1.age = 26; // syntax error
    //        // record1.name = "Omar"; // syntax error

    //        UnchangeableInheritedFromChangeable record2 = new UnchangeableInheritedFromChangeable(25, "Ahmed");
    //        // record2.age = 26; // syntax error
    //        // record2.name = "Mohamed"; // syntax error

    //        ChangeableInheritedFromUnchangeable record3 = new ChangeableInheritedFromUnchangeable(25, "Mahmoud");
    //        record3.Age = 26;
    //        // record3.name = "Hassan"; // syntax error

    //        ChangeableInheritedFromChangeable record4 = new ChangeableInheritedFromChangeable(25, "Ammar");
    //        record4.Age = 26;
    //        record4.Name = "Abdou";
    //    }
    //}
    #endregion

    #region With Expression
    //public record Color
    //{
    //    public string Name { get; set; }
    //    public bool IsMetallic { get; set; }
    //    public Color() { }
    //    public Color(string name, bool isMetallic)
    //    {
    //        Name = name;
    //        IsMetallic = isMetallic;
    //    }
    //}
    //public record Car
    //{
    //    public Color Color { get; set; }
    //    public string Engine { get; set; }
    //}

    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Car firstCar = new Car() { Color = new Color("Black", false), Engine = "V6" };
    //        Car upgradedCar = firstCar with { Engine = "V8" }; // Cloned and Modified.
    //        // But it performs Shallow copy with clone()
    //        upgradedCar.Color.IsMetallic = true;
    //        Console.WriteLine(firstCar);
    //        //car { Color = Color { Name = Black, IsMetallic = True }, Engine = V6 }
    //        Console.WriteLine(upgradedCar);
    //        //car { Color = Color { Name = Black, IsMetallic = True }, Engine = V8 }
    //    }
    //}
    #endregion

    #region Patter Matching Improvements
    //internal static class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        object o = null;
    //        //if(o != null)
    //        if(o is not null)
    //        {

    //        }

    //        //if(!(o is string))
    //        if(o is not string)
    //        {

    //        }

    //        int temperature = 6666;
    //        var feel = temperature switch // if not all cases handeled it will throw SwitchExpressionException cause it will fail if the input is 25 for example
    //        {
    //            < 0 => "freezing",
    //            // and
    //            >= 0 and < 20 => "tolerable",
    //            // >= 20 => "warm",
    //            // 600 => "hellish" // it's already handeled so it won't compile, so in order to do it we can do the following
    //            >= 20 and not 600 => "warm",
    //            // >= 20 and not 600 and not 6666 => "warm", // will except the exception for 6666
    //            // >= 20 and not (600 or 6666) => "warm", // will except the exception for 6666
    //            600 or 6666 => "hellish" // and it will compile fine
    //        };
    //        Console.WriteLine(feel); // it will compile and print "warm" cause cause it's already handeled int that condition
    //    }

    //    public static bool IsLetter(this char c) =>
    //        //(c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
    //        c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';
    //    // "and" has higher precedence than "or" so the "and" expression will get evaluated first then the "or" part

    //    public static bool IsLetterOrSeparator(this char c) =>
    //        c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or ';' or ','; 
    //    // we can use the parentheses but to make it readable as it won't change the input 
    //}
    #endregion

    #region Target-Type new
    //public class Person
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //    public Person() { }
    //    public Person(string name)
    //    {
    //        Name = name;
    //    }
    //    public Person(string name, int age)
    //    {
    //        Name = name;
    //        Age = age;
    //    }
    //}

    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Person person1 = new Person { Name = "john", Age = 25 };
    //        var person2 = new Person { Name = "john", Age = 25 };
    //        Person person3 = new() { Name = "John", Age = 25 }; // targe-typed new

    //        // possible but not readable
    //        Person person4;
    //        person4 = new();

    //        Person person5 = new("Mick");
    //        UsePerson(new());
    //        UsePerson(new("Phill"));
    //        UsePerson(new("Phill", 25));
    //    }

    //    public static void UsePerson(Person p)
    //    {
    //        //
    //    }

    //    public static Person MakePerson(string name, int age)
    //        // => new(name) { Age = age };
    //        // => new() { Name = name, Age = age };
    //        => new(name, age);
    //}
    #endregion
}
