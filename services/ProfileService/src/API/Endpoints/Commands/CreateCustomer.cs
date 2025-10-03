using API.Infrastructure;
using AutoMapper;
using Domain.Commands;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands
{
    public class CreateCustomer : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.CREATE_CUSTOMER,
                async ([FromBody] CreateCustomerRequest request,
                       ISender sender,
                       IMapper mapper,
                       CancellationToken cancellationToken) =>
                {
                    var command = mapper.Map<CreateCustomerCommand>(request);
                    Result<CreateCustomerResponse> result = await sender.Send(command, cancellationToken);

                    return result.Match(
                        success => Results.Created(Routes.CREATE_CUSTOMER, success),
                        error => CustomResults.Problem(error)
                    );
                }).WithTags(Tags.PROFILE);
        }
    }
}