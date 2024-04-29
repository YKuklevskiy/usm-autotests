using System;
using System.Collections.Generic;

namespace ATframework3demo.TestEntities
{
    public class Bitrix24ScrumTeamDetail
    {
        public Bitrix24ScrumTeamDetail(string scrumTeamName, Bitrix24User scrumMaster)
        {
            ScrumTeamName = scrumTeamName ?? throw new ArgumentNullException(nameof(scrumTeamName));
            ScrumMaster = scrumMaster ?? throw new ArgumentNullException(nameof(scrumMaster));
        }
        public string ScrumTeamName { get; private set; }
        public Bitrix24User ScrumMaster { get; private set; }
    }
}