using System;

namespace Blog.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public CommentDto(BlogComment comment)
        {
            Id = comment.Id;
            Text = comment.Text;
            CreatedDate = comment.CreatedDate;
        }
    }
}
