using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo
{
    public class Item
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public bool Priority { get; set; }
        public string Description { get; set; }

        public Item(string title, string date, bool priority, string description)
        {
            Title = title;
            Date = date;
            Priority = priority;
            Description = description;
        }
        public override string ToString()
        {
            string result = $"{Title}\t{Date}\t{(Priority ? '!' : ' ')}\n   {Description}";
            return result.TrimEnd('\n', ' ');

        }

        public string ToShortString()
        {
            return $"{Title},{Date},{Priority},{Description}";
        }

        public static Item Parse(string line)
        {
            //title, date, priority, description
            string[] parts = line.Split(',');
            if (parts.Length > 0) {
                string title = parts[0];
                string date = parts[1];
                bool priority = Boolean.Parse(parts[2]);
                string description = parts[3];
                return new Item(title, date, priority, description);
            }
            else
            {
                throw new FormatException("Invalid item format. Items should follow the format: title,date,priority,description");
            }

        }
    }
}
