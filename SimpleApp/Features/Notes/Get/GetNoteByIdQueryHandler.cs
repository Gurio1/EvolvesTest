using Dapper;
using MediatR;
using SimpleApp.Database;
using SimpleApp.Entities;

namespace SimpleApp.Features.Notes.Get;

public class GetNoteByIdQueryHandler : IRequestHandler<GetNoteByIdQuery,Note?>
{
    private readonly IDbConnectionFactory _connectionFactory;

    public GetNoteByIdQueryHandler(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    public async Task<Note?> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<Note>(
            "SELECT * FROM Notes WHERE Id = @Id LIMIT 1", new { request.Id });
    }
}