using SalesService.Application.Mapping;

namespace SalesService.UnitTest.AutoMapper;

public class MappingProfileTests
{
    
    private static void ProfileConfiguration_IsValid<TProfile>()
        where TProfile : Profile, new()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<TProfile>());
        var action = () => config.AssertConfigurationIsValid();
        action.Should().NotThrow();
    }

    [Fact]
    private void CustomerProfile_IsValid() => ProfileConfiguration_IsValid<CustomerProfile>();
    
    [Fact]
    private void ProductProfile_IsValid() => ProfileConfiguration_IsValid<ProductProfile>();
    
    [Fact]
    private void InventoryProfile_IsValid() => ProfileConfiguration_IsValid<InventoryProfile>();
    
    [Fact]
    private void SaleProfile_IsValid() => ProfileConfiguration_IsValid<SaleProfile>();
}