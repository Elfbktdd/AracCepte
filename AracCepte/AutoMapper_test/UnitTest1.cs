using AracCepte.API;
using AutoMapper.Configuration;
using AutoMapper;
using AracCepte.API.Mapping;
namespace AutoMapper_test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<VehicleMapping>();
            });

            // Konfig�rasyonu do�rula
            configuration.AssertConfigurationIsValid();
            Console.WriteLine("Mapper Configuration is valid!");

        }
    }
}