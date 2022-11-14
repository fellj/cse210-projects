using System;
using Unit04.Inheritance;


namespace Unit04
{
    
    class Program
    {
       

        static void Main(string[] args)
        {
           Person person1 = new Person();
           person1.SetFirstName("Lisa");
           person1.SetLastName("Fell");
           //person1.SetCalling("YW President"); //Person doesn't have method Set Calling 

           Person person2 = new Person();
           person2.SetFirstName("John");
           person2.SetLastName("Fell");

           Person person3 = new Person();
           person3.SetFirstName("Zoey");
           person3.SetLastName("Josephine");

           Person person4 = new Person();
           person4.SetFirstName("Henry");
           person4.SetLastName("Harrison");

           Person person5 = new Person();
           person5.SetFirstName("Blair");
           person5.SetLastName("Elizabeth");


           Console.WriteLine(person1.GetFullName());
           Console.WriteLine(person2.GetFullName());
           Console.WriteLine($"{person1.GetFirstName()} and {person2.GetFullName()} have 3 cute children named {person3.GetFullName()}, {person4.GetFullName()} and {person5.GetFullName()}");

           ChurchMember member1 = new ChurchMember();
           member1.SetFirstName("Sweet ");
           member1.SetLastName("Pea");
           member1.SetCalling("YW President");

           ChurchMember member2 = new ChurchMember();
           member2.SetFirstName("Johnny ");
           member2.SetLastName("William");
           member2.SetCalling("Ward Clerk");
           
           Console.WriteLine ($"{member2.GetFullName()} is the {member2.GetCalling()} in the Park Glen 2nd Ward");
           Console.WriteLine($"{member1.GetFullName()} is the {member1.GetCalling()} in our ward");


        }
    }
}