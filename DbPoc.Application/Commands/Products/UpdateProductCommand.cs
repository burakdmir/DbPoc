﻿using DbPoc.Application.Infrastructure;
using DbPoc.Domain.Entities;
using DbPoc.Domain.Enums;
using MediatR;
using System;

namespace DbPoc.Application.Commands.Products
{
    public class UpdateProductCommand: IRequest<Unit>, IMyCacheWriter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal NetPrice { get; set; }
        public decimal Vat { get; set; }
        public UnitEnum Unit { get; set; }
        public Type CacheType => typeof(Product);

    }
}
