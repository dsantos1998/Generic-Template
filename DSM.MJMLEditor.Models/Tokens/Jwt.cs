namespace DSM.MJMLEditor.Domain.Models.Tokens
{
    public class Jwt
    {
        public required string Key { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public required string Subject { get; set; }
        public int DurationTime { get; set; }
    }
}
