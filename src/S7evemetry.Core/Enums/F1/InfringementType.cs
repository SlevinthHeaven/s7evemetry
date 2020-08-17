using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.Core.Enums.F1
{
    public enum InfringementType
    {

        BlockingBySlowDriving = 0,
        BlockingByWrongWayDriving = 1,
        ReversingOffTheStartLine = 2,
        BigCollision = 3,
        SmallCollision = 4,
        CollisionFailedToHandBackPositionSingle = 5,
        CollisionFailedToHandBackPositionMultiple = 6,
        CornerCuttingGainedTime = 7,
        CornerCuttingOvertakeSingle = 8,
        CornerCuttingOvertakeMultiple = 9,
        CrossedPitExitLane = 10,
        IgnoringBlueFlags = 11,
        IgnoringYellowFlags = 12,
        IgnoringDriveThrough = 13,
        TooManyDriveThroughs = 14,
        DriveThroughReminderServeWithinNLaps = 15,
        DriveThroughReminderServeThisLap = 16,
        PitLaneSpeeding = 17,
        ParkedForTooLong = 18,
        IgnoringTyreRegulations = 19,
        TooManyPenalties = 20,
        MultipleWarnings = 21,
        ApproachingDisqualification = 22,
        TyreRegulationsSelectSingle = 23,
        TyreRegulationsSelectMultiple = 24,
        LapInvalidatedCornerCutting = 25,
        LapInvalidatedRunningWide = 26,
        CornerCuttingRanWideGainedTimeMinor = 27,
        CornerCuttingRanWideGainedTimeSignificant = 28,
        CornerCuttingRanWideGainedTimeExtreme = 29,
        LapInvalidatedWallRiding = 30,
        LapInvalidatedFlashbackUsed = 31,
        LapInvalidatedResetToTrack = 32,
        BlockingThePitlane = 33,
        JumpStart = 34,
        SafetyCarToCarCollision = 35,
        SafetyCarIllegalOvertake = 36,
        SafetyCarExceedingAllowedPace = 37,
        VirtualSafetyCarExceedingAllowedPace = 38,
        FormationLapBelowAllowedSpeed = 39,
        RetiredMechanicalFailure = 40,
        RetiredTerminallyDamaged = 41,
        SafetyCarFallingTooFarBack = 42,
        BlackFlagTimer = 43,
        UnservedStopGoPenalty = 44,
        UnservedDriveThroughPenalty = 45,
        EngineComponentChange = 46,
        GearboxChange = 47,
        LeagueGridPenalty = 48,
        RetryPenalty = 49,
        IllegalTimeGain = 50,
        MandatoryPitstop = 51,

    }
}
