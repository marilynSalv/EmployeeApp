using EmployeeApp.Infrastructure.Contexts;
using EmployeeApp.Domain.DomainEntities;
using EmployeeApp.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Infrastructure.Repositories;

public class EmployeeManagementRepository : IEmployeeManagementRepository
{
    private readonly PlayGroundContext _context;
    public EmployeeManagementRepository(PlayGroundContext context)
    {
        _context = context;
    }
    public async Task<List<Employee>> Get()
    {
        var result = await _context.ApplicationUsers
            .Select(x => new Employee
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                CompanyId = x.CompanyId,
                ManagerId = x.ManagerId,
                IsManager = x.IsManager,
                ZipCode = x.ZipCode,
                CompanyName = x.Company.Name,
                ManagerFirstName = x.Manager.FirstName,
                ManagerLastName = x.Manager.LastName,
            })
            .Take(10)
            .ToListAsync();

        return result;
    }

    public async Task<Guid> Update(Employee employeeDto)
    {
        var entity = await _context.ApplicationUsers
            .Where(x => x.Id == employeeDto.Id)
            .SingleAsync();

        entity.FirstName = employeeDto.FirstName;
        entity.LastName= employeeDto.LastName;
        entity.Email = employeeDto.Email;
        entity.ZipCode = employeeDto.ZipCode;
        entity.CompanyId = employeeDto.CompanyId;
        entity.ManagerId= employeeDto.ManagerId;
        entity.IsManager = employeeDto.IsManager;

        await _context.SaveChangesAsync();

        return entity.Id;
    }
}
