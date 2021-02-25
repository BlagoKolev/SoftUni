using System;
using SoftUni.Models;
using SoftUni.Data;
using System.Linq;
using System.Text;
using System.Globalization;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            // Console.WriteLine(GetEmployeesFullInformation(db));
            // Console.WriteLine(GetEmployeesWithSalaryOver50000(db));
            // Console.WriteLine(GetEmployeesFromResearchAndDevelopment(db));
            // Console.WriteLine(AddNewAddressToEmployee(db));
            // Console.WriteLine(GetEmployeesInPeriod(db));
            // Console.WriteLine(GetAddressesByTown(db));
            // Console.WriteLine(GetEmployee147(db));
            // Console.WriteLine(GetDepartmentsWithMoreThan5Employees(db));
            // Console.WriteLine(GetLatestProjects(db));
            // Console.WriteLine(IncreaseSalaries(db));
            // Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(db));
            // Console.WriteLine(DeleteProjectById(db));
        }
        //PROBLEM -3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.EmployeeId).ToList();
            foreach (var employee in employees)
            {
                var middleName = employee.MiddleName;
                string middleNameToAppend = middleName == null ? "" : $" {middleName}";

                sb.AppendLine($"{employee.FirstName} {employee.LastName}{middleNameToAppend} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        // PROBLEM - 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName).ToList();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        //PROBLEM - 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        //PROBLEM - 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var addresses = context.Addresses;

            Address newAddress = new Address() { TownId = 4, AddressText = "Vitoshka 15" };

            addresses.Add(newAddress);

            var employeeNakov = context.Employees
                .Where(e => e.LastName == "Nakov")
                .FirstOrDefault();

            employeeNakov.Address = newAddress;

            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => new { e.Address.AddressText })
                .ToList();

            StringBuilder sb = new StringBuilder();


            foreach (var empl in employees)
            {
                sb.AppendLine(empl.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        //PROBLEM - 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {

            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001
                                                       && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Project = e.EmployeesProjects
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                    }).ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.Project)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }

            }

            return sb.ToString().TrimEnd();

        }

        //PROBLEM - 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                            .Select(x => new
                            {
                                x.AddressText,
                                TownName = x.Town.Name,
                                EmployeesCount = x.Employees.Count
                            })
                            .OrderByDescending(e => e.EmployeesCount)
                            .ThenBy(t => t.TownName)
                            .ThenBy(a => a.AddressText)
                            .Take(10)
                            .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }
            return sb.ToString().TrimEnd();
        }

        //PROBLEM - 9
        public static string GetEmployee147(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                           .Select(ep => new { ProjectName = ep.Project.Name })
                    .OrderBy(ep => ep.ProjectName)
                    .ToList()
                })
                    .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                foreach (var project in e.Projects)
                {
                    sb.AppendLine($"{project.ProjectName}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //PROBLEM - 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    DepEmployees = d.Employees
                                .Select(e => new
                                {
                                    EmployeeFirstName = e.FirstName,
                                    EmployeeLastName = e.LastName,
                                    EmployeeJobTitle = e.JobTitle
                                })
                                .OrderBy(e => e.EmployeeFirstName)
                                .ThenBy(e => e.EmployeeLastName)
                                .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var dep in departments)
            {
                sb.AppendLine($"{dep.Name} - {dep.ManagerFirstName} {dep.ManagerLastName}");

                foreach (var emp in dep.DepEmployees)
                {
                    sb.AppendLine($"{emp.EmployeeFirstName} {emp.EmployeeLastName} - {emp.EmployeeJobTitle}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //PROBLEM 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .OrderBy(p => p.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var p in projects)
            {

                sb.AppendLine($"{p.Name}")
                    .AppendLine($"{p.Description}")
                    .AppendLine($"{p.StartDate}");
            }
            return sb.ToString().TrimEnd();
        }

        //PROBLEM - 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing"
                || e.Department.Name == "Information Services");

            foreach (var s in employees)
            {
                s.Salary = s.Salary * 1.12M;
            }

            context.SaveChanges();

            var updatedSalary = employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var s in updatedSalary)
            {
                sb.AppendLine($"{s.FirstName} {s.LastName} (${s.Salary:f2})");

            }

            return sb.ToString().TrimEnd();
        }

        //PROBLEM - 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary,
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }

        //PROBLEM - 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectToDelete = context.Projects
                .Where(p => p.ProjectId == 2)
                .FirstOrDefault();

            var mappingToDeleteList = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2).ToArray();

            context.EmployeesProjects.RemoveRange(mappingToDeleteList);

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine($"{p}");
            }
            return sb.ToString().TrimEnd();
        }

        //PROBLEM - 15
        public static string RemoveTown(SoftUniContext context)
        {
            var townToDelete = context.Towns
                .Where(t => t.Name == "Seattle")
                .FirstOrDefault();

            var addressesIdToRemove = context.Addresses
                .Where(a => a.TownId == townToDelete.TownId);

            int addressesToDeleteCount = addressesIdToRemove.Count();

            var employeesToDeleteAddress = context.Employees
             .Where(e => addressesIdToRemove
             .Any(a => a.AddressId == e.AddressId));


            foreach (var e in employeesToDeleteAddress)
            {
                e.AddressId = null;
            }

            foreach (var address in addressesIdToRemove)
            {
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(townToDelete);

            context.SaveChanges();

            return $"{addressesToDeleteCount} addresses in {townToDelete.Name} were deleted";
        }


    }
}
