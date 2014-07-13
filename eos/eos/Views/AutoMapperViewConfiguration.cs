using AutoMapper;
using eos.Models.Subjects;
using eos.Models.Tasks;
using eos.Views.Subjects.ViewModels;
using eos.Views.Tasks.ViewModels;

namespace eos.Views
{
    public class AutoMapperViewConfiguration
    {
        public static void Configure()
        {
            ConfigureTaskMapping();
            ConfigureSubjectMapping();
        }

        private static void ConfigureTaskMapping()
        {
            Mapper.CreateMap<Task, TaskViewModel>();
        }

        private static void ConfigureSubjectMapping()
        {
            Mapper.CreateMap<Subject, SubjectViewModel>();
            Mapper.CreateMap<Subject, SubjectListBoxViewModel>();
        }

    }
}