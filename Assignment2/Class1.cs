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

        public Student(int id, int startyear, int endYear = startyear + 3)
        {
            Id = id;

            StartDate = DateTime(startyear, 9, 1);
            EndDate = DateTime(startyear, 6, 29);
            GraduationDate = DateTime(startyear + 3, 6, 29);

            _status = StudentEnrollmentStatus();
        }

        public Status StudentEnrollmentStatus()
        {
            var newlyEnrolled = DateTime.Compare( DateTime.Now, StartDate.AddDays(14) ) < 0;
            var graduatedOrDroppedOut = DateTime.Compare( GraduationDate, EndDate) > 0;

            if (graduatedOrDroppedOut == false) return Status.Dropout;

            switch ()
            {
                case (graduatedOrDroppedOut):
                    return Status.Graduated;
                case (newlyEnrolled):
                    return Status.New;
                default:
                    return Status.Active;
                
            }
        }
    }
}
