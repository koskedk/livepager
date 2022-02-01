using CSharpFunctionalExtensions;
using LivePager.Setup.Domain;
using MediatR;

namespace LivePager.Setup.Application.Queries
{
    public class ReadDataSource : IRequest<Result<DataSource>>
    {
    }
}
