namespace Ipuc.Models
{
    using SQLite;
    using System;

    public class Members
    {
        [PrimaryKey]
        public string Identificacion { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Direccion { get; set; }
        public bool Bautizado { get; set; }
        public string FullName { get; set; }
        public string IsBautizado { get; set; }

        public override int GetHashCode()
        {
            return Convert.ToInt32(Identificacion);
        }
    }
}
