using FluentResults.Errors;
using Domain.DTO.ResultsError;

namespace Domain.DTO.ResultsError
{
    public record ErrorList(string Message, ErrorType ErrorType, List<ErrorDetail> Reasons);
}
