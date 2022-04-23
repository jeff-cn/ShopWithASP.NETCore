namespace ShopWithASP.NETCore.Doima.Entities.Users
{
    public class UserInRole
    {
        public long UserInRoleId { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public virtual Role Role { get; set; }
        public long RoleId { get; set; }
    }
}
