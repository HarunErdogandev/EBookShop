namespace EBookShopWeb.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public string ErrorMessage => "Hata Ald�n bebek";
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}