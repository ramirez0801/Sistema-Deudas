namespace SistemaDeudas.DTO
{
    public class AccountDetailDto
    {
        public int IdAccount { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string UserName{ get; set; } //Se puede cambiar el nombre del usario? Como se cual es el usuario? Esta propiedad es indepediente a User?
    }
}
