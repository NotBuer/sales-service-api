using SalesService.Application.Mapping;

namespace SalesService.UnitTest.AutoMapper;

public class CustomerMappingProfileTests
{
    [Fact]
    public void ProfileConfiguration_IsValid()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<CustomerProfile>());
        var action = () => config.AssertConfigurationIsValid();
        action.Should().NotThrow();
    }
}