using Microsoft.AspNetCore.Http;

namespace NaturalPersonReference.Models
{
    public class PictureModel
    {
        public string Name { get; set; }
        public string PicurePath { get; set; }
        public IFormFile PictureFile { get; set; }
    }
}
