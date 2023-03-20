namespace AircraftAPI.Exceptions
{
    public class AircraftNotFoundException : Exception
    {
        public AircraftNotFoundException() {}

        public AircraftNotFoundException(string message) : base(message) {}

        public AircraftNotFoundException(string message, Exception innerException) : base(message, innerException) {}
    }
}
