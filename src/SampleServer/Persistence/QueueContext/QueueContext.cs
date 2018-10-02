using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;

namespace SampleServer.Persistence.QueueContext
{
    public interface IQueueContext : IDisposable
    {
        IDbSet<QueueEntry> DeviceQueue { get; }
        int SaveChanges();
    }

    public class QueueContext : DbContext, IQueueContext
    {
        public IDbSet<QueueEntry> DeviceQueue { get; set; }

        public QueueContext() : base(ConnectionBuilder(), true)
        {
            Configuration.LazyLoadingEnabled = false;
        }
        
        private static DbConnection ConnectionBuilder()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("oem");
            base.OnModelCreating(modelBuilder);
        }
    }
}
