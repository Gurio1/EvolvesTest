using MediatR;
using SimpleApp.Entities;

namespace SimpleApp.Features.Notes.Edit;

public record EditNoteCommand(Note Note) : IRequest<Note>;