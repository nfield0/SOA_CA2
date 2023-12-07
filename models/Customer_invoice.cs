using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SOA_CA2.models
{
    public class Customer_invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int customer_id { get; set; }
        public int plant_id { get; set; }
        public DateTime date_time_purchased {get; set; }
        public string customer_delivery_address { get; set; } = "";

        public int quantity { get;set; }

    }
}
