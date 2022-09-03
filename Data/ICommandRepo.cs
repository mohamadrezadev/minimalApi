
using System.Threading.Tasks;
using MyAPi.Models;
namespace MyAPi.Data
{
    public interface ICommandRepo
    {
        Task SavaChanges();
        Task<Command?> GetCommandbyId(int Id);
        Task<IEnumerable<Command>> GEtAllCommands();
        Task CreateCommand(Command command);
        void DeletCommand(Command command);

    }
}