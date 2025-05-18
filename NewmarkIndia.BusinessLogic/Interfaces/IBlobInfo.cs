using NewmarkIndia.BusinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewmarkIndia.BusinessLogic.Interfaces
{
    public interface IBlobInfo
    {
        Task<IEnumerable<BlobReponse>> GetBlobInfoAsync();
    }
}
