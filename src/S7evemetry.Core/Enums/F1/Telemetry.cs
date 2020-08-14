namespace S7evemetry.Core.Enums.F1
{
    /// <summary>
    /// The player's UDP setting
    /// There is some data in the UDP that you may not want other 
    /// players seeing if you are in a multiplayer game. This is 
    /// controlled by the “Your Telemetry” setting in the Telemetry options. 
    /// The options are:
    /// 
    /// Restricted (Default) – other players viewing the UDP data will not see values for your car
    /// Public – all other players can see all the data for your car
    /// 
    /// Note: You can always see the data for the car you are driving regardless of the setting.
    /// 
    /// The following data items are set to zero if the player driving 
    /// the car in question has their “Your Telemetry” set to “Restricted”:
    /// 
    /// Car status packet
    /// m_fuelInTank
    /// m_fuelCapacity
    /// m_fuelMix
    /// m_fuelRemainingLaps
    /// m_frontBrakeBias
    /// m_frontLeftWingDamage
    /// m_frontRightWingDamage
    /// m_rearWingDamage
    /// m_engineDamage
    /// m_gearBoxDamage
    /// m_tyresWear(All four wheels)
    /// m_tyresDamage(All four wheels)
    /// m_ersDeployMode
    /// m_ersStoreEnergy
    /// m_ersDeployedThisLap
    /// m_ersHarvestedThisLapMGUK
    /// m_ersHarvestedThisLapMGUH
    /// m_tyresAgeLaps
    /// </summary>
    public enum Telemetry
    {
        /// <summary>
        /// Restricted (Default) – other players viewing the UDP data will not see values for your car
        /// </summary>
        Restricted = 0,

        /// <summary>
        /// Public – all other players can see all the data for your car
        /// </summary>
        Public = 1,
    }
}
