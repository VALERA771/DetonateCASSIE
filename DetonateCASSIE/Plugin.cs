using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Warhead;
using MEC;

using Warhead = Exiled.Events.Handlers.Warhead;
using Server = Exiled.Events.Handlers.Server;

namespace DetonateCASSIE
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "Detonate CASSIE";
        public override string Prefix { get; } = "DetonateCASSIE";
        public override string Author { get; } = "VALERA771#1471";
        public override Version Version { get; } = new Version(1, 1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(6, 0, 0, 0);

        private static Plugin _singleton;
        public static Plugin Instance => _singleton;
        private static bool IsAuto = false;

        public override void OnEnabled()
        {
            Warhead.Starting += AlphaWarheadCountDownStart;
            Warhead.Stopping += InteractionPanel;
            Server.RoundStarted += RoundStart;

            Plugin._singleton = this;
            Log.Debug("Plugin \"DetonateCASSIE\" is enabled!");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Warhead.Starting -= AlphaWarheadCountDownStart;
            Warhead.Stopping -= InteractionPanel;
            Server.RoundStarted -= RoundStart;
            
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
                Log.Debug("Sending CASSIE message");
            }
            else
            {
                if (IsAuto)
                {
                    Cassie.Message(Instance.Config.CassieMessage, Instance.Config.IsSubtiteled);
                    Log.Debug("Sending CASSIE message");
                }
            }
        }

        void InteractionPanel(StoppingEventArgs ev)
        {
            if (IsAuto)
                if (!Instance.Config.IsCancelable)
                {
                    ev.IsAllowed = false;
                    Log.Debug($"[{ev.Player.Id}] {ev.Player.Nickname} tried to stop auto-nuke, but it was declined");
                }
        }

        void RoundStart()
        {
            if (Instance.Config.AutoNuke)
            {
                float delay = Instance.Config.ActivatingMinutes * 60f;
                float actiondelay = delay - 0.3f;
                Timing.CallDelayed(actiondelay, () =>
                {
                    IsAuto = true;
                    Timing.CallDelayed(0.3f, () =>
                    {
                        Exiled.API.Features.Warhead.Status = WarheadStatus.InProgress;
                        Log.Debug("Auto-nuke has been started!");
                    });
                });
            }
        }
    }
}