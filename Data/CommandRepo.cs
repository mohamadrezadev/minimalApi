using Microsoft.EntityFrameworkCore;
using MyAPi.Models;

namespace MyAPi.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;

        public CommandRepo(AppDbContext context)
        {
            _context=context;
        }
        public async Task CreateCommand(Command command)
        {
            if(command==null)
            {
                throw new ArgumentNullException(nameof(command));

            }
            await _context.AddAsync(command);
        }

        public  void DeletCommand(Command command)
        {
            if(command==null)
            {
                throw new ArgumentNullException(nameof(command));

            }
            _context.Commands.Remove(command);

        }

        public async Task<IEnumerable<Command>> GEtAllCommands()
        {
            return await _context.Commands!.ToListAsync();
        }

        public async Task<Command?> GetCommandbyId(int Id)
        {
            return await _context.Commands.FirstOrDefaultAsync(c=>c.Id ==Id);
        }

        public async Task SavaChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}