using MediatR;
using SimpleApp.Entities;

namespace SimpleApp.Features.Notes.Get;

public record GetNoteByIdQuery(string Id) : IRequest<Note?>;