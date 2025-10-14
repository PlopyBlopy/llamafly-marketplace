namespace Domain.Models
{
    public static class CommonConstraints
    {
        public enum RoleVariants
        {
            Admin = 0,
            Seller = 1,
            Customer = 2,
        }

        public enum LoginVariants
        {
            Login = 0,
            PhoneNumber = 1,
            Email = 2,
        }
    }
}