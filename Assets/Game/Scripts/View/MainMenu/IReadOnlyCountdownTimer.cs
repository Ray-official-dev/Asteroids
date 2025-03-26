namespace Game.View
{
    public interface IReadOnlyCountdownTimer
    {
        public float CurrentTime { get; }
        public string GetFormattedTime();
    }
}