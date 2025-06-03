using Reckon.Core.ModelDto;

namespace Reckon.Core.Interfaces
{
    public interface IResultsService
    {
        public Task<ResultsDTO> GetResultsAsync();
       
    }
}
