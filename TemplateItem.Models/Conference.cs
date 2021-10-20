using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TemplateItem.Models
{
    [Table("Conference")]
    public partial class Conference
    {
        public int Id { get; set; }
        public int ConferenceTypeId { get; set; }
        public int LocationId { get; set; }
        public string OrganizerEmail { get; set; }
        public int CategoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }

    }
}
