using API.Infrastructure;
using AutoMapper;
using Domain.Commands;
using FluentResults;
using MediatoR.Alternative.Lite;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Commands
{
    public class RegisterCustomer : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(Routes.REGISTER_CUSTOMER,
                async ([FromBody] RegisterCustomerRequest request,
                       ISender sender,
                       IMapper mapper,
                       CancellationToken cancellationToken) =>
                {
                    var command = mapper.Map<RegisterCustomerCommand>(request);
                    Result<RegisterCustomerResponse> result = await sender.Send(command, cancellationToken);

                    return result.Match(
                        success => Results.Created(),
                        error => CustomResults.Problem(error)
                    );
                })
                .WithTags(Tags.CUSTOMER);
        }
    }
}