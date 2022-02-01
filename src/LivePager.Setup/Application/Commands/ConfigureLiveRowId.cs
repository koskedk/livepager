using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;

namespace LivePager.Setup.Application.Commands
{
    public class ConfigureLiveRowId:IRequest<Result>
    {
    }

    public class ConfigureLiveRowIdHandler : IRequestHandler<ConfigureLiveRowId, Result>
    {
        public Task<Result> Handle(ConfigureLiveRowId request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
