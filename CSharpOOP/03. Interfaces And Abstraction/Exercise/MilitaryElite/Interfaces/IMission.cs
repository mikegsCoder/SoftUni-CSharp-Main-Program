using MilitaryElite.Enumerations;

namespace MilitaryElite.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }

        MissionStateEnum MissionStateEnum { get; }

        void CompleteMission(string missionName);
    }
}