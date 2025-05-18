namespace cp2.Application.DTOs.Request
{
    public class MotoRequest
    {
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
