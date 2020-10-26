// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akshay Poriya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Program class contains main function
    /// </summary>
    public class Program
    {
        /// <summary>
        /// addressBookMapper is a data structure used to store All AddressBooks created in the project
        /// which can be accessed with the help of their name
        /// </summary>
        private static readonly Dictionary<string, AddressBook> addressBookMapper = new Dictionary<string, AddressBook>();

        /// <summary>
        /// cityToContactMapperGlobal is a variable which store all contacts with their city names
        /// </summary>
        public static readonly Dictionary<string, List<Contact>> cityToContactMapperGlobal = new Dictionary<string, List<Contact>>();

        /// <summary>
        /// stateToContactMapperGlobal is a variable which store all contacts with their state names
        /// </summary>
        public static readonly Dictionary<string, List<Contact>> stateToContactMapperGlobal = new Dictionary<string, List<Contact>>();

        /// <summary>
        /// Defines the entry point of the application.
        /// Calls StartProgram function
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");
            StartProgram();
        }

        /// <summary>
        /// StartProgram function asks user about which activity to be done
        /// </summary>
        private static void StartProgram()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nEnter 1 to add New Address Book \nEnter 2 to Add Contacts \nEnter 3 to Edit Contacts " +
                    "\nEnter 4 to Delete Contacts\nEnter 5 to search contact using city name" +
                    "\nEnter 6 to search contact using state name\nEnter 7 to view contact details by city name" +
                    "\nEnter 8 to view contact details by state name\nEnter 9 to get number of contacts by city" +
                    "\nEnter 10 to get number of contacts by state\nEnter 11 to view AddressBooks in sorted order" +
                    "\nEnter any other key to exit");
                string options = Console.ReadLine();
                switch (options)
                {
                    case "1":
                        AddAddressBook();
                        break;
                    case "2":
                        AddContactsInAddressBook();
                        break;
                    case "3":
                        EditDetailsOfAddressBook();
                        break;
                    case "4":
                        DeleteContactsOfAddressBook();
                        break;
                    case "5":
                        SearchContactWithCityName();
                        break;
                    case "6":
                        SearchContactWithStateName();
                        break;
                    case "7":
                        ViewContactByCityName();
                        break;
                    case "8":
                        ViewContactByStateName();
                        break;
                    case "9":
                        NumberOfContactsByCityName();
                        break;
                    case "10":
                        NumberOfContactsByStateName();
                        break;
                    case "11":
                        ViewInSortedOrder();
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }

        /// <summary>
        /// View Contacts in sorted order.
        /// </summary>
        public static void ViewInSortedOrder()
        {
            Console.WriteLine("Enter a for Sort by person name\nEnter b for sort by city name" +
                "\nEnter c for sort by state name\nEnter d for sort by zip code\nPress any other key to exit");
            string options = Console.ReadLine();
            string orderBy = "name";
            switch (options)
            {
                case "a":
                    orderBy = "name";
                    break;
                case "b":
                    orderBy = "city";
                    break;
                case "c":
                    orderBy = "state";
                    break;
                case "d":
                    orderBy = "zip";
                    break;
                default:
                    return;
            }
            foreach (KeyValuePair<string, AddressBook> pair in addressBookMapper)
            {
                Console.WriteLine("************************************************");
                Console.WriteLine("Details of AddressBook with Name: " + pair.Key);
                pair.Value.ViewEntriesInSortedOrder(orderBy);
            }
        }

        /// <summary>
        /// AddAddressBook function is called when user want to create new AddressBook
        /// </summary>
        private static void AddAddressBook()
        {
            Console.WriteLine("\nEnter Name for the New Address Book");
            string name = Console.ReadLine();
            if (addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("Address Book Already exist with this name");
            }
            else
            {
                AddressBook addressBook = new AddressBook();
                addressBookMapper.Add(name, addressBook);
            }
        }

        /// <summary>
        /// AddContactsInAddressBook is called when user ask to enter new contact details in any AddressBook
        /// </summary>
        private static void AddContactsInAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to add new contact");
            string name = Console.ReadLine();
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, AddressBook> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                AddressBook addressBook = addressBookMapper[name];
                addressBook.AddContacts();
            }
        }

        /// <summary>
        /// EditDetailsOfAddressBook is called when a user ask to modify Contact details in a AddressBook
        /// </summary>
        private static void EditDetailsOfAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to modify contact details");
            string name = Console.ReadLine();
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, AddressBook> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                AddressBook addressBook = addressBookMapper[name];
                addressBook.EditDetails();
            }
        }

        /// <summary>
        /// DeleteContactsOfAddressBook is called when user want to delete a particular contact from a AddressBook
        /// </summary>
        private static void DeleteContactsOfAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to delete contact details");
            string name = Console.ReadLine();
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, AddressBook> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                AddressBook addressBook = addressBookMapper[name];
                addressBook.DeleteContact();
            }
        }

        /// <summary>
        /// Searches the name of the contact with city.
        /// </summary>
        private static void SearchContactWithCityName()
        {
            Console.WriteLine("\nEnter full name of the person!");
            string personName = Console.ReadLine();
            Console.WriteLine("\nEnter name of the city!");
            string cityName = Console.ReadLine();
            if (!cityToContactMapperGlobal.ContainsKey(cityName))
            {
                Console.WriteLine("No record found with such city name!");
                return;
            }
            foreach (Contact contact in cityToContactMapperGlobal[cityName])
            {
                if ((contact.firstName + " " + contact.lastName) == personName)
                {
                    Console.WriteLine("Contact found!");
                    Console.WriteLine("FirstName: " + contact.firstName + "\nLast Name :" + contact.lastName);
                    Console.WriteLine("Address: " + contact.address + "\nCity: " + contact.city);
                    Console.WriteLine("State: " + contact.state + "\nZip: " + contact.zip);
                    Console.WriteLine("Phone Number: " + contact.phoneNumber + "\nEmail: " + contact.email);
                    return;
                }
            }
            Console.WriteLine($"No Contact Exist With This Name!");
        }

        /// <summary>
        /// Searches the name of the contact with state.
        /// </summary>
        private static void SearchContactWithStateName()
        {
            Console.WriteLine("\nEnter full name of the person!");
            string personName = Console.ReadLine();
            Console.WriteLine("\nEnter name of the state!");
            string stateName = Console.ReadLine();
            if (!stateToContactMapperGlobal.ContainsKey(stateName))
            {
                Console.WriteLine("No record found with this state name!");
                return;
            }
            foreach (Contact contact in stateToContactMapperGlobal[stateName])
            {
                if ((contact.firstName + " " + contact.lastName) == personName)
                {
                    Console.WriteLine("Contact found!");
                    Console.WriteLine("FirstName: " + contact.firstName + "\nLast Name :" + contact.lastName);
                    Console.WriteLine("Address: " + contact.address + "\nCity: " + contact.city);
                    Console.WriteLine("State: " + contact.state + "\nZip: " + contact.zip);
                    Console.WriteLine("Phone Number: " + contact.phoneNumber + "\nEmail: " + contact.email);
                    return;
                }
            }
            Console.WriteLine($"No Contact Exist With This Name!");
        }

        /// <summary>
        /// Views the name of the contact by city.
        /// </summary>
        public static void ViewContactByCityName()
        {
            Console.WriteLine("\nEnter name of the city!");
            string cityName = Console.ReadLine();
            if (!cityToContactMapperGlobal.ContainsKey(cityName))
            {
                Console.WriteLine("No record found with such city name!");
                return;
            }
            foreach (Contact contact in cityToContactMapperGlobal[cityName])
            {
                Console.WriteLine("FirstName: " + contact.firstName + "\nLast Name :" + contact.lastName);
                Console.WriteLine("Address: " + contact.address + "\nCity: " + contact.city);
                Console.WriteLine("State: " + contact.state + "\nZip: " + contact.zip);
                Console.WriteLine("Phone Number: " + contact.phoneNumber + "\nEmail: " + contact.email);
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Views the name of the contact by state.
        /// </summary>
        public static void ViewContactByStateName()
        {
            Console.WriteLine("\nEnter name of the State!");
            string stateName = Console.ReadLine();
            if (!cityToContactMapperGlobal.ContainsKey(stateName))
            {
                Console.WriteLine("No record found with such state name!");
                return;
            }
            foreach (Contact contact in stateToContactMapperGlobal[stateName])
            {
                Console.WriteLine("FirstName: " + contact.firstName + "\nLast Name :" + contact.lastName);
                Console.WriteLine("Address: " + contact.address + "\nCity: " + contact.city);
                Console.WriteLine("State: " + contact.state + "\nZip: " + contact.zip);
                Console.WriteLine("Phone Number: " + contact.phoneNumber + "\nEmail: " + contact.email);
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Numbers the name of the of contacts by city.
        /// </summary>
        public static void NumberOfContactsByCityName()
        {
            Console.WriteLine("\nEnter name of the city!");
            string cityName = Console.ReadLine();
            if (!cityToContactMapperGlobal.ContainsKey(cityName))
            {
                Console.WriteLine("No of Contacts: 0");
                return;
            }
            Console.WriteLine("No of Contacts: " + cityToContactMapperGlobal[cityName].Count);
        }

        /// <summary>
        /// Numbers the name of the of contacts by state.
        /// </summary>
        public static void NumberOfContactsByStateName()
        {
            Console.WriteLine("\nEnter name of the state!");
            string stateName = Console.ReadLine();
            if (!stateToContactMapperGlobal.ContainsKey(stateName))
            {
                Console.WriteLine("No of Contacts: 0");
                return;
            }
            Console.WriteLine("No of Contacts: " + stateToContactMapperGlobal[stateName].Count);
        }
    }
}