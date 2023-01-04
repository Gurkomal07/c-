#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace TrainWatchSystem.Entities
{
    [Table("RailCarType")]
    public class RailCarType
    {
        [Key]
        public int RailCarTypeId { get; set; }

        [StringLength(24, ErrorMessage = "Name must be under 30 characters." , MinimumLength = 0)]
        public string Name { get; set; }

        [StringLength(24, ErrorMessage = "Commodity  must be under 100 characters.")]
        public string Commodity { get; set; }
    }
}