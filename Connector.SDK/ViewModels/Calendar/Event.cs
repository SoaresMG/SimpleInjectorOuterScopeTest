using System;

namespace Connector.SDK.ViewModels.Calendar
{
    public class Event
    {
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }

        public Event() { }

        public Event(string Title, DateTime Date)
        {
            this.Title = Title;
            this.Start = new DateTime(Date.Year, Date.Month, Date.Day, 0, 0, 0);
            this.End = new DateTime(Date.Year, Date.Month, Date.Day, 0, 0, 0);
        }

        public Event(string Title, DateTime Date, string Description)
            : this(Title, Date)
        {
            this.Description = Description;
        }

        public Event(string Title, DateTime Start, DateTime? End)
        {
            this.Title = Title;
            this.Start = Start;
            this.End = End;
        }

        public Event(string Title, DateTime Start, DateTime? End, string Description)
            : this(Title, Start, End)
        {
            this.Description = Description;
        }
    }
}