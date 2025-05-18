namespace cp2.Application.DTOs.Response
{
    public class UsuarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public List<MotoResponse> Motos { get; set; } = new();
    }
}
