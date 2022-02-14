using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS_Library.Models {
   public class RequestLine {
        public int Id { get; set; }
        [Required]
        public int RequestId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public int PropId { get; set; }
        public virtual Request Request { get; set; }
        [Required]
        public int Quantity { get; set; } = 1;


        public RequestLine() { }
    }
}
