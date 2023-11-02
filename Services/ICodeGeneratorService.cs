
namespace TriviaLink.Services
{
    public interface ICodeGeneratorService
    {
        Task<string> GenerateUniqueCode();
    }
}
