using Bloginary.CloudyHelper;
using Bloginary.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace Bloginary.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _config;

        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var account = new Account(
                config.Value.CloudName = "",
                config.Value.ApiKey = "",
                config.Value.ApiSecret = ""
                );
            _config = new Cloudinary( account );
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if ( file.Length>0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity(Gravity.Center)
                };
                uploadResult = await _config.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _config.DestroyAsync(deleteParams);

            return result;
        }
    }
}
