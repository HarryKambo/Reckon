using Reckon.Core.Interfaces;
using Reckon.Core.ModelDto;


namespace Reckon.Core
{
    public class ResultService : IResultsService
    {
        private readonly IReckonApiService _apiService;
        
        public ResultService(IReckonApiService reckonApiService) 
        { 
            _apiService = reckonApiService;    
        }
        
        public async Task<ResultsDTO> GetResultsAsync()
        {
            var text = await _apiService.getTextToSearchAsync();
            var searchText = await _apiService.getSubTextAsync();
            
            ResultsDTO resultsDTO = new ResultsDTO();
            
            if (text != null) {
                resultsDTO.Text = text.Text;
            }
            if (searchText != null)
            {
                resultsDTO.Results = searchText.subTexts;               
            }

            var resultData = SearchText(resultsDTO);
            
            //Post result
            var postResult = new ReckonPostRequestDTO();
            postResult.Text = resultData.Text;

            foreach (var item in resultsDTO.subTexts)
            {
                ReckonPostRequestResults rec = new ReckonPostRequestResults();
                
                rec.SubText = item.Name;
                rec.Result = item.IndicesString;
                postResult.Results.Add(rec);
            }
            await _apiService.postSearchResultAsync(postResult);

            return resultData;
        }

        private ResultsDTO SearchText(ResultsDTO data)
        {
            var textToBeSearchedIn = data.Text;
            var searchItems = data.Results;
            foreach (string item in searchItems)
            {
                var result = FindIndexOfOccurrences(textToBeSearchedIn, item);
                data.subTexts.Add(result);
            }
            return data;
        }

        private SubText FindIndexOfOccurrences(string text, string searchString)
        {
           SubText indices = new SubText();
           indices.Name = searchString;

            text = text.ToLower();
            searchString = searchString.ToLower();


            for (int i = 0; i <= text.Length - searchString.Length; i++)
            {
                bool match = true;

                for (int j = 0; j < searchString.Length; j++)
                {
                    if (text[i + j] != searchString[j])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {                    
                    indices.Results.Add(i.ToString());                   
                }
              
            }
            if(indices.Results.Count == 0)
            {              
                 
                indices.Results.Add("<No Output>");
            }
                          
            return  indices;           

        }
    }
}
