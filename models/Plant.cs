using System.ComponentModel.DataAnnotations;

namespace SOA_CA2.models
{
    public class Plant
    {

        [Key] public int plant_id { get; set; }
        public string? plant_name { get; set; }
        public string? plant_type { get; set; }
        public float? plant_price { get; set; }

    }
}
