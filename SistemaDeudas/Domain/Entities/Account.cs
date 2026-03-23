using SistemaDeudas.Domain.Enums;

namespace SistemaDeudas.Domain.Entities
{
    public class Account
    {
        public int IdAccount { get; private set; }
        public string Name { get; private set; }
        public TypeAccount Type { get; set; }

        public int IdUser { get; private set; }
        public User User { get; private set; }

        private readonly List<Contact> _contactos = new();
        public IEnumerable<Contact> Contactos => _contactos.AsReadOnly();

        private readonly List<Debt> _deudas = new();
        public IEnumerable<Debt> Deudas => _deudas.AsReadOnly(); //Revisar si es necesario exponer las deudas a través de la cuenta o si se accede a ellas a través de los contactos
        //Estudiar IEnumerable y AsReadOnly
        public Account(string name, TypeAccount type, User user)
        {
            Name = name;
            Type = type;
            User = user;
            IdUser = user.IdUser;
        }
    }
}