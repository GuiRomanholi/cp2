namespace cp2.Domain.Entity
{
    public class Moto
    {
        public Guid Id { get; private set; }
        public string Modelo { get; private set; }
        public string Placa { get; private set; }

        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }

        public Moto(string modelo, string placa, Guid usuarioId)
        {
            Id = Guid.NewGuid();
            SetModelo(modelo);
            SetPlaca(placa);
            UsuarioId = usuarioId;
        }

        public void SetModelo(string modelo)
        {
            if (string.IsNullOrWhiteSpace(modelo))
                throw new ArgumentException("Modelo é obrigatório.");
            Modelo = modelo;
        }

        public void SetPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                throw new ArgumentException("Placa é obrigatória.");
            Placa = placa;
        }
    }
}
