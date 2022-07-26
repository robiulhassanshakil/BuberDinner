using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //1.Validate user doesn't exists
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with the given email already exsist.");
        }

        //2.Create user (generate unique ID) & persist DB
        var user = new User 
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        //3.Create JWT token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
    public AuthenticationResult Login(string email, string password)
    {
        //1.Validate the user exists
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("Invalid user and password.");
        }

        //2. Validate the password i correct
        if(user.Password != password)
        {
            throw new Exception("Invalid user and password.");
        }

        //3.Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
