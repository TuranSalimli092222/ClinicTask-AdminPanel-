﻿namespace ClinicTask.Models
{
    public class Doctor:BaseModel
    {
        public string ImgUrl { get; set; }  
        public string FullName {  get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
  
    
	}
}
