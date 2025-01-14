﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    class TreatmentContext : DbContext
    {
        public TreatmentContext()
           : base("data source =.\\SQLEXPRESS; initial catalog = project; integrated security = SSPI")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Mentor> Mentors { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
        public virtual DbSet<Treatment‏> Treatment‏s { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Teenager‏> Teenager‏s { get; set; }
        public virtual DbSet<VolunteerRequest> VolunteerRequests { get; set; }
        public virtual DbSet<Re‏commender> Re‏commenders‏ { get; set; }






        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Admin>()
                .HasMany(a => a.Mentors)
                .WithRequired(m => m.Admin)
                .HasForeignKey(m => m.AdminId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Mentor>()
               .HasMany(m => m.Teenagers‏)
               .WithMany(t => t.Mentors);


            modelBuilder.Entity<Mentor>()
                .HasMany(m => m.Appointments)
                .WithRequired(a => a.Mentor)
                .HasForeignKey(a => a.MentorId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Admin>()
                .HasMany(a => a.Volunteers)
                .WithRequired(v => v.Admin)
                .HasForeignKey(v => v.AdminId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Volunteer>()
                .HasMany(v => v.Teenagers‏)
                .WithMany(t => t.Volunteers);


            modelBuilder.Entity<Volunteer>()
                .HasMany(v => v.Treatments)
                .WithOptional(t => t.Volunteer)
                .HasForeignKey(t => t.VolunteerId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Teenager>()
                .HasMany(t => t.Treatments)
                .WithRequired(t => t.Teenager)
                .HasForeignKey(t => t.TeenagerId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Admin>()
                  .HasMany(a => a.VolunteerRequests)
                  .WithRequired(v => v.Admin)
                  .HasForeignKey(v => v.AdminId)
                  .WillCascadeOnDelete(false);

            modelBuilder.Entity<VolunteerRequest>()
                .HasMany(v => v.Recommenders)
                .WithRequired(r => r.VolunteerRequest)
                .HasForeignKey(r => r.VolunteerRequestId)
                .WillCascadeOnDelete(false);




             
            
            modelBuilder.Entity<Treatment>()
                .Property(t => t.VolunteerId).IsOptional();

            modelBuilder.Entity<Admin>()
                .HasIndex(u => u.MailAddress)
                .IsUnique();
            modelBuilder.Entity<Admin>()
                .Property(u => u.MailAddress).HasMaxLength(50);

            modelBuilder.Entity<Mentor>()
                .HasIndex(u => u.MailAddress)
                .IsUnique();
            modelBuilder.Entity<Mentor>()
                .Property(u => u.MailAddress).HasMaxLength(50);

            modelBuilder.Entity<Volunteer>()
                .HasIndex(u => u.MailAddress)
                .IsUnique();
            modelBuilder.Entity<Volunteer>()
                .Property(u => u.MailAddress).HasMaxLength(50);

            modelBuilder.Entity<Teenager>()
                .HasIndex(u => u.MailAddress)
                .IsUnique();
            modelBuilder.Entity<Teenager>()
                .Property(u => u.MailAddress).HasMaxLength(50);



        }
    }
}
