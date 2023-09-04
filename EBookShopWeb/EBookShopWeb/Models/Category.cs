using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EBookShopWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen eklemek istediğiniz kategorinin ismini belirtin")]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }
    }
}
