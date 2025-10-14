namespace Domain.DTO.ResultsError
{
    public record ReasonMetadata(
        string ErrorCode,
        string FieldName,
        string AttemptedValue);
}
