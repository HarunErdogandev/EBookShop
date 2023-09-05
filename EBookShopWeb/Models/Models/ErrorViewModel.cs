namespace EBookShopWeb.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public string ErrorMessage => "Default message";
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Password { get; set; }



        void UserForRegister(string password,string name)
        {
            string[] characters = { "a", "S", "@", "-" };

            

             
        }






    }
}