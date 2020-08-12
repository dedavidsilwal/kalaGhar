namespace KalaGhar.Models
{
    public class CraftView : BaseEntity
    {
        public string CraftId { get; set; }
        public string UserId { get; set; }
        public string PublicIP { get; set; }

        public Craft Craft { get; set; }
    }
}
