namespace Domain.Models.Profile
{
    public class ProfileModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ProfileModel(Guid id, Guid userId, string name, string surname, string? patronymic, int age, bool gender, DateTime updatedAt)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Age = age;
            Gender = gender;
            UpdatedAt = updatedAt;
        }
    }
}