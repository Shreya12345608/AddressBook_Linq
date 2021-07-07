using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address book linq problem!");
            AddressBook addressBook = new AddressBook();
            Contact contact = new Contact();

            int loop = 1;
            while (loop == 1)
            {
                Console.WriteLine("Enter your choice: \n1.Insert a new contact \n" +
                "2.Display existing contact" +
                " \n3.Edit existing contact " +
                " \n4.Delete existing contact " +
                 " \n5.Reterive Data From City" +
                   " \n6.Reterive Data From State" +
                " \n6.Exit.");
                int Selectchoice = Convert.ToInt32(Console.ReadLine());
                switch (Selectchoice)
                {
                    case 1:
                        addressBook.InsertContactToTable();
                        break;
                    case 2:
                        addressBook.DisplayDetails();
                        break;
                    case 3:
                        addressBook.EditExistingContact();
                        break;
                    case 4:
                        addressBook.DeleteContact("Shreya");
                        break;
                    case 5:
                        Console.WriteLine("Enter the city = ");
                        contact.City = Console.ReadLine();
                        addressBook.retrievePersonByUsingCity(contact);
                        break;
                    case 6:
                        Console.WriteLine("Enter the State = ");
                        contact.City = Console.ReadLine();
                        addressBook.retrievePersonByUsingState(contact);
                        break;
                    default:
                        Console.WriteLine("Please enter the valid number : ");
                        break;

                        Console.ReadKey();

                }
            }
        }
    }
}

