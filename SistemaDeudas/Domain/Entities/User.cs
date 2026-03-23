
namespace SistemaDeudas.Domain.Entities
{
    public class User
    {
        public int IdUser { get; private set; }
        public string Name { get; private set; }
        public string MiddleName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        private readonly List<Account> _accounts = new();
        public IReadOnlyCollection<Account> Accounts => _accounts;

        protected User() { }

        public User(int idUser, string name, string middleName, string email, string password)
        {
            IdUser = idUser;
            Name = name;
            MiddleName = middleName;
            Email = email;
            Password = password; //Cambiarlo por un hash de la contraseña para mayor seguridad
        }

        public void AddAcount(Account account)
        {
            _accounts.Add(account);
        }
    }
}
