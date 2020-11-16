using Microsoft.AspNetCore.Hosting;
using NaturalPersonReference.Models;
using System;
using System.IO;

namespace NaturalPersonReference.Factories
{
    public class PictureModelFactory : IPictureModelFactory
    {
        private IWebHostEnvironment _webHostEnvironment;
        public PictureModelFactory(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async void PreparePictureModel(PictureModel model)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(model.PictureFile.FileName);
            string extension = Path.GetExtension(model.PictureFile.FileName);
            model.Name = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            model.PicurePath = Path.Combine(wwwRootPath + "/Image/", fileName);
            using (var fileStream = new FileStream(model.PicurePath, FileMode.Create))
            {
                await model.PictureFile.CopyToAsync(fileStream);
            }
        }
    }
}
