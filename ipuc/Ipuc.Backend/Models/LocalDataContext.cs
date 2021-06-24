namespace Ipuc.Backend.Models
{
    using Domain;
    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Domain.User> Users { get; set; }

        public System.Data.Entity.DbSet<Domain.UserType> UserTypes { get; set; }
        public System.Data.Entity.DbSet<Domain.Members> Members { get; set; }
    }
}