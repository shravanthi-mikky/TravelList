using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class PaymentModel
    {
        
        public string cardHolder { get; set; }
        public string cardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }

    }
}
