using Furion.DatabaseAccessor;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Ticket.Entity;

namespace 通用订票.Core.Entity
{
    public class Ticket : TicketBase<Guid>,IEntity,IEntityTypeBuilder<Ticket>
    {
        public Guid id { get; set; }
        public int _id { get; set; }
        public DateTime? createTime { get; set; }
        public bool isDeleted { get; set; }
        public Guid AppointmentId { get; set; }
        /// <summary>
        /// 购票人选择的用户
        /// </summary>
        public Guid TUserId { get; set; }
        public UserInfo userInfo { get; set; }

        public void Configure(EntityTypeBuilder<Ticket> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a._id );

            entityBuilder.HasIndex(a => new { a.startTime,a.endTime });


            entityBuilder.Property(x => x._id).ValueGeneratedOnAdd();
            entityBuilder.HasQueryFilter(a => a.isDeleted == false);
            entityBuilder.HasOne(a => a.userInfo).WithMany().HasForeignKey(a => a.TUserId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
