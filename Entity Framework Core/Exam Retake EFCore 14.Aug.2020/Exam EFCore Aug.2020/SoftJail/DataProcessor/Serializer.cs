namespace SoftJail.DataProcessor
{

    using Data;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.IO;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            

            var prisoners = context.Prisoners
            //To get points in judge  you must put here -->>    .ToArray()
                .Where(p => ids.Contains(p.Id))
                .Select(p => new ExportPrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(po => new ExportOfficersDto
                    {
                        OfficerName = po.Officer.FullName,
                        Department = po.Officer.Department.Name
                    })
                    .OrderBy(po => po.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(x => x.Officer.Salary)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            

            var serializedPrisoners = JsonConvert.SerializeObject(prisoners,Formatting.Indented );

            return serializedPrisoners;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(ExportPrisonersMailsDto[]), new XmlRootAttribute("Prisoners"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            var prisonersNamesArray = prisonersNames.Split(",").ToArray();

            var prisoners = context.Prisoners
                //To get points in judge  you must put here -->>    .ToArray()
                .Where(p => prisonersNamesArray.Contains(p.FullName))
                .Select(p => new ExportPrisonersMailsDto()
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Mails = p.Mails.Select(x => new ExportMailsDto()
                    {

                        Description = ReversedString(x.Description)
                    })
                    .ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            string result = string.Empty;

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, prisoners,namespaces);
                result = writer.ToString();
            }


            return result.ToString();
        }
        private static string ReversedString(string text)
        {
            return string.Join("", text.Reverse());
        }
    }
}