using DbPoc.Common;
using System;

namespace DbPoc.Infrastructure
{
    public class SystemTime : ISystemTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
