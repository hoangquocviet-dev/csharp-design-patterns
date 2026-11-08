namespace DesignPatterns.Behavioral.State;

public interface IPlayerState { void Play(); void Pause(); }

public class PlayingState : IPlayerState {
    public void Play() => Console.WriteLine("Already playing.");
    public void Pause() => Console.WriteLine("Pausing track.");
}
