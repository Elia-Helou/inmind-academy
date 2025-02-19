using AutoMapper;
using Lab4_2.API.ViewModels;
using Lab4_2.Domain.Models;

namespace Lab4_2.Application.services
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            CreateMap<Teacher, TeacherViewModel>();
            CreateMap<Course, CourseViewModel>();
            CreateMap<Class, ClassViewModel>()
                .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teacher))
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course));
            CreateMap<Student, StudentViewModel>();
            CreateMap<ClassEnrollment, ClassEnrollmentViewModel>()
                .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class));
        }
    }
}
