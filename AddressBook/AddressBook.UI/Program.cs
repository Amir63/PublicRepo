using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Data;
using AddressBook.Models;

namespace AddressBook.UI
{
    class Program
    {


        static void Main(string[] args)
        {
            ContactRepository.deserializeFromXML();
            DisplayMenu();

        }

        static void DisplayMenu()
        {


            string menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("Address Book:");
                Console.WriteLine("---------------");
                Console.WriteLine("1. Display Contacts");
                Console.WriteLine("2. Load a contact");
                Console.WriteLine("3. Modify a contact");
                Console.WriteLine("4. Delete a contact");
                Console.WriteLine("5. Add a new contact");
                Console.WriteLine("6. Save Updated Contact List");

                Console.WriteLine("\nQ to quit");

                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        DisplayContacts();
                        break;
                    case "2":
                        LoadContact();
                        break;
                    case "3":
                        ModifyContact();
                        break;
                    case "4":
                        DeleteContact();
                        break;
                    case "5":
                        AddNewContact();
                        break;
                    case "6":
                        SaveContacts();
                        break;
                }


            } while (menuChoice.ToUpper() != "Q");

            Console.WriteLine("Do you want to Save? (Y):");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                SaveContacts();
            }




        }

        private static void SaveContacts()
        {
            ContactRepository.serializeToXML();
        }

        private static void ModifyContact()
        {

            int theID;
            string newText = "";

            //ask user for contact to modify
            do
            {
                Console.WriteLine("\n\nEnter the ID for the contact you wish to modify:");
            } while (!int.TryParse(Console.ReadLine(), out theID));

            ContactRepository repo = new ContactRepository();
            Contact modifiedContact = repo.LoadOne(theID);

            Console.WriteLine("Current values are in parenthesis.");
            Console.WriteLine("Press enter to keep current value.");
            Console.WriteLine("Enter a space to erase the value.");

            Console.WriteLine("First Name({0}): ", modifiedContact.FirstName);
            newText = Console.ReadLine();
            if (newText != "")
            {
                modifiedContact.FirstName = newText;
            }

            Console.WriteLine("Last Name ({0}): ", modifiedContact.LastName);
            newText = Console.ReadLine();
            if (newText != "")
            {
                modifiedContact.LastName = newText;
            }
            Console.WriteLine("Salutation ({0}): ", modifiedContact.Salutation);
            newText = Console.ReadLine();
            if (newText != "")
            {
                modifiedContact.Salutation = newText;
            }

            Console.WriteLine("");
            Console.WriteLine("Do you want to delete a phone number? (Press Y to Delete)");
            foreach (PhoneNumber thisPhoneNumber in modifiedContact.PhoneNumber)
            {

                Console.WriteLine("{0}: {1}-{2} x:{3}", thisPhoneNumber.Type, thisPhoneNumber.CountryCode, thisPhoneNumber.Number, thisPhoneNumber.Extension);
            }


            if (Console.ReadLine().ToUpper() == "Y")
            {
                foreach (PhoneNumber thisPhoneNumber in modifiedContact.PhoneNumber.ToArray())
                {
                    Console.Write("Do you want to delete {0}: {1}-{2} x:{3} ? (Press Y to Delete)", thisPhoneNumber.Type, thisPhoneNumber.CountryCode, thisPhoneNumber.Number, thisPhoneNumber.Extension);
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        modifiedContact.PhoneNumber.Remove(thisPhoneNumber);
                    }
                    Console.WriteLine(("---------------------------------"));
                }

            }



            Console.WriteLine();
            Console.WriteLine("Add a new phone number:");

            Console.WriteLine("");
            Console.WriteLine("Do you want to add a new phone number? (Press Y to Add)");
            foreach (PhoneNumber thisPhoneNumber in modifiedContact.PhoneNumber)
            {

                Console.WriteLine("{0}: {1}-{2} x:{3}", thisPhoneNumber.Type, thisPhoneNumber.CountryCode, thisPhoneNumber.Number, thisPhoneNumber.Extension);
            }


            if (Console.ReadLine().ToUpper() == "Y")
            {
                do
                {
                    PhoneNumber thisPhoneNumber = new PhoneNumber();
                    Console.WriteLine("Phone Number Type (1)Mobile, (2)Home, (3)Work, (4)Other:  ");
                    //newContact.PhoneNumber.Type = Console.ReadLine();
                    switch (Console.ReadLine())
                    {
                        case "1":
                            thisPhoneNumber.Type = PhoneType.Mobile;
                            break;
                        case "2":
                            thisPhoneNumber.Type = PhoneType.Home;
                            break;
                        case "3":
                            thisPhoneNumber.Type = PhoneType.Work;
                            break;
                        default:
                            thisPhoneNumber.Type = PhoneType.Other;
                            break;

                    }


                    Console.WriteLine("Phone Number Country Code: ");
                    thisPhoneNumber.CountryCode = Console.ReadLine();
                    Console.WriteLine("Phone Number: ");
                    thisPhoneNumber.Number = Console.ReadLine();
                    Console.WriteLine("Phone Number Extension: ");
                    thisPhoneNumber.Extension = Console.ReadLine();

                    modifiedContact.PhoneNumber.Add(thisPhoneNumber);
                    Console.WriteLine(("---------------------------------"));

                    Console.WriteLine("Do you want to add another Phone Number?");
                } while (Console.ReadLine().ToUpper() == "Y");

            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Modify existing phone numbers:");

            foreach (PhoneNumber thisPhoneNumber in modifiedContact.PhoneNumber)
            {
                Console.WriteLine("Phone Number Type {0}: \nModify List (1)Mobile, (2)Home, (3)Work, (4)Other: ", thisPhoneNumber.Type);
                newText = Console.ReadLine();
                if (newText != "")
                {
                    switch (newText)
                    {
                        case "1":
                            thisPhoneNumber.Type = PhoneType.Mobile;
                            break;
                        case "2":
                            thisPhoneNumber.Type = PhoneType.Home;
                            break;
                        case "3":
                            thisPhoneNumber.Type = PhoneType.Work;
                            break;
                        default:
                            thisPhoneNumber.Type = PhoneType.Other;
                            break;

                    }

                }

                Console.WriteLine("Phone Number Country Code: {0} ", thisPhoneNumber.CountryCode);
                newText = Console.ReadLine();
                if (newText != "")
                {
                    thisPhoneNumber.CountryCode = newText;
                }

                Console.WriteLine("Phone Number: {0} ", thisPhoneNumber.Number);
                newText = Console.ReadLine();
                if (newText != "")
                {
                    thisPhoneNumber.Number = newText;
                }

                Console.WriteLine("Phone Number Extension: {0} ", thisPhoneNumber.Extension);
                newText = Console.ReadLine();
                if (newText != "")
                {
                    thisPhoneNumber.Extension = newText;
                }
                Console.WriteLine(("---------------------------------"));
            }

            Console.WriteLine("*****Address*********");

            Console.WriteLine("");
            Console.WriteLine("Do you want to delete an address? (Press Y to Delete)");
            foreach (Address thisAddress in modifiedContact.Address)
            {

                Console.WriteLine("\n{0} Address:\n{1}\n{2},{3},{4}, {5},{6} ,\n{7} ", thisAddress.Type,
                    thisAddress.Street1, thisAddress.Street2, thisAddress.City, thisAddress.State, thisAddress.Zip,
                    thisAddress.County, thisAddress.Country);
            }


            if (Console.ReadLine().ToUpper() == "Y")
            {
                foreach (Address thisAddress in modifiedContact.Address.ToArray())
                {
                    Console.WriteLine("\n{0} Address:\n{1}\n{2},{3},{4}, {5},{6} ,\n{7} \n(Press Y to Delete): ", thisAddress.Type,
                    thisAddress.Street1, thisAddress.Street2, thisAddress.City, thisAddress.State, thisAddress.Zip,
                    thisAddress.County, thisAddress.Country);
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        modifiedContact.Address.Remove(thisAddress);
                    }
                    Console.WriteLine(("---------------------------------"));
                }

            }

            Console.WriteLine();
            Console.WriteLine("Add a new address:");

            Console.WriteLine("");
            Console.WriteLine("Do you want to add a new address? (Press Y to Add)");
            foreach (Address thisAddress in modifiedContact.Address)
            {

                Console.WriteLine("\n{0} Address:\n{1}\n{2},{3},{4}, {5},{6} ,\n{7} ", thisAddress.Type,
                    thisAddress.Street1, thisAddress.Street2, thisAddress.City, thisAddress.State, thisAddress.Zip,
                    thisAddress.County, thisAddress.Country);
            }


            if (Console.ReadLine().ToUpper() == "Y")
            {
                do
                {
                    Address thisAddress = new Address();

                    Console.WriteLine("Address Type: ");
                    thisAddress.Type = Console.ReadLine();
                    Console.WriteLine("Street1 : ");
                    thisAddress.Street1 = Console.ReadLine();
                    Console.WriteLine("Street2 : ");
                    thisAddress.Street2 = Console.ReadLine();
                    Console.WriteLine("City : ");
                    thisAddress.City = Console.ReadLine();
                    Console.WriteLine("State ");
                    thisAddress.State = Console.ReadLine();
                    Console.WriteLine("Zip Code ");
                    thisAddress.Zip = Console.ReadLine();
                    Console.WriteLine("County : ");
                    thisAddress.County = Console.ReadLine();
                    Console.WriteLine("Country: ");
                    thisAddress.Country = Console.ReadLine();

                    Console.WriteLine("Do you want to add another Address?");

                    modifiedContact.Address.Add(thisAddress);
                    Console.WriteLine(("---------------------------------"));
                } while (Console.ReadLine().ToUpper() == "Y");

            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Modify existing addresses:");


            foreach (Address thisAddress in modifiedContact.Address)
            {

                Console.WriteLine("Street1 : {0} ", thisAddress.Street1);
                newText = Console.ReadLine();
                if (newText != "")
                {
                    thisAddress.Street1 = newText;
                }
                Console.WriteLine("Street2 : {0} ", thisAddress.Street2);
                newText = Console.ReadLine();
                if (newText != "")
                {
                    thisAddress.Street2 = newText;
                }
                Console.WriteLine("City : {0} ", thisAddress.City);
                newText = Console.ReadLine();
                if (newText != "")
                {
                    thisAddress.City = newText;
                }

                Console.WriteLine("State : {0} ", thisAddress.State);
                newText = Console.ReadLine();
                if (newText != "")
                {
                    thisAddress.State = newText;
                }

                Console.WriteLine("Zip : {0} ", thisAddress.Zip);
                newText = Console.ReadLine();
                if (newText != "")
                {
                    thisAddress.Zip = newText;
                }


                Console.WriteLine("County : {0} ", thisAddress.County);
                newText = Console.ReadLine();
                if (newText != "")
                {
                    thisAddress.County = newText;
                }


                Console.WriteLine("Counrty : {0} ", thisAddress.Country);
                newText = Console.ReadLine();
                if (newText != "")
                {
                    thisAddress.Country = newText;
                }
                Console.WriteLine(("---------------------------------"));

            }



            Console.WriteLine("*****Email*********");
            Console.WriteLine("");
            Console.WriteLine("Do you want to delete an email? (Press Y to Delete)");
            foreach (Email thisEmail in modifiedContact.Email)
            {
                
                Console.WriteLine("{0}", thisEmail.EmailAddress);
            }
            

            if (Console.ReadLine().ToUpper() == "Y") 
            {
                foreach (Email thisEmail in modifiedContact.Email.ToArray())
                {
                    Console.Write("Do you want to delete {0} ? (Press Y to Delete)", thisEmail.EmailAddress);
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        modifiedContact.Email.Remove(thisEmail);
                    } 
                    Console.WriteLine(("---------------------------------"));
                }
               
            }

            Console.WriteLine();
            Console.WriteLine("Add a new email:");

            Console.WriteLine("");
            Console.WriteLine("Do you want to add an email? (Press Y to Add)");
            foreach (Email thisEmail in modifiedContact.Email)
            {

                Console.WriteLine("{0}", thisEmail.EmailAddress);
            }


            if (Console.ReadLine().ToUpper() == "Y")
            {
                do
                {
                    Email thisEmail = new Email();
                    Console.WriteLine("Email Type (Work, Home): ");
                    thisEmail.Type = Console.ReadLine();
                    Console.WriteLine("Email Address : ");

                    thisEmail.EmailAddress = Console.ReadLine();
                    modifiedContact.Email.Add((thisEmail));

                    Console.WriteLine("Do you want to add another email address?");
                } while (Console.ReadLine().ToUpper() == "Y");

            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine("Modify existing emails:");


            foreach (Email thisEmail in modifiedContact.Email)
            {
                Console.WriteLine("Email Type (Work, Home): {0} ", thisEmail.Type);
                newText = Console.ReadLine();
                if (newText != "")
                {
                    thisEmail.Type = newText;
                }

                Console.WriteLine("Email: {0} ", thisEmail.EmailAddress);
                newText = Console.ReadLine();
                if (newText != "")
                {
                    thisEmail.EmailAddress = newText;
                }
                Console.WriteLine(("---------------------------------"));
            }
        

            Console.WriteLine("Website: {0} ", modifiedContact.WebSite);
            newText = Console.ReadLine();
            if (newText != "")
            {
                modifiedContact.WebSite = newText;
            }
            Console.WriteLine("Notes: {0} ", modifiedContact.Notes);
            newText = Console.ReadLine();
            if (newText != "")
            {
                modifiedContact.Notes = newText;
            }
            Console.WriteLine(("---------------------------------"));


            repo.ModifyContact(modifiedContact);
        }

        private static void DeleteContact()
        {
            int idToDelete = 0;
            ContactRepository repo = new ContactRepository();
            // var contacts = repo.deserializeFromXML();
            Console.WriteLine("Please enter the ID you want to delete:");
            idToDelete = int.Parse(Console.ReadLine());

            repo.DeleteContact(idToDelete);
        }

        private static void AddNewContact()
        {
            int highestID = 1;
            ContactRepository repo = new ContactRepository();
            //var contacts = repo.deserializeFromXML();
            foreach (Contact contact in repo.GetWorkingList())
            {
                highestID = Math.Max(highestID, contact.Id);
            }
            highestID++;


            Contact newContact = new Contact();
            newContact.Id = highestID;
            Console.Clear();
            Console.WriteLine("Input");
            Console.WriteLine("First Name: ");
            newContact.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            newContact.LastName = Console.ReadLine();
            Console.WriteLine("Salutation: ");
            newContact.Salutation = Console.ReadLine();

            do
            {
                PhoneNumber thisPhoneNumber = new PhoneNumber();
                Console.WriteLine("Phone Number Type (1)Mobile, (2)Home, (3)Work, (4)Other:  ");
                //newContact.PhoneNumber.Type = Console.ReadLine();
                switch (Console.ReadLine())
                {
                    case "1":
                        thisPhoneNumber.Type = PhoneType.Mobile;
                        break;
                    case "2":
                        thisPhoneNumber.Type = PhoneType.Home;
                        break;
                    case "3":
                        thisPhoneNumber.Type = PhoneType.Work;
                        break;
                    default:
                        thisPhoneNumber.Type = PhoneType.Other;
                        break;

                }


                Console.WriteLine("Phone Number Country Code: ");
                thisPhoneNumber.CountryCode = Console.ReadLine();
                Console.WriteLine("Phone Number: ");
                thisPhoneNumber.Number = Console.ReadLine();
                Console.WriteLine("Phone Number Extension: ");
                thisPhoneNumber.Extension = Console.ReadLine();

                newContact.PhoneNumber.Add(thisPhoneNumber);


                Console.WriteLine("Do you want to add another Phone Number?");
            } while (Console.ReadLine().ToUpper() == "Y");

            Console.WriteLine("*****Address*********");
            do
            {
                Address thisAddress = new Address();

                Console.WriteLine("Address Type: ");
                thisAddress.Type = Console.ReadLine();
                Console.WriteLine("Street1 : ");
                thisAddress.Street1 = Console.ReadLine();
                Console.WriteLine("Street2 : ");
                thisAddress.Street2 = Console.ReadLine();
                Console.WriteLine("City : ");
                thisAddress.City = Console.ReadLine();
                Console.WriteLine("State ");
                thisAddress.State = Console.ReadLine();
                Console.WriteLine("Zip Code ");
                thisAddress.Zip = Console.ReadLine();
                Console.WriteLine("County : ");
                thisAddress.County = Console.ReadLine();
                Console.WriteLine("Country: ");
                thisAddress.Country = Console.ReadLine();

                Console.WriteLine("Do you want to add another Address?");

                newContact.Address.Add(thisAddress);
            } while (Console.ReadLine().ToUpper() == "Y");






            Console.WriteLine("*****Email*********");
            do
            {
                Email thisEmail = new Email();
                Console.WriteLine("Email Type (Work, Home): ");
                thisEmail.Type = Console.ReadLine();
                Console.WriteLine("Email Address : ");

                thisEmail.EmailAddress = Console.ReadLine();
                newContact.Email.Add((thisEmail));

                Console.WriteLine("Do you want to add another email address?");
            } while (Console.ReadLine().ToUpper() == "Y");

            Console.WriteLine("Website ");
            newContact.WebSite = Console.ReadLine();
            Console.WriteLine("Notes ");
            newContact.Notes = Console.ReadLine();


            repo.AddNewContact(newContact);
            //repo.serializeToXML(contacts);
        }



        private static void LoadContact()
        {
            int theID;

            do
            {
                Console.WriteLine("\n\nEnter the ID for the contact you wish to retrieve:");
            } while (!int.TryParse(Console.ReadLine(), out theID));


            ContactRepository repo = new ContactRepository();
            var contact = repo.LoadOne(theID);

            if (contact.Id == 0)
            {
                Console.WriteLine("The contact with the ID you requested was not found. Please try again.");
            }
            else
            {
                Console.Clear();
                DisplayContact(contact);
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();


        }

        private static void DisplayContacts()
        {
            ContactRepository repo = new ContactRepository();
            //var contacts = repo.LoadAllTxt();
            //var contacts = repo.deserializeFromXML();
            Console.Clear();
            Console.WriteLine("All contacts");
            Console.WriteLine("----------------------------------------------");
            repo.SortRepo();
            foreach (var contact in repo.GetWorkingList())
            {
                DisplayContact(contact);
                Console.WriteLine("----------------------------------------------");
            }

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();

        }

        private static void DisplayContact(Contact contact)
        {

            Console.WriteLine("Contact: \n{0}: {1} {2} {3}", contact.Id, contact.Salutation, contact.FirstName, contact.LastName);
            foreach (PhoneNumber thisPhoneNumber in contact.PhoneNumber)
            {
                Console.WriteLine("\n{0} Number: \n{1}-{2}  x: {3}", thisPhoneNumber.Type, thisPhoneNumber.CountryCode, thisPhoneNumber.Number, thisPhoneNumber.Extension);
            }
            foreach (Address thisAddress in contact.Address)
            {
                Console.WriteLine("\n{0}Address:\n{1}\n{2},{3},{4}, {5},{6} ,\n{7} ", thisAddress.Type,
                    thisAddress.Street1, thisAddress.Street2, thisAddress.City, thisAddress.State, thisAddress.Zip,
                    thisAddress.County, thisAddress.Country);

            }


            foreach (Email thisEmail in contact.Email)
            {
                Console.WriteLine("\n{0} email: {1}", thisEmail.Type, thisEmail.EmailAddress);
            }
            Console.WriteLine("\nWeb Site: {0}", contact.WebSite);
            Console.WriteLine("\nNotes:\n{0}", contact.Notes);
        }


    }
}
