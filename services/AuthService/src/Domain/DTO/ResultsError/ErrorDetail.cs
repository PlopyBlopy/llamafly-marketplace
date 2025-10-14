namespace Domain.DTO.ResultsError
{
    public record ErrorDetail(
        List<Reason> Reasons,
        string Message,
        ErrorMetadata Metadata);
}