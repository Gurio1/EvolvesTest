using FastEndpoints;
using MediatR;

namespace SimpleApp.Features.Notes.GetAll;

public class GetAllNotesEndpoint : EndpointWithoutRequest
{
    private readonly IMediator _mediator;

    public GetAllNotesEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("/notes");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var getAllNotesQuery = new GetAllNotesQuery();

        var result = await _mediator.Send(getAllNotesQuery, ct);

        await SendOkAsync(result, ct);
    }
}