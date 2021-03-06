﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication14.Auth
{
        public interface IJwtFactory
        {
            Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity,List<string>ListRoles);
            ClaimsIdentity GenerateClaimsIdentity(string userName, string id, List<string> ListRoles);
        }
    

}
