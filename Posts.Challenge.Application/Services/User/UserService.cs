using Posts.Challenge.Domain.Entities.User;
using Posts.Challenge.Domain.Exceptions;
using Posts.Challenge.Domain.Interfaces.Repositories.User;
using Posts.Challenge.Domain.Interfaces.Services.User;
using Posts.Challenge.Domain.Requests;
using AutoMapper;
using FluentValidation;

namespace Posts.Challenge.Application.Services.User
{
    public class UserService : BaseService<UserEntity>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UserRegisterRequest> _validator;

        public UserService(
            IUserRepository repository,
            IMapper mapper,
            IValidator<UserRegisterRequest> validator) : base(repository)
        {
            _userRepository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public UserEntity FindUserByEmail(string email)
        {
            var user = _userRepository.Select()
                .Where(p => p.Email == email && p.Active)
                .FirstOrDefault();

            return user;
        }

        public TOut GetById<TOut>(long id)
        {
            var user = _userRepository.GetById(id);

            var output = _mapper.Map<TOut>(user);

            return output;
        }

        public UserEntity GetUserByEmailAndPassword(string email, string password)
        {
            return _userRepository.GetUserByEmailAndPassword(email, password);
        }

        public async Task Register(UserRegisterRequest request)
        {
            try
            {
                var validate = await _validator.ValidateAsync(request);

                if (validate.Errors.Any())
                    throw new UserRegisterValidationException(string.Join("\n", validate.Errors));

                var entity = _mapper.Map<UserEntity>(request);

                _userRepository.Insert(entity);
            }
            catch
            {
                // TODO: incluir logs
                throw;
            }
            
        }

    }
}
