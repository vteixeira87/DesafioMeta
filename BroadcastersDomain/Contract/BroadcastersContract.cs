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
             Requires().                
                IsNotNullOrWhiteSpace(id, "Id Invalid");
                Matches(brodcastersName, "^[a-zA-Z0-9 ]*$", brodcastersName);
                IsNotNullOrWhiteSpace(brodcastersName, "BrodcastersName Invalid");           
        }

        public BroadcastersContract(string brodcastersName)
        {
            Requires().
                Matches(brodcastersName, "^[a-zA-Z0-9 ]*$", brodcastersName);
                IsNotNullOrWhiteSpace(brodcastersName, "BrodcastersName Invalid");
        }
    }
}
