using System;
using static Assignment2.Status;

namespace Assignment2
{
    public class Student
    {
        public int Id { get; }

        public string GivenName { get; set; }
        public string Surname { get; set; }

        public Status _status { get; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime GraduationDate { get; set; }


        public Student(int id, int startyear) : this(id, startyear, startyear + 3)
        {
        }

        public Student(int id, int startyear, int endYear)
        {
            Id = id;

            StartDate = new DateTime(startyear, 9, 1);
            GraduationDate = new DateTime(startyear + 3, 6, 29);
            EndDate = new DateTime(endYear, 6, 29);

            _status = StudentEnrollmentStatus();
        }

        public Status StudentEnrollmentStatus()
        {
            var newlyEnrolled = DateTime.Compare(DateTime.Now, StartDate.AddDays(90)) < 0;
            var graduatedOrDroppedOut = DateTime.Compare(GraduationDate, EndDate) > 0;

            if (graduatedOrDroppedOut) return Status.Dropout;


            if (graduatedOrDroppedOut)
            {
                return Status.Graduated;
            }
            if (newlyEnrolled)
            {
                return Status.New;
            }
            return Status.Active;
        }
    }
}
