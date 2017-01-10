﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Stove.Domain.Entities.Auditing;

namespace Stove.Tests.SampleApplication.Domain.Entities
{
    [Table(nameof(Order))]
    public class Order : CreationAuditedAggregateRoot<long, User>
    {
        [ForeignKey("OrderId")]
        public virtual ICollection<OrderDetail> OrderProducts { get; set; }
    }
}