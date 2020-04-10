using System.Collections.Generic;

namespace Habitat.Images
{
    public interface IImageSearch
    {
        List<string> GetImageUrls(string searchPhrase);
    }
}