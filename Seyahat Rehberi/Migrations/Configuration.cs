﻿namespace Seyahat_Rehberi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Seyahat_Rehberi.Models.Sınıflar.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Seyahat_Rehberi.Models.Sınıflar.Context context)
        {
  
        }
    }
}
