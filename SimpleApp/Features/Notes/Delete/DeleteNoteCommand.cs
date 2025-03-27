using MediatR;

namespace SimpleApp.Features.Notes.Delete;

public record DeleteNoteCommand(string Id) : IRequest<bool>;