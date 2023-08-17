namespace E470CodeChallenge.Events.Vehicular
{
    /// <summary>
    /// Delegate for defining event and attaching vehicle events handlers. 
    /// </summary>
    /// <param name="vehicleEventArgs">A VehicleEventArgs object to pass arguments for the event handler.</param>
    /// 
    public delegate Task VehicleEvent(VehicleEventArgs vehicleEventArgs);
}