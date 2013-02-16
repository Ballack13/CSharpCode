using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage="name should not be null")]
        public string Name { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        [Required(ErrorMessage = "Please specify whether you'll attend")]
        public bool? WillAttend { set; get; }
    }
}