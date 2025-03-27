using FastEndpoints;
using MediatR;

namespace SimpleApp.Features.Notes.Delete;

public class DeleteNoteEndpoint : Endpoint<DeleteNoteRequest>
{
    private readonly IMediator _mediator;

    public DeleteNoteEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Delete("/notes/{Id}");
        AllowAnonymous();
        Description(x => x.Accepts<DeleteNoteRequest>());
    }

    public override async Task HandleAsync(DeleteNoteRequest req, CancellationToken ct)
    {
        var deleteCommand = new DeleteNoteCommand(req.Id);

        var result = await _mediator.Send(deleteCommand, ct);

        if (result)
        {
            await SendNoContentAsync(ct);
            return;
        }
        
        ThrowError("Could not delete note from database");
    }
}