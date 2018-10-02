namespace SampleServer.Domain.ApplicationConfiguration
{
    public sealed class ApplicationController : ApplicationEntity
    {
        public string AreaMode { get; set; } 
        public string TimeZone { get; set; } 
        public ApplicationBlade[] Blades { get; set; }
        public IApplicationReader[] Readers { get; set; }
        public IApplicationPortal[] Portals { get; set; }
        public ApplicationArea[] Areas { get; set; }
        public ApplicationInput[] Inputs { get; set; }
        public ApplicationOutput[] Outputs { get; set; }
        public ApplicationTokenFormat[] TokenFormats { get; set; }
        public ApplicationTimeTable[] TimeTables { get; set; }
        public ApplicationAction[] Actions { get; set; }
        public ApplicationSiSystem SmartIntego { get; set; }

        public ApplicationController()
        {
            Type = "Hardware.Controller";
        }

        public override void SetDefaults()
        {
            AreaMode = AreaMode ?? "local";
            TimeZone = TimeZone ?? "Etc/UTC";
        }

        public override void ClearDefaults()
        {
            Type = Type == "Hardware.Controller" ? null : Type;
            AreaMode = AreaMode == "local" ? null : AreaMode;
            TimeZone = TimeZone == "Etc/UTC" ? null : TimeZone;
        }
    }
}