namespace ShopWithASP.NETCore.Doima.Entities.Users
{
    public class Role
    {
        public long  RoleId { get; set; }
        public string Name { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
