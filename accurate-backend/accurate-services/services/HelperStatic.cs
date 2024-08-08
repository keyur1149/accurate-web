using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accurate_services.services
{
    public static class HelperStatic
    {
        private static string GetFilenameWithoutExtension(string fileName)
        {
            int lastDotIndex = fileName.LastIndexOf('.');
            return lastDotIndex == -1 ? fileName : fileName.Substring(0, lastDotIndex);
        }
        public static Tuple<bool, string> UploadFile(IFormFile file)
        {
            if (file == null)
            {
                return Tuple.Create(false, "File is null.");
            }

            try
            {
                string rootFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                if (!Directory.Exists(rootFolder))
                {
                    Directory.CreateDirectory(rootFolder);
                }
                string uploadsFolder = Path.Combine(rootFolder, "CategoryImage");
                // Ensure the uploads directory exists
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string fileName = $"{GetFilenameWithoutExtension(file.FileName)}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                string path = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return Tuple.Create(true, fileName);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return Tuple.Create(false, $"File upload failed: {ex.Message}");
            }
        }
    }
}
