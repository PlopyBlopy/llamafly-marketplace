namespace Domain.Models.Companies
{
    public class CompanyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneContact { get; set; }
        public string EmailContact { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public CompanyModel(Guid id, string name, string emailContact, string phoneContact, DateTime updatedAt, DateTime createdAt)
        {
            Id = id;
            Name = name;
            EmailContact = emailContact;
            PhoneContact = phoneContact;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
        }
    }
}