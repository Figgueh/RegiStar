using AutoMapper;
using RegiStar.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.Maps
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<SelectorViewModel, CourseViewModel>();

            //SelectorViewModel selector = Mapper.Map<SelectorViewModel>(((SelectorViewModel)DataContext).)
        }
    }
}
