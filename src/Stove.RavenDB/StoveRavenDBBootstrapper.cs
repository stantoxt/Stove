﻿using Raven.Client;

using Stove.Bootstrapping;
using Stove.RavenDB.Configuration;

namespace Stove
{
    [DependsOn(
        typeof(StoveKernelBootstrapper)
    )]
    public class StoveRavenDBBootstrapper : StoveBootstrapper
    {
        public override void PreStart()
        {
            Configuration.GetConfigurerIfExists<IStoveRavenDBConfiguration>()(Configuration.Modules.StoveRavenDB());
        }

        public override void Start()
        {
            Resolver.Resolve<IDocumentStore>().Initialize();
        }

        public override void Shutdown()
        {
            Resolver.Resolve<IDocumentStore>().Dispose();
        }
    }
}
