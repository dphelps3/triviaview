using System.Data;
using TriviaLink.Models;
using Microsoft.EntityFrameworkCore;
using TriviaLink.Data;

namespace TriviaLink.Services
{
    public class CodeGeneratorService : ICodeGeneratorService
    {
        private readonly ApplicationDbContext _context;

        public CodeGeneratorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public static string GenerateCode()
        {
            Random rand = new Random();

            int stringlength = 4;
            int randValue;
            string str = String.Empty;
            char letter;

            for (int i = 0; i < stringlength; i++)
            {
                randValue = rand.Next(0, 26);

                letter = Convert.ToChar(randValue + 65);

                str = str + letter;
            }

            return str;
        }

        public async Task<string> GenerateUniqueCode()
        {
            string code = string.Empty;
            bool isMatch = true;

            while (isMatch == true)
            {
                code = GenerateCode();
                isMatch = await GameCodeMatchExisting(code);
            }
            return code;
        }

        public async Task<bool> GameCodeMatchExisting(string newGameCode)
        {
            var existingGameCodes = await _context.Game.Select(x => x.GameCode).ToListAsync();

            if (existingGameCodes.Any(x => x == newGameCode))
            {
                return true;
            }
            return false;
        }
    }
}
