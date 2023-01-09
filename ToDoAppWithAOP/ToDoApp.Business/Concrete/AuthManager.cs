using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Aspects.Exception;
using TodoApp.Core.Aspects.Logging;
using TodoApp.Core.CrossCuttingConcerns.Logging.Log4Net;
using TodoApp.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using TodoApp.Core.Entities.Concrete;
using TodoApp.Core.Utilities.Results;
using TodoApp.Core.Utilities.Security;
using TodoApp.Core.Utilities.Security.Hashing;
using TodoApp.Core.Utilities.Security.JWT;
using TodoApp.Entities.Dtos;
using ToDoApp.Business.Abstract;
using ToDoApp.Business.Constants;

namespace ToDoApp.Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    [ExceptionLogAspect(typeof(FileLogger))]
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private LoggerServiceBase _logger;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _logger = (LoggerServiceBase)Activator.CreateInstance(typeof(FileLogger));
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            _logger.Debug("AuthManager-Login için mail kontrolü yapılacak.");
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            _logger.Info(userToCheck);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, "Giriş başarılı!");
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            _logger.Debug("Kullanıcı kaydı için passwordsalt ve passwordhash oluşturuluyor.");
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _logger.Debug("Kullanıcı sisteme kayıt ediliyor.");
            _userService.AddNewUser(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            _logger.Debug("Kullanıcı varlık kontrolü yapılıyor.");
            if (_userService.GetByMail(email)!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
