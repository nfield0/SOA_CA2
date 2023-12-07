using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOA_CA2.models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int customer_id { get; set; }
        public string first_name { get; set; } = "";
        public string last_name { get; set; } = "";
        public string email_address { get; set; } = "";
        public string phone_num { get; set; } = "";

    }
}
