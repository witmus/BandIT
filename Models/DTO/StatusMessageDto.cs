namespace BandIT.Models.DTO
{
    public struct StatusMessageDto
    {
        public string? Status { get; init; }
        public string? Message { get; init; }

        public StatusMessageDto(string status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
