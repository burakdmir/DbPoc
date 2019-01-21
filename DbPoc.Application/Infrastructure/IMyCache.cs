using DbPoc.Domain.Entities;
using System;

namespace DbPoc.Application.Infrastructure
{
    public interface IMyCache
    {
         Type CacheType { get; }
    }
}
    