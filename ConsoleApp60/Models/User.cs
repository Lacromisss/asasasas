using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    internal class User
    {
        List<User> Users { get; set; }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

    }
}