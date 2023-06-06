using Blog.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Blog
{
    public static class BlogService
    {
        public static ICollection<NumberOfCommentsDto> NumberOfCommentsPerUser(MyDbContext context)
        {
            return context.BlogComments
               .GroupBy(c => c.UserName)
               .Select(c => new NumberOfCommentsDto { UserName = c.Key, NumberOfComments = c.Count() })
               .OrderBy(c => c.NumberOfComments)
               .ToList();
        }

        public static ICollection<PostDto> PostsOrderedByLastCommentDate(MyDbContext context)
        {
            return context.BlogPosts
               .OrderByDescending(p => p.Comments.OrderByDescending(c => c.CreatedDate).First().CreatedDate)
               .Select(p => new PostDto(p))
               .ToList();
        }

        public static ICollection<NumberOfCommentsDto> NumberOfLastCommentsLeftByUser(MyDbContext context)
        {
            return context.BlogComments
               .Where(c => c.CreatedDate == c.BlogPost.Comments.Max(c => c.CreatedDate))
               .GroupBy(c => c.UserName)
               .Select(c => new NumberOfCommentsDto { UserName = c.Key, NumberOfComments = c.Count() })
               .OrderBy(c => c.NumberOfComments)
               .ToList();
        }
    }
}
