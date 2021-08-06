using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppcentNetCase.Models.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Text { get; set; }
        public int ProjectID { get; set; }
        public virtual Project Projects { get; set; }
    }
}
