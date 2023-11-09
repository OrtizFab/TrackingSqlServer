using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.SignalR;
using System.Reflection.PortableExecutable;
using TrackingChangesDB.Models;

namespace TrackingChangesDB.Services
{
 
    public class SqlDependencyService: BackgroundService
    {
       

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string connectionString = TrackingChangesDB.Properties.Resources.stringConnection;
            using (TableDependency.SqlClient.SqlTableDependency<PostingCreations> dep = new TableDependency.SqlClient.SqlTableDependency<PostingCreations>(connectionString))
            {
                dep.OnChanged += Dep_OnChanged;               

                dep.Start();
                 Console.WriteLine("Press any key to stop");
                
                Console.ReadKey();
                dep.Stop();

            }
        }

        private void Dep_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<PostingCreations> e)
        {
            switch (e.ChangeType)
            {
                case TableDependency.SqlClient.Base.Enums.ChangeType.Insert:
                    Console.WriteLine("Record  Inserted client batch Id: " + e.Entity.posting_instruction_batch_client_id + " Status :" + e.Entity.status);
                    break;
                case TableDependency.SqlClient.Base.Enums.ChangeType.Update:
                    Console.WriteLine("Record Edited client batch id: " + e.Entity.posting_instruction_batch_client_id + " Status: "+ e.Entity.status);
                    break;
                case TableDependency.SqlClient.Base.Enums.ChangeType.Delete:
                    Console.WriteLine("Record Deleted client batch id: " + e.Entity.posting_instruction_batch_client_id + " Status: " + e.Entity.status);
                    break;
            }
            
        }
    }
}
