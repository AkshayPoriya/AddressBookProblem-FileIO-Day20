// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileIOOperations.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akshay Poriya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    class FileIOOperations
    {

        /// <summary>
        /// Writes the data to text file.
        /// Store all contact details from address book directory to AddressBookDirectory.txt file
        /// </summary>
        public static void AppendContactDetailsToTextFile()
        {
            try
            {
                string path = @"G:\Programming\Bridge Labz\04 C# IO Streams\01_AddressBookProblem_FileIO\AddressBookSystem\AddressBookDirectory.txt";
                
                using (StreamWriter sr = File.AppendText(path))
                {
                    sr.WriteLine($"\n\n******************* New Data Added *******************\n");
                    foreach (KeyValuePair<string, AddressBook> pair in AddressBookDirectory.addressBookMapper)
                    {
                        sr.WriteLine($"\n******************* AddressBook: {pair.Key} *******************\n");
                        sr.WriteLine("Number of contacts: " + pair.Value.contactList.Count);
                        sr.WriteLine("----------------Contact Details----------------");
                        int contactCount = 1;
                        foreach (Contact contact in pair.Value.contactList)
                        {
                            sr.WriteLine(contactCount + ".");
                            sr.WriteLine("First Name:\t" + contact.firstName);
                            sr.WriteLine("Last Name:\t" + contact.lastName);
                            sr.WriteLine("Address:\t" + contact.address);
                            sr.WriteLine("City:\t" + contact.city);
                            sr.WriteLine("State:\t" + contact.state);
                            sr.WriteLine("ZIP:\t" + contact.zip);
                            sr.WriteLine("Phone Number:\t" + contact.phoneNumber);
                            sr.WriteLine("Email:\t" + contact.email + "\n");
                            contactCount++;
                        }
                    }
                    sr.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }

        /// <summary>
        /// Reads the data from AddressBookDirectory.txt file.
        /// </summary>
        public static void ReadContactDetailsFromTextFile()
        {
            try
            {
                string path = @"G:\Programming\Bridge Labz\04 C# IO Streams\01_AddressBookProblem_FileIO\AddressBookSystem\AddressBookDirectory.txt";
                if (!File.Exists(path))
                {
                    Console.WriteLine("File doesn't exist!");
                    return;
                }

                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }
    }
}
