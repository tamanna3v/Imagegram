using Abp.Domain.Repositories;
using Imagegram.Authorization.Users;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Imagegram
{
    public class ImagegramManager : IImagegramManager
    {
        private readonly IRepository<Post, long> _postRepository;
        private readonly IRepository<Comments, long> _commentRepository;
        private readonly IHostingEnvironment _env;

        public ImagegramManager(IRepository<Post, long> postRepository,
            IRepository<Comments, long> commentRepository,
            IHostingEnvironment env)
        {
            _env = env;
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        public async Task DeleteAllObjects(User user)
        {
            await DeleteComments(user);
            await DeleteTemporaryImage(user);
            await DeletePosts(user);
        }

        private async Task DeleteComments(User user)
        {
            var comments = _commentRepository.GetAll().Where(t => t.CreatorUserId == user.Id);
            foreach (var item in comments)
            {
                await _commentRepository.DeleteAsync(item);
            }
        }

        private async Task DeletePosts(User user)
        {
            var posts = _postRepository.GetAll().Where(t => t.CreatorUserId == user.Id);
            foreach (var item in posts)
            {
                await _postRepository.DeleteAsync(item);
            }
        }

        public Task DeleteTemporaryImage(User user)
        {
            try
            {
                var postImages = _postRepository.GetAll().Where(t => t.CreatorUserId == user.Id).Select(t => t.Image);
                foreach (var item in postImages)
                {
                    List<string> imageCollection = item?.Split(',').ToList();
                 
                    if (imageCollection != null)
                    {
                        foreach (var imageFileName in imageCollection)
                        {
                            var tempFileDownloadFolder = Path.Combine(_env.WebRootPath, $"Temp{Path.DirectorySeparatorChar}Downloads");

                            string tempFilePath = Path.Combine(tempFileDownloadFolder, imageFileName);

                            File.Delete(tempFilePath);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return Task.CompletedTask;
        }
    }
}
