using System;
using static Assignment2.Status;

namespace Assignment2
{
    public record ImmutableStudent(int Id, string GivenName, string Surname, Status status, DateTime StartDate, DateTime EndDate, DateTime GraduationDate)
    {
        public virtual bool Equals(ImmutableStudent other) =>
            other != null && DateTime.Compare(other.StartDate, StartDate) == 0 && DateTime.Compare(other.EndDate, EndDate) == 0 && DateTime.Compare(other.GraduationDate, GraduationDate) == 0 && other.Id == Id && string.Equals(other.GivenName, GivenName) && string.Equals(other.Surname, Surname) && other.status == status;
    } 
}