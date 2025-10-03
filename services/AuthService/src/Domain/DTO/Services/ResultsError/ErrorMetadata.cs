namespace Domain.DTO.Services.ResultsError
{
    public record ErrorMetadata(
        string ErrorCode,
        string FieldName,
        string AttemptedValue);
}