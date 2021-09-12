using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using Imagegram.Imagegram.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Imagegram
{

    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    public class ImagegramAppService : ApplicationService, IImagegramAppService
    {
        private readonly IRepository<Post, long> _postRepository;
        private readonly IRepository<Comments, long> _commentsRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postRepository"></param>
        /// <param name="commentsRepository"></param>
        public ImagegramAppService(IRepository<Post, long> postRepository,
            IRepository<Comments, long> commentsRepository
        )
        {
            _commentsRepository = commentsRepository;
            _postRepository = postRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<long> CreateComments(CommentsInputDto input)
        {
            var comments = new Comments();
            ObjectMapper.Map<CommentsInputDto, Comments>(input, comments);
            return _commentsRepository.InsertAndGetIdAsync(comments);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<long> CreatePost(PostInputDto input)
        {
            try
            {
                var posts = new Post();
                ObjectMapper.Map(input, posts);
                return await _postRepository.InsertAndGetIdAsync(posts);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public async Task<PagedPostResultDto> GetAllPostsWithComments(Pagination input)
        {
            (List<Post>, Pagination) posts = await QueryWithPagination(input);

            //// As a user, I should be able to get the list of all posts from all users along with last 2 comments to each post
            posts.Item1?.ForEach(a => { a.Comments = (a.Comments?.OrderByDescending(c => c.Id).Take(2).ToList()); });

            PagedPostResultDto result = new PagedPostResultDto()
            {
                Posts = new ListResultDto<PostDto>(ObjectMapper.Map<List<PostDto>>(posts.Item1)),
                Pagination = posts.Item2
            };

            return result;
        }

        private Task<(List<Post>, Pagination)> QueryWithPagination(Pagination input)
        {
            Pagination page;
            List<Post> posts;
            int limit = 10;
            ////Posts should be sorted by the number of comments (desc)
            var query =_postRepository.GetAllIncluding(x => x.Comments)
                                .OrderByDescending(c => c.Comments.Count)
                                .ThenByDescending(c => c.Id)
                                .AsEnumerable()
                                .Select((row, i) => new { Post = row, Index = i });

            if (input.After.HasValue)
            {
                // if the user specified the after parameter, return the next batch of records with a higher ID
                query = query.Where(t => t.Index > input.After);
            }
            else if (input.Before.HasValue)
            {
                // if the user specified the before parameter, return the next batch of records with a lower ID
                query = query.Where(t => t.Index < input.Before);
            }

            query = query
                  .Take(limit);

            //// Retrieve posts via a cursor - based pagination
                page = new Pagination()
            {
                After =  query?.LastOrDefault()?.Index,
                Before = query?.FirstOrDefault()?.Index,
            };

            posts = query.Select(t => t.Post)
                .ToList();

            return Task.FromResult((posts, page));
        }
    }
}
