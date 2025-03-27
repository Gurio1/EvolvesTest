using MediatR;
using SimpleApp.Entities;

namespace SimpleApp.Features.Notes.Create;

public record CreateNoteCommand(string Title,string Content) : IRequest<Note>;