﻿using MyUtil.Token.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyUtil.Token.Backend
{
    public class Credential : GenericIdentity
    {
        public TokenData Token { get; set; }
        public string ApplicationCode { get; set; }
        public Credential(string name) : base(name) { }
    }
}