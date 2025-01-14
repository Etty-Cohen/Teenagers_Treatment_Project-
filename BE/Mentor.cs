﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
    public class Mentor : Helper
    {
        public int MentorId { get; set; }


        public virtual ICollection<Appointment> Appointments { get; set; }

        public int AdminId { get; set; }

        public virtual Admin Admin { get; set; }


        public Mentor(string firstName, string lastName, string phoneNumber, string mailAddress, Address address, string password, int adminId) :
            base(firstName, lastName, phoneNumber, mailAddress, address, password, adminId)
        {
            Appointments = new HashSet<Appointment>();
            AdminId = adminId;
        }

        public Mentor() { }


    }
}
