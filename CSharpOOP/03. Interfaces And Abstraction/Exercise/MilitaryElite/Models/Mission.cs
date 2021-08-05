using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using System;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateEnum missionStateEnum)
        {
            this.CodeName = codeName;
            this.MissionStateEnum = missionStateEnum;
        }

        public string CodeName { get; }

        public MissionStateEnum MissionStateEnum { get; }

        public void CompleteMission(string missionName)
        {
            throw new NotImplementedException();
        }
    }
}
