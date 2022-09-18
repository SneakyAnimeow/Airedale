namespace Airedale.Database.Model
{
    public partial class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string PassHash { get; set; } = null!;
        public string? Token { get; set; }
    }
}
