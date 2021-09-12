using Abp.Authorization;
using Abp.IO;
using Abp.IO.Extensions;
using Abp.UI;
using Imagegram.Imagegram;
using Imagegram.Imagegram.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Controllers
{
    [AbpAuthorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ImagegramController : ImagegramControllerBase
    {
        private readonly IHostingEnvironment _env;
        private readonly ImagegramAppService _imagegramService;

        public ImagegramController(IHostingEnvironment env,
            ImagegramAppService imagegramService)
        {
            _imagegramService = imagegramService;
            _env = env;
        }
        /// <summary>
        /// creates post with image
        /// </summary>
        /// <param name="input"></param>
        /// <param name="file"></param>
        /// <returns></returns>
      [HttpPost]
       public async Task<JsonResult> CreatePostWithImage([FromQuery] PostInputDto input, IFormFileCollection files)
        {
            List<string> fileNames = new List<string>();

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file.FileName);
                string[] fileType = { ".jpg", ".png", ".bmp" };

                if (!fileType.Contains(fileInfo.Extension))
                    throw new UserFriendlyException("Please upload an image.");

                byte[] fileBytes;
                using (var stream = file.OpenReadStream())
                {
                    fileBytes = stream.GetAllBytes();
                }

                //Save new picture
                var tempFileName = Guid.NewGuid().ToString() + ".jpg";
                var tempFileDownloadFolder = Path.Combine(_env.WebRootPath, $"Temp{Path.DirectorySeparatorChar}Downloads");
                DirectoryHelper.CreateIfNotExists(tempFileDownloadFolder);

                var tempFilePath = Path.Combine(tempFileDownloadFolder, tempFileName);
                System.IO.File.WriteAllBytes(tempFilePath, fileBytes);
                fileNames.Add(tempFileName);
            }

            input.Image = string.Join(',', fileNames);

            await _imagegramService.CreatePost(input);
            return Json(input);
        }
    }
}
