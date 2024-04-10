using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;

namespace 通用订票.OTA.携程.Entity
{
    public class XieChengTicket : IEntity, IEntityTypeBuilder<XieChengTicket>
    {
        public int id { get; set; }
        public int ticketId { get; set; }
        public string OTAPassengerId { get; set; }
        public string itemId { get; set; }

        public Ticket? ticket { get; set; }

        public void Configure(EntityTypeBuilder<XieChengTicket> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.id);
            entityBuilder.Property(a => a.id).ValueGeneratedOnAdd();
            entityBuilder.HasOne(a => a.ticket).WithOne().HasForeignKey<XieChengTicket>(a => a.ticketId);
        }
    }
}
