using System.ComponentModel;
using Exiled.API.Interfaces;

namespace DetonateCASSIE
{
    public class Config : IConfig
    {
        [Description("Is plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        
        [Description("Is debug mode enabled?")]
        public bool Debug { get; set; } = false;

        [Description("Should auto-nuke be enabled?")]
        public bool AutoNuke { get; set; } = false;

        [Description("Time (in minutes) when auto-nuke should start")]
        public int ActivatingMinutes { get; set; } = 20;

        [Description("Can auto-nuke be cancelled?")]
        public bool IsCancelable { get; set; } = false;

        [Description("Should CASSIE be send on every warhead start (true) or only on auto-nuke (false)")]
        public bool EveryStart { get; set; } = false;

        [Description("Text for CASSIE")]
        public string CassieMessage { get; set; } = "Alpha warhead has been Detonated";

        [Description("Should CASSIE be subtiteled?")]
        public bool IsSubtiteled { get; set; } = false;
    }
}