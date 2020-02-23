﻿using System.Threading.Tasks;
using FileMaker.Commands.Modules.Employees;
using FileMaker.Infrastructure;

namespace FileMaker.Service.Interfaces.Modules.Employees
{
    public interface IEmployeeService
    {
        Task<Result> CreateEmployeePersonalInfoAsyn(CreateEmployeePersonalInfoCommand command);

        Task<Result> GetEmployeePersonalInfoByEmployeeNumber(int id);

        Task<Result> UpdateEmployeePersonalInfoAsyn(UpdateEmployeePersonalInfoCommand command);

        Task<Result> GetEmployeeInfoByEmployeeNumber(int id);
    }
}