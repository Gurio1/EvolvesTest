using MediatR;
using SimpleApp.Entities;

namespace SimpleApp.Features.Notes.Create;

public record CreateNoteRequest(string Title,string Content);