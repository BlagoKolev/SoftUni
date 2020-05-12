using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mankind
{
   public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            private set
            {
                if (5 > value.Length || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                if (!ValidateFacultyNumber(value))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("First Name: {0}", this.FirstName))
                .AppendLine(String.Format("Last Name: {0}", this.LastName))
                .AppendLine(String.Format("Faculty number: {0}", this.facultyNumber));

            return sb.ToString().TrimEnd();
        }

        private bool ValidateFacultyNumber(string value)
        {
            var isValid = true;
            foreach (var symbol in value)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return isValid = false;
                }
            }
            return isValid;
        }
    }
}




