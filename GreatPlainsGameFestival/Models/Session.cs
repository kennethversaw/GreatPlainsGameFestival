using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreatPlainsGameFestival.Models
{
    public class Entity
    {
        public int Id { get; set; }
    }

    public class Session : Entity
    {
        public string Title { get; set; }
        [AllowHtml]
        public string Abstract { get; set; }

        public SessionType SessionType { get; set; }

        public string Level { get; set; }
        public int? TimeSlotId { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }

        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }

        public virtual ICollection<Speaker> Speakers { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }

    public class TimeSlot : Entity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }

    public class Room : Entity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }

    public class Speaker : Entity
    {
        public string Name { get; set; }
        [AllowHtml]
        public string Bio { get; set; }
        public string TwitterHandle { get; set; }
        [Url]
        public string Website { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Company { get; set; }
        [Url]
        public string CompanyUrl { get; set; }
        public string ShirtSize { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }

    public class Attendee : Entity
    {
        [EmailAddress]
        public string Email { get; set; }
        public bool Verified { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }


    public class Evaluation : Entity
    {
        public int? SessionId { get; set; }
        public virtual Session Session { get; set; }
        public int Question1 { get; set; }
        public int Question2 { get; set; }
        public int Question3 { get; set; }
        public int Question4 { get; set; }
        public int Question5 { get; set; }
        public int Question6 { get; set; }
        public int Question7 { get; set; }
        public int Question8 { get; set; }
        public int Question9 { get; set; }
        public int Question10 { get; set; }
        public string Comments { get; set; }
        public string Tag { get; set; }
    }

    public class SessionSubmission : Entity
    {
        public string Title { get; set; }
        [AllowHtml]
        public string Abstract { get; set; }
        public string Level { get; set; }
        public SessionType SessionType { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Bio { get; set; }
        public string TwitterHandle { get; set; }
        [Url]
        public string Website { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Company { get; set; }
        [Url]
        public string CompanyUrl { get; set; }
        public string ShirtSize { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
    }

    public enum SessionType
    {
        Breakout,
        Keynote,
        Break,
        Group,
        Workshop,
        Social
    }

    public class CodeCampContext : DbContext
    {
        public CodeCampContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionSubmission> SessionSubmissions { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}