﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TaxCalculationsAPI.Models;

public partial class TaxCalculatorResult
{
    public int Id { get; set; }

    public string PostalCode { get; set; }

    public double? EnteredAmount { get; set; }

    public double? CalculatedAmount { get; set; }

    public DateTime? Date { get; set; }
}