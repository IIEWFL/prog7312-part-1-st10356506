using System;

namespace Municipality.Models
{
    //W3schools.com (no date) W3Schools Online Web Tutorials. Available at: https://www.w3schools.com/cs/cs_classes.php (Accessed: 10 September 2025). 
    //BillWagner (no date) Classes, structs, and Records - C#, Classes, structs, and records - C# | Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/ (Accessed: 10 September 2025). 
    //this model represents a single report sent to the municipality
    public class Issue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string ReporterName { get; set; }
        public string ReporterEmail { get; set; }
        public string ReporterPhone { get; set; }
        public string Location { get; set; }
        public DateTime DateReported { get; set; }
        public DateTime? DateResolved { get; set; }
        public string Notes { get; set; }
        public string AttachedFiles { get; set; } // Comma-separated file paths
        public string StatusNotes { get; set; }
        public DateTime? DateViewed { get; set; }
        public DateTime? DateResponded { get; set; }

        public Issue()
        {
            DateReported = DateTime.Now;
            Status = "Open";
            Priority = "Medium";
            AttachedFiles = "";
        }

        //this is for creating a new report, these are default values
        public Issue(string title, string description, string category, string reporterName, string reporterEmail, string location)
        {
            Title = title;
            Description = description;
            Category = category;
            ReporterName = reporterName;
            ReporterEmail = reporterEmail;
            Location = location;
            DateReported = DateTime.Now;
            Status = "Open";
            Priority = "Medium";
            AttachedFiles = "";
        }
        //string of the report object for displaying reports in a list with the date reported 
        public override string ToString()
        {
            return $"[{Id}] {Title} - {Status} ({DateReported:yyyy-MM-dd})";
        }
    }
}
