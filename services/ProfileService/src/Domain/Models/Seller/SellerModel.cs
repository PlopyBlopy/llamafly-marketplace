namespace Domain.Models.Seller
{
    public class SellerModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? ShopId { get; set; }
        public Guid? CompanyId { get; set; }
        public string EmailContact { get; set; }
        public string PhoneContact { get; set; }
        public DateTime UpdatedAt { get; set; }

        public SellerModel(Guid id, Guid userId, Guid? shopId, Guid? companyId, string emailContact, string phoneContact, DateTime updatedAt)
        {
            Id = id;
            UserId = userId;
            ShopId = shopId;
            CompanyId = companyId;
            EmailContact = emailContact;
            PhoneContact = phoneContact;
            UpdatedAt = updatedAt;
        }
    }
}