namespace KalaGhar.Models
{
    public class Wish
    {
        public string UserId { get; set; }
        public string CraftId { get; set; }

        public Craft Craft { get; set; }
        public ApplicationUser User { get; set; }
         
    }
}
