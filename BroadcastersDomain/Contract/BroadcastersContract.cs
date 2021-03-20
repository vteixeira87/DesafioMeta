using BroadcastersDomain.Queries.Request;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersDomain.Contract
{
    public class BroadcastersContract : Contract<CreateBroadcastersCommand>
    {
        public BroadcastersContract(string id, string brodcastersName)
        { 
            if (string.IsNullOrWhiteSpace(id))
                AddNotification(id, "Id Invalid");

            Requires().Matches(brodcastersName, "^[a-zA-Z0-9 ]*$", brodcastersName);
            
            if (string.IsNullOrWhiteSpace(brodcastersName))
                AddNotification(brodcastersName, "BrodcastersName Invalid");
        }

        public BroadcastersContract(string brodcastersName)
        { 
            Requires().Matches(brodcastersName, "^[a-zA-Z0-9 ]*$", brodcastersName);

            if (string.IsNullOrWhiteSpace(brodcastersName))
                AddNotification(brodcastersName, "BrodcastersName Invalid");
        }
    }
}
