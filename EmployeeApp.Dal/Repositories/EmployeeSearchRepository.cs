﻿using EmployeeApp.Dal.Contexts;
using EmployeeApp.Dal.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Repositories;

public class ManagerSearchRepository : IManagerSearchRepository
{
    private readonly PlayGroundContext _context;
    public ManagerSearchRepository(PlayGroundContext context)
    {
        _context = context;
    }

    public async Task<List<ManagerSearchDto>> ManagerSearch(string searchValue)
    {
        var results = await _context.Employees
            .Where(x => x.IsManager)
            .Where(x => x.FirstName.Contains(searchValue) || x.LastName.ToString() == searchValue)
            .Select(x => new ManagerSearchDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
            })
            .ToListAsync();

        return results;
    }
}
