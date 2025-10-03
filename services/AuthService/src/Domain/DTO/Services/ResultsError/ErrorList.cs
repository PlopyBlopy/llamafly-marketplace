using FluentResults.Errors;

namespace Domain.DTO.Services.ResultsError
{
    public record ErrorList(string Message, ErrorType ErrorType, List<ErrorDetail> Reasons);
}