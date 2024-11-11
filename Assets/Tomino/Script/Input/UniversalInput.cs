using ICEBOOO;
using System.Collections.Generic;
using System.Linq;

public class UniversalInput : IPlayerInput
{
    List<IPlayerInput> inputs = new List<IPlayerInput>();

    public UniversalInput(params IPlayerInput[] inputs)
    {
        this.inputs = new List<IPlayerInput>(inputs);
    }

    public void Update() => inputs.ForEach(input => input.Update());

    public void Cancel() => inputs.ForEach(input => input.Cancel());

    public PlayerAction? GetPlayerAction()
    {
        foreach (var action in inputs.Select(input => input.GetPlayerAction()).Where(action => action != null))
        {
            return action;
        }

        return null;
    }
}