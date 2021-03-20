using BroadcastersDomain.Queries.Request;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersDomain.Contract
{
    public class AudienceContract : Contract<CreateAudienceCommand>
    { 
        public AudienceContract(string audiencebrodcastersName, DateTime audienceDateTime, decimal audiencePoints)
        {
            Requires().Matches(audiencebrodcastersName, "^[a-zA-Z0-9 ]*$", audiencebrodcastersName);

            if (string.IsNullOrWhiteSpace(audiencebrodcastersName))
                AddNotification(audiencebrodcastersName, "BrodcastersName Invalid");

            Requires()
               .IsGreaterThan(audiencePoints, 0, "Audience Points", "Audience Points Invalid");

            Requires()
                .AreNotEquals(audienceDateTime, default, "Audience date time invalid")
                .IsGreaterThan(audienceDateTime, DateTime.Now.Date, "Audience date time invalid");

        }

        public AudienceContract(string id, string audiencebrodcastersName, DateTime audienceDateTime, decimal audiencePoints)
        {
            if (string.IsNullOrWhiteSpace(id))
                AddNotification(id, "Id Invalid");

            Requires().Matches(audiencebrodcastersName, "^[a-zA-Z0-9 ]*$", audiencebrodcastersName);

            if (string.IsNullOrWhiteSpace(audiencebrodcastersName))
                AddNotification(audiencebrodcastersName, "BrodcastersName Invalid");

            Requires()
               .IsGreaterThan(audiencePoints, 0, "Audience Points", "Audience Points Invalid");

            Requires()
                .AreNotEquals(audienceDateTime, default, "Audience date time invalid")
                .IsGreaterThan(audienceDateTime, DateTime.Now.Date, "Audience date time invalid");

        }
    }
}
