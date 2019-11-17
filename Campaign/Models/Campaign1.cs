using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.Models
{
    public class Campaign1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Keywords { get; set; }
        [Range(1, 1000000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Fund { get; set; }
        [Range(1, 999999)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Bid { get; set; }
        public string Town { get; set; }
        [DisplayName("Status (ON/OFF)")]
        public bool Status { get; set; }
        [Range(1, 10000)]
        public int Radius { get; set; }
    }
}
