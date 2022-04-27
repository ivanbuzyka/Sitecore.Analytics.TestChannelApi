using Sitecore.Analytics.Model;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Collection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestChannelApi
{
  public partial class setfacets : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SetFacets_Click(object sender, EventArgs e)
    {
      if (Sitecore.Analytics.Tracker.Current.Contact.IsNew)
      {
        var manager = Sitecore.Configuration.Factory.CreateObject("tracking/contactManager", true) as Sitecore.Analytics.Tracking.ContactManager;

        if(manager != null)
        {
          // Save contact to xConnect; at this point, a contact has an anonymous
          // TRACKER IDENTIFIER, which follows a specific format. Do not use the contactId overload
          // and make sure you set the ContactSaveMode as demonstrated

          Sitecore.Analytics.Tracker.Current.Contact.ContactSaveMode = ContactSaveMode.AlwaysSave;
          manager.SaveContactToCollectionDb(Sitecore.Analytics.Tracker.Current.Contact);

          // Now that the contact is saved, you can retrieve it using the tracker identifier
          // NOTE: Sitecore.Analytics.XConnect.DataAccess.Constants.IdentifierSource is marked internal in 9.0 Initial and cannot be used. If you are using 9.0 Initial, pass "xDB.Tracker" in as a string.

          var trackerIdentifier = new IdentifiedContactReference(Sitecore.Analytics.XConnect.DataAccess.Constants.IdentifierSource, Sitecore.Analytics.Tracker.Current.Contact.ContactId.ToString("N"));
          
          //Change the Channel in session
          if(!string.IsNullOrEmpty(ChannelIdTextBox.Text))
          {
            Sitecore.Analytics.Tracker.Current.Interaction.ChannelId = Guid.Parse(ChannelIdTextBox.Text); //Webinar Live channel
          }

          // Get contact from xConnect, update and save the facet
          using (XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
          {
            try
            {
              var contact = client.Get<Contact>(trackerIdentifier, new Sitecore.XConnect.ContactExpandOptions());

              if (contact != null)
              {
                //client.SetFacet<PersonalInformation>(contact, PersonalInformation.DefaultFacetKey, new PersonalInformation()
                client.SetFacet<PersonalInformation>(contact, new PersonalInformation()
                {
                  FirstName = FirstNameTextBox.Text,
                  LastName = LastNameTextBox.Text
                });

                EmailAddressList emails = new EmailAddressList(new EmailAddress(EmailTextBox.Text, true), "Preferred");
                emails.PreferredEmail = new EmailAddress(EmailTextBox.Text, true);
                //client.SetFacet(contact, EmailAddressList.DefaultFacetKey, emails);
                
                //try different methods to store it without DefaultFacetKey
                client.SetFacet(contact, emails);

                client.Submit();

                // Remove contact data from shared session state - contact will be re-loaded
                // during subsequent request with updated facets
                manager.RemoveFromSession(Sitecore.Analytics.Tracker.Current.Contact.ContactId);
                Sitecore.Analytics.Tracker.Current.Session.Contact = manager.LoadContact(Sitecore.Analytics.Tracker.Current.Contact.ContactId);
              }
            }
            catch (XdbExecutionException ex)
            {
              // Manage conflicts / exceptions
            }
          }

        }
      }       

    }
  }
}