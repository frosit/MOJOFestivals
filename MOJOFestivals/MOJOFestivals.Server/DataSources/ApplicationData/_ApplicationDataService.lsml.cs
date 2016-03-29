using Microsoft.LightSwitch.Security.Server;
using Microsoft.LightSwitch;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Mail;

namespace LightSwitchApplication
{
    public partial class ApplicationDataService
    {

        // validatie voor aanmaken activiteit tot podium, momenteel controleert hij podium + datumtijd vanaf
        partial void ActiviteitOpPodias_Validate(ActiviteitOpPodia entity, EntitySetValidationResultsBuilder results)
        {
            int currentPodiumId = entity.Podium.Id;
            DateTime currentVan = entity.Van;

            int queryResult = this.getPodiaByVan(currentPodiumId, currentVan).Count();

            if (queryResult > 0)
            {
                results.AddEntityError("De begin datum / tijd voor dit podium is al in gebruik. Kies een ander podium of tijd.");
            }
        }


        // stuur mail na aanschaf ticket indien mail aan staat
        partial void Tickets_Inserted(Ticket entity)
        {

            if (Properties.Settings.Default.UseMail)
            {

           Bezoeker bezoeker = this.BezoekerBijPersoonId().FirstOrDefault();

            MailAddress from = new MailAddress(Properties.Settings.Default.DefaultSendMail);
            MailAddress to = new MailAddress(bezoeker.Email);
            MailMessage message = new MailMessage(from, to);
            // message.Subject = "Using the SmtpClient class.";
            message.Subject = "Bedankt voor uw bestelling.";
            message.Body = @"Uw bestelling van "+ entity.Aantal + " ticket(s) voor" + entity.Festival.Naam + " is zojuist verwerkt." ;
            // Add a carbon copy recipient.

            SmtpClient client = new SmtpClient(Properties.Settings.Default.SMTPServer,Properties.Settings.Default.SMTPPort);
            // Include credentials if the server requires them.
            client.Credentials = (ICredentialsByHost)CredentialCache.DefaultNetworkCredentials;
            Console.WriteLine("Sending an e-mail message to {0} using the SMTP host {1}.",
                 to.Address, client.Host);
            try
            {
                client.Send(message);
            }
            catch (SmtpFailedRecipientsException ex)
            {
                for (int i = 0; i < ex.InnerExceptions.Length; i++)
                {
                    SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        Console.WriteLine("Delivery failed - retrying in 5 seconds.");
                        System.Threading.Thread.Sleep(5000);
                        client.Send(message);
                    }
                    else
                    {
                        Console.WriteLine("Failed to deliver message to {0}",
                            ex.InnerExceptions[i].FailedRecipient);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in RetryIfBusy(): {0}",
                        ex.ToString());
            }

            }
        }


        // automatisch koppelen aan gebruiker
        partial void Beoordelingen_Inserting(Beoordeling entity)
        {
            Bezoeker bezoeker = this.BezoekerBijPersoonId().FirstOrDefault();

            entity.Bezoeker = bezoeker;
            entity.Gebruiker = Application.Current.User.PersonId;
        }

        partial void Tickets_Inserting(Ticket entity)
        {
            Bezoeker bezoeker = this.BezoekerBijPersoonId().FirstOrDefault();

            entity.Bezoeker = bezoeker;
            entity.Gebruiker = Application.Current.User.PersonId;
        }

        partial void Tickets_Validate(Ticket entity, EntitySetValidationResultsBuilder results)
        {
            int totaal = this.Tickets.Sum(h => h.Aantal);
            int resterend = entity.Festival.TicketsTotaal - totaal;

            if (resterend < entity.Aantal)
            {
                results.AddEntityError("Sorry, Zoveel tickets zijn er niet meer beschikbaar, we hebben er nog maar " + Convert.ToString(resterend) + " over.");
            }
        }
    }
}