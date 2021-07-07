using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBook_Linq
{
    class AddressBook
    {
        DataTable table = new DataTable("AddressBook");
        public AddressBook()
        {
            // Here store Type as a field
            //column Represents all table columns
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(string));
            table.Columns.Add("PhoneNumber", typeof(string));
            table.Columns.Add("Email", typeof(string));
        }
        /// <summary>
        /// UC3 Method to insert data into the address book contact table
        /// </summary>
        public void InsertContactToTable()
        {
            ////Declaring Rows:
            table.Rows.Add("Shreya", "Malviya", "Howrah", "Nagpur", "MH", 75866, "8596748585", "shreya@gmail.com");
            table.Rows.Add("A", "sMalviya", "Howrah", "Nagpur", "MH", 75866, "8596748585", "shreya@gmail.com");
            table.Rows.Add("B", "dMalviya", "Howrah", "Nagpur", "MH", 75866, "8596748585", "shreya@gmail.com");
            table.Rows.Add("C", "vMalviya", "Howrah", "Nagpur", "MH", 75866, "8596748585", "shreya@gmail.com");
            table.Rows.Add("D", "fMalviya", "Howrah", "Nagpur", "MH", 75866, "8596748585", "shreya@gmail.com");
            table.Rows.Add("prajakta", "Nayak", "Durgapur", "A zone", "West Bengal", 14526, "8596748585", "prajakta@gmail.com");
            table.Rows.Add("Tanmay", "Agarwal", "Kolkata", "NewTown", "West Bengal", 78596, "8596748585", "tanmay@gmail.com");
            table.Rows.Add("ekta", "Nath", "Patna", "Patna City", "Bihar", 125896, "8596748585", "ekta@gmail.com");
            Console.WriteLine("Contact details added successfully!\n Select 2 for view contact\n");



        }
        //Display Details
        public void DisplayDetails()
        {
            // IEnumerable in C# is an interface that defines one method, 
            //AsEnumerable, which is an extension method for DataTable,
            //AsEnumerable method will return multiple, independent
            //queryable objects that are all bound to the source DataTable.
            foreach (var table in table.AsEnumerable())
            {
                // Get all field by column index.
                Console.WriteLine("\nFirstName:-" + table.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + table.Field<string>("LastName"));
                Console.WriteLine("Address:-" + table.Field<string>("Address"));
                Console.WriteLine("City:-" + table.Field<string>("City"));
                Console.WriteLine("State:-" + table.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + table.Field<string>("Zip"));
                Console.WriteLine("PhoneNumber:-" + table.Field<string>("PhoneNumber"));
                Console.WriteLine("Email:-" + table.Field<string>("Email"));
            }
        }
        /// <summary>
        /// Edit Existing Contact
        /// </summary>
        public void EditExistingContact()
        {
            try
            {
                ////Contact that has to be edited
                string editName = "prajakta";
                ////Select using Lambda Function
                /////Table.asenumarable means takes all the data from table as list
                ///X is like variable declaration or else we can say as x stores all the columns field is nthg but x.column name
              //Firstordefault means gets the first elements in the table when we search
                var updateData = table.AsEnumerable().Where(x => x.Field<string>("FirstName").Equals(editName)).FirstOrDefault();
                if (updateData != null)
                {
                    ////Update Phone Number and City
                    updateData.SetField("PhoneNumber", "895478520");
                    updateData.SetField("City", "Pune");
                    Console.WriteLine("\n PhoneNumber and ity of {0} updated successfully!", editName);
                    DisplayDetails();
                }
                else
                {
                    Console.WriteLine("There is no such record in the Address Book!");
                }
            }
            //exception
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Delete row
        /// </summary>
        /// <param name="name"></param>
        public void DeleteContact(string firstName)
        {
            try
            {
                ////Select row to delete using Lambda function
                /////Table.asenumarable means takes all the data from table as list
                ///a is like variable declaration or else we can say as x stores all the columns field is nthg but a.column name
              //Firstordefault means gets the first elements in the table when we search
                var rowDelete = table.AsEnumerable().Where(a => a.Field<string>("FirstName").Equals(firstName)).FirstOrDefault();
                if (rowDelete != null)
                {
                    // add a RowDelete event handler for the table.

                    rowDelete.Delete();
                    Console.WriteLine("\nContact with name '{0}' deleted successfully!", firstName);
                    DisplayDetails();
                }
                else
                {
                    Console.WriteLine("There is no such data");
                }
            }
            ////Catch Exception If any
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void retrievePersonByUsingCity(Contact contact)
        {
            //// using Lambda function
            /////Table.asenumarable means takes all the data from table as list
            ///a is like variable declaration or else we can say as x stores all the columns field is nthg but a.column name
            //Firstordefault means gets the first elements in the table when we search
            var selectdData = table.AsEnumerable().Where(a => a.Field<string>("City").Equals(contact.City)).FirstOrDefault();
            /////Table.asenumarable means takes all the data from table as list
            foreach (var table in table.AsEnumerable())
            {
                Console.WriteLine("\nFirstName:-" + table.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + table.Field<string>("LastName"));
                Console.WriteLine("Address:-" + table.Field<string>("Address"));
                Console.WriteLine("City:-" + table.Field<string>("City"));
                Console.WriteLine("State:-" + table.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + table.Field<string>("Zip"));
                Console.WriteLine("PhoneNumber:-" + table.Field<string>("PhoneNumber"));
                Console.WriteLine("Email:-" + table.Field<string>("Email"));
            }

        }
        public void retrievePersonByUsingState(Contact contact)
        {
            //// using Lambda function
            /////Table.asenumarable means takes all the data from table as list
            ///a is like variable declaration or else we can say as x stores all the columns field is nthg but a.column name
            //Firstordefault means gets the first elements in the table when we search
            var selectdData = table.AsEnumerable().Where(a => a.Field<string>("State").Equals(contact.State)).FirstOrDefault();
            /////Table.asenumarable means takes all the data from table as list
            foreach (var table in table.AsEnumerable())
            {
                Console.WriteLine("\nFirstName:-" + table.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + table.Field<string>("LastName"));
                Console.WriteLine("Address:-" + table.Field<string>("Address"));
                Console.WriteLine("City:-" + table.Field<string>("City"));
                Console.WriteLine("State:-" + table.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + table.Field<string>("Zip"));
                Console.WriteLine("PhoneNumber:-" + table.Field<string>("PhoneNumber"));
                Console.WriteLine("Email:-" + table.Field<string>("Email"));
            }

        }
        public void sortContactAlphabeticallyForGivenCity(Contact contact)
        {
            /// using Lambda function
            /////Table.asenumarable means takes all the data from table as list
            ///a is like variable declaration or else we can say as x stores all the columns field is nthg but a.column name
            //OrderBy() method sorts the collection in ascending order based on specified field.
            //ThenBy() method after OrderBy to sort the collection on another field in ascending order. 
            var records = table.AsEnumerable().Where(x => x.Field<string>("City") == contact.City).OrderBy(x => x.Field<string>("FirstName")).ThenBy(x => x.Field<string>("LastName"));
            foreach (var table in records)
            {
                Console.WriteLine("\nFirstName:-" + table.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + table.Field<string>("LastName"));
                Console.WriteLine("Address:-" + table.Field<string>("Address"));
                Console.WriteLine("City:-" + table.Field<string>("City"));
                Console.WriteLine("State:-" + table.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + table.Field<string>("Zip"));
                Console.WriteLine("PhoneNumber:-" + table.Field<string>("PhoneNumber"));
                Console.WriteLine("Email:-" + table.Field<string>("Email"));
            }
        }
    }
}