using E_Ticket_API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Ticket_API.Contexts
{
    public class TrainsContext : DbContext
    {
        public TrainsContext() : base("TrainsContext")
        {

        }

        public DbSet<Train> Trains { get; set; }
        public DbSet<Vagon> Vagons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vagon>()
                .HasRequired(vagon => vagon.Train) // required (HasRequired()): mutlaka olmalı, optional (HasOptional()): olmasa da olur
                .WithMany(train => train.Vagons)
                .HasForeignKey(vagon => vagon.TrainId)
                .WillCascadeOnDelete(false); // veritabanındaki Review ile Movie arasındaki ilişkide delete rule no action olur
        }
    }
}