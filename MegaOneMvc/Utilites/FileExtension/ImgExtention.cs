using SixLabors.ImageSharp;

namespace MegaOneMvc.Utilites.FileExtension
{
    public static class ImgExtention
    {
        public static string RenameImg(this IFormFile file)
        {
            return Guid.NewGuid().ToString() + file.FileName;
        }

        public static void CreateImgFile(this IFormFile file, string path)
        {
            if (file == null)
            {
                return;
            }


            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fs);
            }
        }

        public static void CropImgAndSave(this IFormFile file, string path)
        {
            
            // Process the uploaded image file
            using (var image = Image.Load(file.OpenReadStream()))
            {
                // Crop the image based on the specified dimensions
                image.Mutate(x => x.Resize(440,330));

                // Save the cropped image to disk or perform further processing
                string croppedFilePath = path;
                image.Save(croppedFilePath);
            }
        }


        public static void DeleteImgFile(string path)
        {
            if (path == null)
            {
                return;
            }
            if (!File.Exists(path))
            {
                return;
            }


            File.Delete(path);
        }

        public static bool CheckImgFileType(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }
    }
}
