using System;
using System.ComponentModel.DataAnnotations;

namespace PRS_Library {
    public class User {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [Required]
        [StringLength(30)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(30)]
        public string Lastname { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        public bool IsReviewer { get; set; }
        [Required]
        public bool IsAmin { get; set; }

        public User() { }
    }
}
