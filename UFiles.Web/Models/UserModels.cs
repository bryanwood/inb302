using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using UFiles.Domain.Entities;

namespace UFiles.Web.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public Role Role { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
    }
}