using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using Blog.DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TDD.DbTestHelpers.Yaml;
using TDD.DbTestHelpers.Core;

namespace Blog.DAL.Tests
{
    
    public class BlogFixturesModel 
    { 
        public FixtureTable<Post> Posts { get; set; } 
    }

    public class BlogFixtures : YamlDbFixture<BlogContext, BlogFixturesModel> 
    {
        public BlogFixtures() 
        { 
            SetYamlFiles("posts.yml"); 
        } 
    }

    [TestClass]
    public class RepositoryTests : DbBaseTest<BlogFixtures>
    {
        [TestMethod]
        public void GetAllPost_OnePostInDb_ReturnOnePost()
        {
            // arrange
            /*var context = new BlogContext();
            context.Database.CreateIfNotExists();
            */
            var repository = new BlogRepository();

            // -- prepare data in db 
            /*
            context.Posts.ToList().ForEach(x => context.Posts.Remove(x)); 
            context.Posts.Add(new Post 
            { 
                Author = "test1", 
                Content = "test1, test1, test1..." 
            }); 
            context.SaveChanges();
             */

            // act
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void mojTest()
        {
            // arrange
            /*var context = new BlogContext();
            context.Database.CreateIfNotExists();
            */
            var repository = new BlogRepository();

            repository.AddPost();
            // act
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(2, result.Count());
        }

        [ExpectedException (typeof(Exception))]
        [TestMethod]
        public void wymagane_pola()
        {
            // arrange
            /*var context = new BlogContext();
            context.Database.CreateIfNotExists();
            */
            var repository = new BlogRepository();

            repository.AddBadPost();
            // act
            var result = repository.GetAllPosts();

            // assert
            Assert.AreEqual(2, result.Count());
        }

        // zad 3
        [TestMethod]
        public void test_sprawdzajacy_comments()
        {
            var repository = new BlogRepository();

            repository.AddComment();
            // act
            var result = repository.GetAllComments();
            // assert
            Assert.AreEqual(2, result.Count());
        }
    }
}
