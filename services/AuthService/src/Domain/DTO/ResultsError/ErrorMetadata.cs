namespace Domain.DTO.ResultsError
{
    public record ErrorMetadata(
        string ErrorCode,
        string FieldName,
        string AttemptedValue);
}
