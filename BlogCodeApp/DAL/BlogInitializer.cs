using BlogCodeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogCodeApp.DAL
{
    public class BlogInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BlogCodeAppContext>
    {
        protected override void Seed(BlogCodeAppContext context)
        {
            var bloggers = new List<Blogger>
            {
            new Blogger{Username="Carson",Email="test@gmail.com",Password="aaaaaA_1",ConfirmPassword="aaaaaA_1"},
            new Blogger{Username="Meredith",Email="test1@gmail.com",Password="aaaaaA_1",ConfirmPassword="aaaaaA_1"},
            new Blogger{Username="Arturo",Email="test2@gmail.com",Password="aaaaaA_1",ConfirmPassword="aaaaaA_1"},
            new Blogger{Username="Gytis",Email="test3@gmail.com",Password="aaaaaA_1",ConfirmPassword="aaaaaA_1"},
            new Blogger{Username="Yan",Email="test4@gmail.com",Password="aaaaaA_1",ConfirmPassword="aaaaaA_1"},
            new Blogger{Username="Peggy",Email="test5@gmail.com",Password="aaaaaA_1",ConfirmPassword="aaaaaA_1"},
            new Blogger{Username="Laura",Email="test6@gmail.com",Password="aaaaaA_1",ConfirmPassword="aaaaaA_1"},
            new Blogger{Username="Nino",Email="test7@gmail.com",Password="aaaaaA_1",ConfirmPassword="aaaaaA_1"}
            };
            bloggers.ForEach(s => context.Bloggers.Add(s));
            context.SaveChanges();

            var blogs = new List<Blog>
            {
            new Blog{BloggerID=1,Title="Title1",Text="Sample text"},
            new Blog{BloggerID=1,Title="Title2",Text="Sample text"},
            new Blog{BloggerID=1,Title="Title3",Text="Sample text"},
            new Blog{BloggerID=2,Title="Title4",Text="Sample text"},
            new Blog{BloggerID=2,Title="Title5",Text="Sample text"},
            new Blog{BloggerID=2,Title="Title6",Text="Sample text"},
            new Blog{BloggerID=3,Title="Title7"},
            new Blog{BloggerID=4,Title="Title8",Text="Sample text"},
            new Blog{BloggerID=4,Title="Title9",Text="Sample text"},
            new Blog{BloggerID=5,Title="Title9",Text="Sample text"},
            new Blog{BloggerID=6,Title="Title11",Text="Sample text"},
            new Blog{BloggerID=7,Title="Title12",Text="Sample text"},
            };
            blogs.ForEach(s => context.Blogs.Add(s));
            context.SaveChanges();

        }
    }
}