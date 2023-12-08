using System;
using AutoMapper;
using AutoMapper.Internal;

namespace OnionArc.Mapper
{
    public class Mapper : Application.Interfaces.Automapper.IMapper
    { 
        //automapper içerisinde de IMapper var, buyüzden yolunu belirttik

        public static List<TypePair> typePairs = new();
        private IMapper MapperContainer; 

        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);

            return MapperContainer.Map<TSource, TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> sources, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);

            return MapperContainer.Map<IList<TSource>, IList<TDestination>>(sources);
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {
            Config<TDestination, object>(5, ignore); 

            return MapperContainer.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TDestination>(IList<object> sources, string? ignore = null)
        {
            Config<TDestination,IList<object>>(5, ignore);

            return MapperContainer.Map<IList<TDestination>>(sources);
        }


        //int depth = 5 satırı için 5 default değer. 5 dto'ya kadar mapleme yapacağını ifade ediyor
        protected void Config<TDestination, TSource>(int depth = 5, string? ignore = null)
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestination));

            if (typePairs.Any(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType && ignore is null))
                return;

            typePairs.Add(typePair);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var item in typePairs)
                {
                    if (ignore is not null)
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(5).ForMember(ignore, x => x.Ignore()).ReverseMap();
                    else
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(5).ReverseMap();
                }
            });

            MapperContainer = config.CreateMapper(); 
        }

    }
}

