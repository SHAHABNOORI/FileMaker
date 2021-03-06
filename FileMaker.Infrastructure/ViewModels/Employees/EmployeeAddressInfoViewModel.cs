﻿using FileMaker.Infrastructure.Enums;

namespace FileMaker.Infrastructure.ViewModels.Employees
{
    public class EmployeeAddressInfoViewModel
    {
        public string AddressOne { get; set; }

        public string AddressTwo { get; set; }

        public Town Town { get; set; }

        public City City { get; set; }

        public string Email { get; set; }

        public string PostalCode { get; set; }
    }
}