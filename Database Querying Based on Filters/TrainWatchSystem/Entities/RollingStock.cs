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
    [Table("RollingStock")]
    public class RollingStock
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [StringLength(24, ErrorMessage ="Reporting Mark must be under 24 characters.")]
        public string ReportingMark { get; set; }

        [StringLength(50, ErrorMessage = "Owner  must be under 24 characters.")]
        public string Owner { get; set; }

        public int LoadLimit { get; set; }

        public int? Capacity { get; set; }

        public int LightWeight { get; set; }

        public int? RailCarTypeId { get; set; }

        public bool InService { get; set; }

        [StringLength(24, ErrorMessage = "Reporting Mark must be under 24 characters.")]
        public string Notes{ get; set; }
    }
}
