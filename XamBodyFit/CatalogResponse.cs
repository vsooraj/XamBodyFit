
using System.Collections.Generic;
namespace XamBodyFit
{
    public class CatalogResponse
    {
        public Response Response { get; set; }
        public virtual List<Video> Videos { get; set; }
        public string AuthToken { get; set; }
    }
}
