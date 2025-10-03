namespace Domain.DTO.Services.ResultsError
{
    public record ErrorDetail(
        List<Reason> Reasons,
        string Message,
        ErrorMetadata Metadata);
}