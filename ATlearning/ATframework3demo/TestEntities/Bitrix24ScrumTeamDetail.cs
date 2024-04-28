using System;
using System.Collections.Generic;

namespace ATframework3demo.TestEntities
{
    public class Bitrix24ScrumTeamDetail
    {
        public Bitrix24ScrumTeamDetail(string teamName, string scrumMasterName)
        {
            TeamName = teamName ?? throw new ArgumentNullException(nameof(teamName));
            ScrumMasterName = scrumMasterName ?? throw new ArgumentNullException(nameof(scrumMasterName));
        }
        public string TeamName { get; set; }
        public string ScrumMasterName { get; set; }
    }
}