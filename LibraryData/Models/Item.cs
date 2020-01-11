using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string ItemName { get; set; }
        public string Description { get; set; }
    }
}
