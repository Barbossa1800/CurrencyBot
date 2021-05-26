using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyBot.Infrastructure.Database.Models
{
    public class Schedule
    {
        [Key]
        public long Id { get; set; }
        public int ChatId { get; set; }
        public DateTime Time { get; set; }
        [Required]
        public string ComandName { get; set; }
    }
}
