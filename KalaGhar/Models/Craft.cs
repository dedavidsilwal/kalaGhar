using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KalaGhar.Models
{

    public class Craft : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }


        [Required(ErrorMessage = "price is required.")]

        public float Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Category is required.")]
        public string CategoryId { get; set; }


        public Category Category { get; set; }


        [Required]

        public short Quantity { get; set; }

        public bool Published { get; set; } = true;


        [Display(Name = "Validity Month")]

        [Required(ErrorMessage = "validity is required.")]

        public CraftValidityMonth Validity { get; set; }


        public CraftStatus CraftStatus { get; set; }

        public DateTime ExpiredDate => PublishDate.AddMonths((int)Validity);

        [Display(Name = "Negotiable")]

        public bool Negotiable { get; set; }

        public int Rating { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


        public ICollection<Image> Images { get; set; } = new List<Image>();

        public ICollection<Message> Messages { get; set; } = new List<Message>();

        public ICollection<CraftView> Views { get; set; } = new List<CraftView>();

    }
}
