using System.ComponentModel.DataAnnotations;

namespace EBookShopWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Boş geçme lan")]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
