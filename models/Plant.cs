using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOA_CA2.models
{
    public class Plant
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int plant_id { get; set; }
        public string? plant_name { get; set; }
        public string? plant_type { get; set; }
        public double? plant_price { get; set; }

    }
}
