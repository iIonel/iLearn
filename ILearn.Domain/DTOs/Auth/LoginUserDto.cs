﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.DTOs.Auth
{
    public class LoginUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
