namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ImportDto;
    using SoftJail.Data.Models;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.IO;
    using SoftJail.Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var deparmentsCells = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            var depToImport = new List<Department>();


            foreach (var dep in deparmentsCells)
            {
                if (!IsValid(dep))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newDepartment = new Department
                {
                    Name = dep.Name,
                };

                bool isDepatmentValid = true;

                foreach (var cell in dep.Cells)
                {
                    if (!IsValid(cell))
                    {
                        isDepatmentValid = false;
                        break;
                    }

                    var newCell = new Cell
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = cell.HasWindow
                    };

                    newDepartment.Cells.Add(newCell);
                }

                if (!isDepatmentValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (newDepartment.Cells.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                depToImport.Add(newDepartment);
                sb.AppendLine($"Imported {newDepartment.Name} with {newDepartment.Cells.Count} cells");
            }

            context.Departments.AddRange(depToImport);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var serializedPrisoners = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            var prisonersToImport = new List<Prisoner>();

            foreach (var prisoner in serializedPrisoners)
            {

                if (!IsValid(prisoner))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime incarcerationDate;

                bool isIncarcerationDateValid = DateTime.TryParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? releaseDate = null;

                if (!string.IsNullOrEmpty(prisoner.ReleaseDate))
                {

                    DateTime releaseDateValue;
                    bool isReleaseDataValid = DateTime.TryParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDateValue);

                    if (!isReleaseDataValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    releaseDate = releaseDateValue;
                }


                var newPrisoner = new Prisoner
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    Age = prisoner.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId
                };

                bool areMailsValid = true;

                foreach (var mail in prisoner.Mails)
                {
                    if (!IsValid(mail))
                    {
                        areMailsValid = false;
                        break;
                    }

                    var newMail = new Mail
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address
                    };

                    newPrisoner.Mails.Add(newMail);
                }

                if (!areMailsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                prisonersToImport.Add(newPrisoner);
                sb.AppendLine($"Imported {newPrisoner.FullName} {newPrisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisonersToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportOfficersDto[]), new XmlRootAttribute("Officers"));

            ImportOfficersDto[] serizlizedOfficers;

            using (var reader = new StringReader(xmlString))
            {
                var officers = new List<Officer>();

                serizlizedOfficers = (ImportOfficersDto[])serializer.Deserialize(reader);

                foreach (var officer in serizlizedOfficers)
                {
                    if (!IsValid(officer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    object objPosition;

                    bool isPositionValid = Enum.TryParse(typeof(Position), officer.Position, out objPosition);

                    if (!isPositionValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    object objWeapon;

                    bool isWeaponValid = Enum.TryParse(typeof(Weapon), officer.Weapon, out objWeapon);

                    if (!isWeaponValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }


                    var newOfficer = new Officer
                    {
                        FullName = officer.FullName,
                        Salary = officer.Salary,
                        Position = (Position)objPosition,
                        Weapon = (Weapon)objWeapon,
                        DepartmentId = officer.DepartmentId,
                    };

                    foreach (var prisoner in officer.Prisoners)
                    {
                        var newPrisoner = new OfficerPrisoner
                        {
                            Officer = newOfficer,
                            PrisonerId = prisoner.Id
                        };

                        newOfficer.OfficerPrisoners.Add(newPrisoner);
                    }

                    officers.Add(newOfficer);
                        sb.AppendLine($"Imported {newOfficer.FullName} ({newOfficer.OfficerPrisoners.Count} prisoners)");
                }

                context.Officers.AddRange(officers);
                context.SaveChanges();
            }


            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}