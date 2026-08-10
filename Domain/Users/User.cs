namespace Domain.Users
{
    public class User(string email, string passwordHash, string firstName, string lastName)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Email { get; private set; } = email;

        public string PasswordHash { get; private set; } = passwordHash;

        public string FirstName { get; private set; } = firstName;

        public string LastName { get; private set; } = lastName;

        public string Role { get; private set; } = "User";
    }
}