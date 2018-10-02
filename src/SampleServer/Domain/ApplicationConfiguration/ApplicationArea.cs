using SampleServer.Domain.ApplicationConfiguration.Enums;

namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationArea : ApplicationCommandModeEntity<AreaOperationalMode>
    {
        public string OfflineMode { get; set; } 
        public bool? EnforceOccupancyLimits { get; set; } 
        public int? MaximumOccupancy { get; set; }
        public int? MinimumOccupancy { get; set; } 

        public string[] ChangeModePermissions { get; set; }
        public string[] SetPersonStatePermissions {get;set;} 
        public string[] MakeAllUnknownPermissions {get;set;} 
        public string[] MakeAllOutPermissions {get;set;} 

        public ApplicationArea()
        {
            Type = "AccessControl.Area";
        }

        public override void SetDefaults()
        {
            OperationalMode = OperationalMode ?? AreaOperationalMode.Enforced;
            OfflineMode = OfflineMode ?? "unenforced";
            EnforceOccupancyLimits = EnforceOccupancyLimits ?? true;
            MaximumOccupancy = MaximumOccupancy ?? 1_000_000;
            MinimumOccupancy = MinimumOccupancy ?? 0;
        }
    }
}