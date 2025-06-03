using Reckon.Core.ModelDto;
using Reckon.Infrastructure.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reckon.Core.Interfaces
{
    public interface IReckonApiService
    {
        Task<TextToSearch?> getTextToSearchAsync();

        Task<SubTextResponse?> getSubTextAsync();

        Task<Task> postSearchResultAsync(ReckonPostRequestDTO data);
    }
}
