namespace KalaGhar.Models
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string DisplayName { get; set; }


        public string CraftId { get; set; }
    }
}
