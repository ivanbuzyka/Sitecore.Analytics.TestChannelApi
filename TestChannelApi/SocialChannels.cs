using Sitecore.Analytics.OmniChannel.Pipelines.DetermineInteractionChannel;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestChannelApi
{
  public class SocialChannels : DetermineChannelProcessorBase
  {
    public override void Process(DetermineChannelProcessorArgs args)
    {
      DoProcess(args);
    }

    protected void DoProcess(DetermineChannelProcessorArgs args)
    {
      try
      {
        if (args.Interaction != null && !string.IsNullOrEmpty(args.Interaction.Referrer))
        {


          Uri interactionUrlReferrer = new Uri(args.Interaction.Referrer);
          if (interactionUrlReferrer.Host == "www.google.com")
          {
            args.ChannelId = ID.Parse("{DC70F72E-0A36-404D-8B10-86FE765A3BCC}"); // Google Plus social community channel ID
            Sitecore.Diagnostics.Log.Info("SocialChannels: channel set to 'Google Plus social community'", this);
          }
        }
      }
      catch (Exception exception)
      {
        Sitecore.Diagnostics.Log.Error("Couldn't determine the social channels for the interaction.", exception, this);
      }
    }
  }
}