using Reckon.Core.Interfaces;
using Reckon.Core.ModelDto;
using Reckon.Infrastructure.ResponseModel;

namespace Reckon.Infrastructure
{
    public class ReckonApiService : IReckonApiService
    {

        private readonly ReckonApiClient _reckonApiClient;
        public ReckonApiService(ReckonApiClient reckonApiClient)
        {
            _reckonApiClient = reckonApiClient;
        }

        public async Task<SubTextResponse?> getSubTextAsync()
        {
            var subtext = await _reckonApiClient.getSubTextAsync();
            return subtext;
        }

        public async Task<TextToSearch?> getTextToSearchAsync()
        {
            var textToSearch = await _reckonApiClient.getTextToSearchAsync();
            return textToSearch;
        }

        public async Task<Task> postSearchResultAsync(ReckonPostRequestDTO data) 
        {
                return await _reckonApiClient.postSearchResultAsync(data);
        }
           

    }
}
