using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AfsluttendeUmbracoProjekt.Models
{
    public class GuestbookFormViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string GuestName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string EntryText { get; set; }

    }
}