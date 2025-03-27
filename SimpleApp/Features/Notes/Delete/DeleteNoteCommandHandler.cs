using Dapper;
using MediatR;
using SimpleApp.Database;

namespace SimpleApp.Features.Notes.Delete;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand,bool>
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DeleteNoteCommandHandler(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    public async Task<bool> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        
        var result = await connection.ExecuteAsync(@"DELETE FROM Notes WHERE Id = @Id",
            new {Id = request.Id});
        return result > 0;
        
    }
}