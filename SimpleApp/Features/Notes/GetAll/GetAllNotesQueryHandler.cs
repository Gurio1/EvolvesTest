using Dapper;
using MediatR;
using SimpleApp.Database;
using SimpleApp.Entities;

namespace SimpleApp.Features.Notes.GetAll;

public class GetAllNotesQueryHandler : IRequestHandler<GetAllNotesQuery,IEnumerable<Note>>
{
    private readonly IDbConnectionFactory _connectionFactory;

    public GetAllNotesQueryHandler(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    public async Task<IEnumerable<Note>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        return await connection.QueryAsync<Note>(
            @"SELECT * FROM Notes");
    }
}