namespace CodeFirstRelation.Models.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
