namespace Domain
{
    using System.ComponentModel.DataAnnotations.Schema;

    [NotMapped]
    public class UserView
    {
        public byte[] ImageArray { get; set; }
        public string Password { get; set; }
    }
}
