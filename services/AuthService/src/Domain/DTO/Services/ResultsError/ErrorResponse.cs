namespace Domain.DTO.Services.ResultsError
{
    public record ErrorResponse(
        string Type,
        string Title,
        int Status,
        List<ErrorList> Reason,
        string TraceId);
}