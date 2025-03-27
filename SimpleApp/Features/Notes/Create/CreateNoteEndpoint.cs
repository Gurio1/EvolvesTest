using FastEndpoints;
using MediatR;
using SimpleApp.Features.Notes.Get;

namespace SimpleApp.Features.Notes.Create;

public class CreateNoteEndpoint : Endpoint<CreateNoteRequest>
{
    private readonly IMediator _mediator;

    public CreateNoteEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override void Configure()
    {
        Post("/notes");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateNoteRequest req, CancellationToken ct)
    {
        var command = new CreateNoteCommand(req.Title, req.Content);

        var note = await _mediator.Send(command, ct);

        await SendCreatedAtAsync<GetNoteByIdEndpoint>(new {Id = note.Id}, note, cancellation: ct);
    }
}