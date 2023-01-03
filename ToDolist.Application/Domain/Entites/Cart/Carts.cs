using Domain.Attributes;
using Domain.Entites.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Cart
{
    [AuditTable]
    public class Cart
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool HaveNofication { get; set; }
        public DateTime? NoficationTime { get; set; }
        public bool IsCompelete { get; set; }
        public DateTime? DueComplete { get; set; }
        public ICollection<PriorityInCarts> PriorityInCarts { get; set; }
        public ICollection<StatusInCarts> StatusInCarts { get; set; }
    }

    public class Priority
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    public class Status
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    [AuditTable]
    public class PriorityInCarts
    {
        public long Id { get; set; }
        public virtual Cart Cart { get; set; }
        public long CartId { get; set; }
        public virtual Priority Priority { get; set; }
        public long PriorityId { get; set; }
    }

    [AuditTable]
    public class StatusInCarts
    {
        public long Id { get; set; }
        public virtual Cart Cart { get; set; }
        public long CartId { get; set; }
        public virtual Status Status { get; set; }
        public long StatusId { get; set; }
    }




}
