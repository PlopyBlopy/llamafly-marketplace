namespace Domain.DTO.Services.ResultsError
{
    public record Reason(
        string Message,
        ReasonMetadata Metadata);
}