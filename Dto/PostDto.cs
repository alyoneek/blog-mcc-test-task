using System;
using System.Linq;

namespace Blog.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CommentDto LastComment { get; set; }
        public PostDto(BlogPost post)
        {
            Id = post.Id;
            Title = post.Title;
            LastComment = new CommentDto(post.Comments.OrderByDescending(c => c.CreatedDate).First());
        }
    }
}
