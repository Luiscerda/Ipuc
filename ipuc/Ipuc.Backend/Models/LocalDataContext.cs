namespace Ipuc.Backend.Models
{
    using Domain;
    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Domain.User> Users { get; set; }
    }
}