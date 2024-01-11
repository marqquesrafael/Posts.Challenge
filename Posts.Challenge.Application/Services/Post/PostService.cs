using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Posts.Challenge.Application.Services.User;
using Posts.Challenge.Domain.Entities.Post;
using Posts.Challenge.Domain.Entities.User;
using Posts.Challenge.Domain.Exceptions;
using Posts.Challenge.Domain.Interfaces.Repositories;
using Posts.Challenge.Domain.Interfaces.Repositories.Post;
using Posts.Challenge.Domain.Interfaces.Services.Post;
using Posts.Challenge.Domain.Interfaces.Services.User;
using Posts.Challenge.Domain.Requests.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Challenge.Application.Services.Post
{
    public class PostService : BaseService<PostEntity>, IPostService
    {
        private readonly IUserService _userService;
        private readonly IPostRepository _repository;
        private readonly IValidator<PostRequest> _validator;
        private readonly IMapper _mapper;

        public PostService(
            IUserService userService,
            IPostRepository repository,
            IValidator<PostRequest> validator,
            IMapper mapper) : base(repository)
        {
            _userService = userService;
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task Create(PostRequest request, string userEmail)
        {
            var validate = await _validator.ValidateAsync(request);

            if (validate.Errors.Any())
                throw new NewPostValidatationException(string.Join("\n", validate.Errors));

            var user = _userService.FindUserByEmail(userEmail);

            var entity = _mapper.Map<PostEntity>(request);
            entity.User = user;

            _repository.Insert(entity);
        }

        public void DeleteByUser(long id, string userEmail)
        {
            var user = _userService.FindUserByEmail(userEmail);
            var entity = _repository.GetById(id);

            if (entity is null)
                throw new EntityNotFoundException();

            if (entity.UserId != user.Id)
                throw new UserNotAllowedException();

            Delete(id);
        }

        public bool UpdateByUser(UpdatePostRequest request, string userEmail)
        {
            var user = _userService.FindUserByEmail(userEmail);
            var entity = _repository.GetById(request.Id);

            if(entity is null)
                throw new EntityNotFoundException();

            if (entity.UserId != user.Id)
                throw new UserNotAllowedException();

            entity.Content = request.Content;
            entity.Title = request.Title;

            _repository.Update(entity);

            return true;
        }

    }
}
