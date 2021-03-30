﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data
{
    public class PlayGroundContext: DbContext
    {

        public PlayGroundContext(DbContextOptions<PlayGroundContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }

}
