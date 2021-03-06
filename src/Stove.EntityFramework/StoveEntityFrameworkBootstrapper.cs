﻿using System;
using System.Linq;

using Stove.Bootstrapping;
using Stove.EntityFramework;
using Stove.Reflection.Extensions;

namespace Stove
{
    [DependsOn(
        typeof(StoveKernelBootstrapper)
    )]
    public class StoveEntityFrameworkBootstrapper : StoveBootstrapper
    {
        private readonly IDbContextTypeMatcher _dbContextTypeMatcher;

        public StoveEntityFrameworkBootstrapper(IDbContextTypeMatcher dbContextTypeMatcher)
        {
            _dbContextTypeMatcher = dbContextTypeMatcher;
        }

        public override void Start()
        {
            Type[] dbContextTypes = typeof(StoveDbContext).AssignedTypes().ToArray();
            _dbContextTypeMatcher.Populate(dbContextTypes);
        }
    }
}
