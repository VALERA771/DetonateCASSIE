using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Warhead;

using Warhead = Exiled.Events.Handlers.Warhead;

namespace DetonateCASSIE
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "Detonate CASSIE";
        public override string Prefix { get; } = "DetonateCASSIE";
        public override string Author { get; } = "VALERA771#1471";
        public override Version Version { get; } = new Version("1.0.0.0");
        public override Version RequiredExiledVersion { get; } = new Version("6.0.0.0");

        private static Plugin _singleton;
        public static Plugin Instance => _singleton;

        public override void OnEnabled()
        {
            Warhead.Starting += AlphaWarheadCountDownStart;

            Plugin._singleton = this;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Warhead.Starting -= AlphaWarheadCountDownStart;
            Plugin._singleton = null;
            base.OnDisabled();
        }

        public override void OnReloaded()
        {
            base.OnReloaded();
        }

        void AlphaWarheadCountDownStart(StartingEventArgs ev)
        {
            if (Instance.Config.EveryStart)
            {
                Cassie.Message(Instance.Config.CassieMessage, Instance.Config.IsSubtiteled);
            }
            else
            {
                if (ev.IsAuto)
                {
                    Cassie.Message(Instance.Config.CassieMessage, Instance.Config.IsSubtiteled);
                }
            }
        }
    }
}