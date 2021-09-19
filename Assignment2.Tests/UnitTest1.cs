using System;
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
        [InlineData(Int32.MaxValue)]
        public void New_student_given_id_returns_correct_id(int id)
        {
            var stud = new Student(id, 1990);

            Assert.Equal(id, stud.Id);
        }

        [Fact]
        public void New_Student_returns_status_new()
        {
            var stud = new Student(1, 2021);

            Assert.Equal(Status.New, stud._status)
        }
    }
}
