namespace KalaGhar.Models
{
    public class Message
    {
        public string UserId { get; set; }
        public string CraftId { get; set; }
        public string Text { get; set; }

        public string ReceivedDate { get; set; }


        public Craft Craft { get; set; }
        public ApplicationUser User { get; set; }

    }

    public class Reply
    {

    }
}
