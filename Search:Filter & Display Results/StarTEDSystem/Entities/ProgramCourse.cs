﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace StarTEDSystem.Entities
{
    public partial class ProgramCourse
    {
        public int ProgramCourseID { get; set; }
        public int ProgramID { get; set; }
        public string CourseID { get; set; }
        public bool Required { get; set; }
        public string Comments { get; set; }
        public int SectionLimit { get; set; }
        public bool Active { get; set; }

        public virtual Program Program { get; set; }
    }
}