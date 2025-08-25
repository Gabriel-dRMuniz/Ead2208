namespace EAD
{
    public class Sessao
    {
        public int IdSessao { get; set; }
        public int IdFilme { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
    }
}