using Application.Tests.FakeDatas.Common;
using Domain.Entities;

namespace Application.Tests.FakeDatas;

public class CompanyFakeData : BaseFakeData<Company>
{
    public override List<Company> FakeData()
    {
        List<Company> datas = new()
        {
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Fake 1",
                Description = "Fake 1",
                CreatedDate = DateTime.UtcNow,
                LastUpdatedDate = DateTime.UtcNow
            },
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Fake 2",
                Description = "Fake 2",
                CreatedDate = DateTime.UtcNow,
                LastUpdatedDate = DateTime.UtcNow
            }
        };
        return datas;
    }
}