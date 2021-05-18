using System;
using System.Collections.Generic;
namespace Specification
{
    public class OrderRequest
    { 
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string SenderContactNumber { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientName { get; set; }
        public string RecipientContactNumber { get; set; }
        public string Dedication { get; set; }

    }
}
