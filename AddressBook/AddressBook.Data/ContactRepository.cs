using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace AddressBook.Data
{
     public class ContactRepository
     {
         static private List<Contact> workingList;
          
        
        const int idColumn = 0;
        const int firstnameColumn = 1;
        const int lastnameColumn = 2;
        const int salutationColumn = 3;
        const int phonenumbertypeColumn = 4;
        const int countrycodeColumn = 5;
        const int phonenumberColumn = 6;
        const int extensionColumn = 7;
        const int street1Column = 8;
        const int street2Column = 9;

        const int cityColumn = 10;
        const int stateColumn = 11;
        const int zipColumn =  12;

        const int countryColumn = 13;
        const int countyColumn = 14;

        const int addresstypeColumn = 15;
        const int emailtypeColumn = 16;
        const int emailaddressColumn =  17;
        const int websiteColumn = 18;
        const int notesColumn =19;



        static public void serializeToXML() //Save to xml
        {
            System.Xml.Serialization.XmlSerializer theSerializer = new System.Xml.Serialization.XmlSerializer(workingList.GetType());
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes= true;
            using(XmlWriter writer = XmlWriter.Create("Contacts.xml", settings))
            {
                theSerializer.Serialize(writer, workingList);
            }
        }

        static public void deserializeFromXML()    //read from xml
        {
            List<Contact> allContacts= new List<Contact>();
            System.Xml.Serialization.XmlSerializer theSerializer = new System.Xml.Serialization.XmlSerializer(allContacts.GetType());

            using (XmlReader reader = XmlReader.Create(("Contacts.xml")))
            {
                workingList = (List<Contact>)theSerializer.Deserialize(reader);

            }


            
        }


        //public List<Contact> LoadAllTxt()
        //{
        //    var allContacts = File.ReadAllLines("Contacts.txt");
        //    List<Contact> contacts = new List<Contact>();
        //    for (int i = 1; i < allContacts.Length; i++)
        //    {
        //        string[] columns = allContacts[i].Split(',');
        //        Contact newContact = new Contact();
        //        newContact.Id = int.Parse(columns[0]);
        //        newContact.FirstName = columns[firstnameColumn];
        //        newContact.LastName = columns[lastnameColumn];
        //        if (!string.IsNullOrEmpty(columns[salutationColumn]))
        //        {
        //            newContact.Salutation = columns[salutationColumn];
        //        }

        //       //newContact.PhoneNumber = new PhoneNumber();

        //        switch (columns[phonenumbertypeColumn])
        //        {
        //            case "Mobile":
        //                newContact.PhoneNumber.Type = PhoneType.Mobile;
        //                break;
        //            case "Home":
        //                newContact.PhoneNumber.Type = PhoneType.Home;
        //                break;
        //            case "Work":
        //                newContact.PhoneNumber.Type = PhoneType.Work;
        //                break;
        //            default:
        //                newContact.PhoneNumber.Type = PhoneType.Other;
        //                break;

        //        }


        //        newContact.PhoneNumber.CountryCode = (columns[countrycodeColumn]);
        //        newContact.PhoneNumber.Number = (columns[phonenumberColumn]);
        //        if (!string.IsNullOrEmpty(columns[extensionColumn]))
        //        {
        //            newContact.PhoneNumber.Extension = columns[extensionColumn];
        //        }

        //       // newContact.Address = new Address();
        //        newContact.Address.Street1 = columns[street1Column];

        //        if (!string.IsNullOrEmpty(columns[street2Column]))
        //        {
        //            newContact.Address.Street2 = columns[street2Column];
        //        }
        //        newContact.Address.City = columns[cityColumn];
        //        newContact.Address.State = columns[stateColumn];
        //        newContact.Address.Zip = columns[zipColumn];
        //        newContact.Address.Country = columns[countryColumn];
        //        if (!string.IsNullOrEmpty(columns[countyColumn]))
        //        {
        //        }
        //        newContact.Address.Type = columns[addresstypeColumn];

        //        newContact.Email = new Email();
        //        newContact.Email.Type = columns[emailtypeColumn];
        //        newContact.Email.EmailAddress = columns[emailaddressColumn];

        //        if (!string.IsNullOrEmpty(columns[websiteColumn]))
        //        {
        //            newContact.WebSite = columns[websiteColumn];
        //        }

        //        if (!string.IsNullOrEmpty(columns[notesColumn]))
        //        {
        //            newContact.Notes = columns[notesColumn];
        //        }

        //        contacts.Add(newContact);

        //    }
        //    return contacts;
        //}

       public  Contact LoadOne(int theID)
        {
            Contact theContact = new Contact();

            //var contacts = deserializeFromXML();

            foreach (Contact contact in workingList)
            {
                if (contact.Id == theID)
                    return contact;
            }

            return theContact;
        }

        public void AddNewContact(Contact theContact)
        {

            //string newContactLine = "";
            ////create string and trim 

            //newContactLine += theContact.Id + "," + theContact.FirstName + "," + theContact.LastName + "," + theContact.Salutation + "," +
            //      theContact.PhoneNumber.Type + "," + theContact.PhoneNumber.CountryCode + "," + theContact.PhoneNumber.Number + "," + theContact.PhoneNumber.Extension + "," +
            //     theContact.Address.Street1 + "," + theContact.Address.Street2 + "," + theContact.Address.City + "," + theContact.Address.State + "," + theContact.Address.Zip + "," + theContact.Address.Country + "," + theContact.Address.County + "," + theContact.Address.Type + "," +
            //     theContact.Email.Type + "," + theContact.Email.EmailAddress + "," + theContact.WebSite + "," + theContact.Notes ;
            //newContactLine.Trim();
            ////append to Contacts.txt

            //using(StreamWriter sw = File.AppendText("Contacts.txt"))
            //{
            //    sw.WriteLine(newContactLine);
            //}

            //var allContacts = deserializeFromXML();
            workingList.Add(theContact);
            //serializeToXML(workingList);



        }

        public void DeleteContact(int theID)
        {
           // var contacts = deserializeFromXML();

            //var newList = contacts.Where(x => x.Id != theID);

            Contact theOne = (Contact)(workingList.SingleOrDefault(x => x.Id == theID));
            if (theOne != null)
            {
                workingList.Remove(theOne);
            }
           

            //serializeToXML(contacts);
            //using (StreamWriter theFile = new StreamWriter(@"Contacts.txt"))
            //{
            //    theFile.WriteLine("id,firstname,latname,salutation,phonenumbertype,countrycode,phonenumber,extension,street1,street2,city,state,zip,country,county,addresstype,emailtype,emailaddress,website,notes,");
            //}
            //foreach (var contact in newList)
            //{
            //    AddNewContact(contact);
            //}
           
        }

        public void ModifyContact(Contact modifiedContact)
        {
           // var contacts = deserializeFromXML();//LoadAllTxt();

            //replace contact with the ID we're modifying with our modified contact
            DeleteContact(modifiedContact.Id);
            //save all contacts back to the file
            AddNewContact(modifiedContact);
        }



        public List<Contact> GetWorkingList()
        {
            return workingList;
        }

        public void SortRepo()
        {
            //Array.Sort(workingList.ToArray());

            workingList.Sort();
        }
     }
}
