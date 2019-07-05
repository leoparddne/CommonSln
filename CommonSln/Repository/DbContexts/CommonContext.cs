using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DbContexts
{
    public class CommonContext : DbContext
    {
        public CommonContext( DbContextOptions options) : base(options)
        {
        }
    }
}
