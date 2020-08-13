using System;
using System.Collections.Generic;

namespace KalaGhar.Models
{
    public class Message : BaseEntity
    {
        public string CraftOwnerUserId { get; set; }
        public string CraftId { get; set; }
        public string Text { get; set; }

        public DateTime CreatedDateTime { get; set; }


        public Craft Craft { get; set; }
        public ApplicationUser User { get; set; }

        public string SenderUserId { get; set; }

        public ICollection<Reply> Replies { get; set; }

    }

    public class Reply : BaseEntity
    {
        public string MessageId { get; set; }
        public string ReplyText { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }
}
