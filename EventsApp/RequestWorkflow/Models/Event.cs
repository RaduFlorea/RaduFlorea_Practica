using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RequestWorkflow.Models
{
    public class Event
    {
        public int Id { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}