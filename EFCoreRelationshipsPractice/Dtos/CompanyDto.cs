﻿using EFCoreRelationshipsPractice.models;
using System.Collections.Generic;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyDto
    {
        public CompanyDto()
        {
        }
        public CompanyDto(CompanyEntity companyEntity)
        {
            Name = companyEntity.Name;
            //ProfileDto != null ? new ProfileDto(CompanyEntity.Profile) : null;
        }


        public string Name { get; set; }

        public ProfileDto? ProfileDto { get; set; }

        public List<EmployeeDto>? Employees { get; set; }
        public CompanyEntity ToEntity()
        {
            return new CompanyEntity()
            {
                Name = this.Name,
                Profile = this.ProfileDto?.ToEntity(),
                Employees = this.Employees?.Select(employeeDto => employeeDto.ToEntity()).ToList()
            };
        }

    }
}