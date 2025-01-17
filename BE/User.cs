﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        //[Index(IsUnique = true)]
        public string MailAddress { get; set; }
        public Address Address { get; set; }
        public string Password { get; set; }

        public User(string firstName, string lastName, string phoneNumber, string mailAddress, Address address, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            MailAddress = mailAddress;
            Address = address;
            Password = password;
        }

        public User() { }

        public Address GetAddress()
        {
            return Address;
        }

        public void SetAddress(Address address)
        {
            if (address != null)
                Address = address;
        }

        public string GetMailAddress()
        {
            return MailAddress;
        }

        public void SetMailAddress(string mailAddress)
        {
            MailAddress = mailAddress;
        }


        public string GetFirstName()
        {
            return FirstName;
        }

        public void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }

        public string GetPassword()
        {
            return Password;
        }

        public void SetPassword(string password)
        {
    
        }

    }
}
