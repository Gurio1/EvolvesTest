using FastEndpoints;
using MediatR;
using SimpleApp.Entities;

namespace SimpleApp.Features.Notes.Get;

public class GetNoteByIdEndpoint : Endpoint<GetNoteByIdRequest,Note>
{
    private readonly IMediator _mediator;

    public GetNoteByIdEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override void Configure()
    {
        Get("/notes/{Id}");
        AllowAnonymous();
        Description(x => x.Accepts<GetNoteByIdRequest>());

    }

    public override async Task HandleAsync(GetNoteByIdRequest req, CancellationToken ct)
    {
        var getNoteByIdQuery = new GetNoteByIdQuery(req.Id);

        var note = await _mediator.Send(getNoteByIdQuery, ct);

        if (note is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(note, ct);
    }
}