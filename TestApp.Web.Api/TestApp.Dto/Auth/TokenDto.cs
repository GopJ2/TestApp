using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Dto.Auth
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
