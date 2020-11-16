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
        public void PreparePictureModel(PictureModel model)
        {
            if (model.PictureFile == null)
            {
                return;
            }
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(model.PictureFile.FileName);
            string extension = Path.GetExtension(model.PictureFile.FileName);
            model.Name = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string absolute = Path.Combine(wwwRootPath + "\\Image\\", fileName);
            model.PicurePath = Path.Combine("\\Image\\", fileName);
            using (var fileStream = new FileStream(absolute, FileMode.Create))
            {
                model.PictureFile.CopyTo(fileStream);
            }
        }
    }
}
