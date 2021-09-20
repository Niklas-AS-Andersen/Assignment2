using System;
using System.ComponentModel;
using Xunit;
using static Assignment2.Status;

namespace Assignment2.Tests
{
    public class StudentTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(123)]
        [InlineData(-1)]
        [InlineData(Int32.MaxValue - 3)]
        public void New_student_given_id_returns_correct_id(int id)
        {
            var stud = new Student(id, 1990);

            Assert.Equal(id, stud.Id);
        }

        [Fact]
        public void Can_only_set_id_on_student_at_creation()
        {
            var stud = new Student(5, 1900);

            AttributeCollection attributes = TypeDescriptor.GetProperties(stud)["Id"].Attributes;

            Assert.Equal(ReadOnlyAttribute.Yes, attributes[typeof(ReadOnlyAttribute)]);
            Assert.Equal(5, stud.Id);
        }

        [Fact]
        public void New_student_can_give_end_date()
        {
            var stud = new Student(9, 1990, 1999);

            Assert.Equal(1999, stud.EndDate.Year);
        }

        [Fact]
        public void New_Student_returns_status_new()
        {
            var stud = new Student(1, 2021);

            Assert.Equal(Status.New, stud._status);
        }

        [Fact]
        public void Status_cant_be_overwritten()
        {
            var stud = new Student(1, 2021);

            AttributeCollection attributes = TypeDescriptor.GetProperties(stud)["_status"].Attributes;

            Assert.Equal(ReadOnlyAttribute.Yes, attributes[typeof(ReadOnlyAttribute)]);
        }

        [Fact]
        public void Student_Returns_Correct_To_String()
        {
            var stud = new Student(9, 2021);
            stud.Surname = "Hansen";
            stud.GivenName = "Emil";

            var expected = "Emil Hansen, 9 is New\nStart date: 01-09-2021 00:00:00\nEnd date: 29-06-2024 00:00:00\nGraduation date: 29-06-2024 00:00:00";

            Assert.Equal(expected, stud.toString());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(123)]
        [InlineData(-1)]
        [InlineData(Int32.MaxValue - 3)]
        public void Two_New_ImmutableStudents_given_same_id_returns_same_id(int id)
        {
            var stud = new ImmutableStudent(id, "Hello", "world", Status.Active, new DateTime(1,2,4), new DateTime(2,4,8), new DateTime(2,4,8));

            Assert.True(stud.Equals(stud));
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(123, 321)]
        [InlineData(-1, 1)]
        [InlineData(Int32.MaxValue - 3, 3)]
        public void Two_New_ImmutableStudents_given_different_ids_returns_different_ids(int id1, int id2)
        {
            var stud1 = new ImmutableStudent(id1, "Hello", "world", Status.Active, new DateTime(1,2,4), new DateTime(2,4,8), new DateTime(2,4,8));
            var stud2 = new ImmutableStudent(id2, "Hello", "world", Status.Active, new DateTime(1,2,4), new DateTime(2,4,8), new DateTime(2,4,8));

            Assert.False(stud1.Equals(stud2));
        }

        [Theory]
        [InlineData(Status.New)]
        [InlineData(Status.Active)]
        [InlineData(Status.Dropout)]
        [InlineData(Status.Graduated)]
        public void Two_New_ImmutableStudents_given_same_status_returns_same_status(Status status)
        {
            var stud = new ImmutableStudent(1, "Hello", "world", status, new DateTime(1,2,4), new DateTime(2,4,8), new DateTime(2,4,8));

            Assert.True(stud.Equals(stud));
        }

        [Theory]
        [InlineData(Status.New, Status.Active)]
        [InlineData(Status.Active, Status.Dropout)]
        [InlineData(Status.Dropout, Status.Graduated)]
        [InlineData(Status.Graduated, Status.New)]
        public void Two_New_ImmutableStudents_given_differenct_status_returns_different_status(Status status1, Status status2)
        {
            var stud1 = new ImmutableStudent(1, "Hello", "world", status1, new DateTime(1,2,4), new DateTime(2,4,8), new DateTime(2,4,8));
            var stud2 = new ImmutableStudent(1, "Hello", "world", status2, new DateTime(1,2,4), new DateTime(2,4,8), new DateTime(2,4,8));

            Assert.False(stud1.Equals(stud2));
        }

        [Theory]
        [InlineData(Status.New)]
        [InlineData(Status.Active)]
        [InlineData(Status.Dropout)]
        [InlineData(Status.Graduated)]
        public void Two_New_ImmutableStudents_given_same_status_returns_same_status_ToString(Status status)
        {
            var stud = new ImmutableStudent(1, "Hello", "world", status, new DateTime(1,2,4), new DateTime(2,4,8), new DateTime(2,4,8));

            Assert.Equal(stud.ToString(), stud.ToString());
        }
    }
}
