using System.Threading.Tasks;
using CSharpWars.ScriptProcessor.Helpers;

namespace CSharpWars.ScriptProcessor.Middleware.Interfaces
{
    public interface IPreprocessor
    {
        Task Go(ProcessingContext context);
    }
}