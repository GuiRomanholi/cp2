namespace cp2.Domain.Entity
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }

        public ICollection<Moto> Motos { get; private set; } = new List<Moto>();

        public Usuario(string nome, string email)
        {
            Id = Guid.NewGuid();
            SetNome(nome);
            SetEmail(email);
        }

        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.");
            Nome = nome;
        }

        public void SetEmail(string email)
        {
            if (!email.Contains("@"))
                throw new ArgumentException("Email inválido.");
            Email = email;
        }
    }
}
