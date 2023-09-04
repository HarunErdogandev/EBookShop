namespace EBookShopWeb.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public string ErrorMessage => "Hata Aldýn bebek";
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}