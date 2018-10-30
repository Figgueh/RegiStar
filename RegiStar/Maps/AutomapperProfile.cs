using AutoMapper;
using RegiStar.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.Maps
{
    public static class MyMapper
    {
        private static bool _isInitialized;
        public static bool Initialize()
        {
            if (!_isInitialized)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<SelectorViewModel, CourseViewModel>()
                        .ForMember(destination => destination.Book, map => map.MapFrom(source => source.SelectedBook))
                        .ForMember(destination => destination.Teacher, map => map.MapFrom(source => source.SelectedTeacher));
                });
                _isInitialized = true;
            }
            return _isInitialized;
        }
    }
    
}
