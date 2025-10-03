namespace Domain.DTO.Services.ResultsError
{
    public record ReasonMetadata(
        string ErrorCode,
        string FieldName,
        string AttemptedValue);
}