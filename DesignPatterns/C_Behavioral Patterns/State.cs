namespace DesignPatterns.C_Behavioral_Patterns;


public enum State
{
    Started,
    Running,
    Stopped
}

public enum Action
{
    Start,
    Accelerate,
    Stop,
}

public class Vehicle
{
    public State CurrentState { get; set; }

    public Vehicle()
    {
        CurrentState = State.Stopped;
    }

    public void ChangeState(Action action)
    {
        CurrentState=(CurrentState,action)switch
        {
            (State.Stopped,Action.Start)=>State.Started,
            (State.Started,Action.Stop)=>State.Stopped,
            (State.Started, Action.Accelerate) => State.Running,
            (State.Running,Action.Stop)=>State.Stopped,
            _=>CurrentState
        };
    }

    public override string ToString()
    {
        return $"Current State: {CurrentState}";
    }
}