﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace WebStore.Domain.Entities.Identity
{
    /// <summary>
    /// Пользователь (переопределенная сущность)
    /// </summary>
    public class User: IdentityUser
    {
        public const string Administrator = "Admin";
        public const string AdminDefaultPassword = "AdminPassword";
    }
}