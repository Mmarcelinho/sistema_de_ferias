namespace Utilitario.Testes.Mapper;

    public class MapperBuilder
    {
        public static IMapper Instancia()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfiguracao());
            });
            
            return mockMapper.CreateMapper();
        }
    }
