using System.Collections.Generic;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using System;

namespace Blog.DAL.Repository
{
    public class BlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository()
        {
            _context = new BlogContext();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts;
        }

        public IEnumerable<Comments> GetAllComments()
        {
            return _context.Comments;
        }

        public void AddPost()
        {
            Post post = new Post();
            post.Content = "sdfniawehf";
            post.Author = "Ewelina";
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void AddBadPost()
        {
            Post post = new Post();
            post.Content = "sdfniawehf";

            throw new Exception();
        }

        public void AddComment()
        {
            Comments comment = new Comments();
            comment.Content = "hah ha ha ha... :D";
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
