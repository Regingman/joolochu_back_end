using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace joolochu.Model
{
    /// <summary>
    /// Машина
    /// </summary>
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public int MarkId { get; set; }
        public Mark Mark { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Number { get; set; }
    }
}
