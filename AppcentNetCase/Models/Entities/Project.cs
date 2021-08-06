using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppcentNetCase.Models.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectTitle { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Text { get; set; }
        public virtual List<Tasks> Tasks { get; set; }
    }
}
