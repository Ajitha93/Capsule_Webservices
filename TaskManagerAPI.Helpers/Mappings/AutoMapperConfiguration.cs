using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using TaskManagerApi.Models.Models;
using TaskManagerAPI.DataAccess.Entity;

namespace TaskManagerAPI.Helpers.Mappings
{
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Mapper initialization
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap < TaskModel, Task>()
                .ForMember(dest => dest.Task_Id, opt => opt.MapFrom(src => src.TaskId))
                .ForMember(dest => dest.Task1, opt => opt.MapFrom(src => src.Task))
                .ForMember(dest => dest.Parent_Task_Id, opt => opt.MapFrom(src => src.ParentTaskId))
                .ForMember(dest => dest.Start_Date, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.End_Date, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
                .ForMember(dest => dest.Project_Id, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                ;
                x.CreateMap<UserModel, User>();
                x.CreateMap<ProjectModel, Project>();
                x.CreateMap<TaskModel, Parent_Task>()
                .ForMember(dest => dest.Parent_Task_Id, opt => opt.MapFrom(src => src.TaskId))
                .ForMember(dest => dest.Parent_Task1, opt => opt.MapFrom(src => src.Task));
            });
            }
    }
}
