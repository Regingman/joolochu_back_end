using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace joolochu.Model
{
    /// <summary>
    /// Заказы
    /// </summary>
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? StartPointId { get; set; }
        public Point StartPoint { get; set; }
        public int? EndPointId { get; set; }
        public Point EndPoint { get; set; }
        public DateTime StartTime { get; set; }
        public int Summ { get; set; }
    }
}
