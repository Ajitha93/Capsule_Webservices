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
                .ForMember(dest => dest.Created_By, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.Created_Date, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.Modified_By, opt => opt.MapFrom(src => src.ModifiedBy))
                .ForMember(dest => dest.Modified_Date, opt => opt.MapFrom(src => src.ModifiedDate));
            });
            }
    }
}
