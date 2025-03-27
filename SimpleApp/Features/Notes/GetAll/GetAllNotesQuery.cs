using MediatR;
using SimpleApp.Entities;

namespace SimpleApp.Features.Notes.GetAll;

public record GetAllNotesQuery : IRequest<IEnumerable<Note>>;