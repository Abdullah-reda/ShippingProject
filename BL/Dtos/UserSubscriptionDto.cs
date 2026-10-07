using System;
using System.Collections.Generic;
using System.Text;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public class UserSubscriptionDto : BaseDto
    {
        public Guid UserId { get; set; }
        public Guid PackageId { get; set; }
        public DateTime SubscriptionDate { get; set; }
    }
}
