using System;
using System.Collections.Generic;
using System.Text;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public class RefreshTokenDto : BaseDto
    {
        public string Token { get; set; }

        public string UserId { get; set; }

        public DateTime Expires { get; set; }
        public int CurrentState { get; set; }
    }
}
