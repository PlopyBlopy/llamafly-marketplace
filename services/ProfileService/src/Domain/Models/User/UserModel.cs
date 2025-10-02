namespace Domain.Models.User
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserModel(Guid id, string login, string? phoneNumber, string? email, DateTime updatedAt, DateTime createdAt)
        {
            Id = id;
            Login = login;
            PhoneNumber = phoneNumber;
            Email = email;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
        }
    }
}