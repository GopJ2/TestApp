using System.Threading;
using System.Threading.Tasks;
using TestApp.Dto.Auth;

namespace TestApp.Services.Auth
{
    public interface IAuthService
    {
        public Task<TokenDto> LoginAsync(AuthDto userDto, CancellationToken cancellationToken);
    }
}
