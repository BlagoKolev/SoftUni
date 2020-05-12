using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName,
            decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException
                        ("Expected value mismatch! Argument: weekSalary");
                }
                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            private set
            {
                if (value < 1 || 12 < value)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workHoursPerDay = value;
            }
        }

        private decimal CalculateSalaryPerHour()
        {
            var salaryPerHour = (this.WeekSalary / (decimal)(5 * this.workHoursPerDay));
            return salaryPerHour;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("First Name: {0}", this.FirstName))
                .AppendLine(String.Format("Last Name: {0}", this.LastName))
                .AppendLine(String.Format("Week Salary: {0:f2}", this.WeekSalary))
                .AppendLine(String.Format("Hours per day: {0:f2}", this.WorkHoursPerDay))
                .AppendLine(String.Format
                ("Salary per hour: {0:f2}", this.CalculateSalaryPerHour()));

            return sb.ToString().TrimEnd();

        }
    }
}
