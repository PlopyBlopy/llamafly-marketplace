using Domain.DTO.ResultsError;
namespace Domain.DTO.ResultsError
{
    public record Reason(
        string Message,
        ReasonMetadata Metadata);
}
