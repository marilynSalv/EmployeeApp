﻿using EmployeeApp.Dal.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Repositories;

public interface ICompanyRepository
{
    Task<List<CompanySearchDto>> Search(string searchValue);
}