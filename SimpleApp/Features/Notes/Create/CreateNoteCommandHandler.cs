using Dapper;
using MediatR;
using SimpleApp.Database;
using SimpleApp.Entities;

namespace SimpleApp.Features.Notes.Create;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand,Note>
{
    private readonly IDbConnectionFactory _connectionFactory;

    public CreateNoteCommandHandler(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory; 
    }

    public async Task<Note> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        var note = new Note()
        {
            Title = request.Title,
            Content = request.Content
        };

        var result = await connection.ExecuteAsync(
            @"INSERT INTO Notes (Id, Title, Content) 
            VALUES (@Id, @Title, @Content)",
            note);

        if (result < 0)
        {
            throw new Exception($"Error while adding note with id - {note.Id} to the database");
        }

        return note;
    }
}