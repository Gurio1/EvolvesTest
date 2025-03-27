using Dapper;
using MediatR;
using SimpleApp.Database;
using SimpleApp.Entities;

namespace SimpleApp.Features.Notes.Edit;

public class EditNoteCommandHandler : IRequestHandler<EditNoteCommand,Note>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public EditNoteCommandHandler(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    public async Task<Note> Handle(EditNoteCommand request, CancellationToken cancellationToken)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        var result = await connection.ExecuteAsync(
            @"UPDATE Notes SET Title = @Title, Content = @Content WHERE Id = @Id", request.Note);

        if (result < 0)
        {
            throw new Exception($"Error while updating note with id - {request.Note.Id} to the database");
        }

        return request.Note;
    }
}