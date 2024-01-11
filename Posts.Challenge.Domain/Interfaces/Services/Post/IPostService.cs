using Posts.Challenge.Domain.Entities.Post;
using Posts.Challenge.Domain.Requests.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Challenge.Domain.Interfaces.Services.Post
{
    public interface IPostService : IBaseService<PostEntity>
    {
        Task Create(PostRequest request, string userEmail);

        bool UpdateByUser(UpdatePostRequest request, string userEmail);
        void DeleteByUser(long id, string userEmail);
    }
}
