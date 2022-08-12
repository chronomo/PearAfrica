using System;

namespace Pear.Africa.Assessment.Common.Features.Jwt
{
    public class RefreshToken
    {
        public string UserName { get; set; }     

        public string TokenString { get; set; }

        public DateTime ExpireAt { get; set; }
    }
}