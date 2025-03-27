using FastEndpoints;
using MediatR;
using SimpleApp.Entities;
using SimpleApp.Features.Notes.Delete;

namespace SimpleApp.Features.Notes.Edit;

public class EditNoteEndpoint : Endpoint<EditNoteRequest>
{
    private readonly IMediator _mediator;

    public EditNoteEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public override void Configure()
    {
        Put("/notes/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EditNoteRequest req, CancellationToken ct)
    {
        var note = new Note()
        {
            Id = req.Id,
            Title = req.Title,
            Content = req.Content
        };

        var editCommand = new EditNoteCommand(note);

        var result = await _mediator.Send(editCommand, ct);

        await SendOkAsync(result, ct);
    }
}