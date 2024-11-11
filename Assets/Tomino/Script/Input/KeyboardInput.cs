using UnityEngine;
using ICEBOOO;
using System.Collections.Generic;
using System.Linq;

public class KeyboardInput : IPlayerInput
{
    KeyCode pressedKey = KeyCode.None;
    float nextRepeatedKeyTime;

    Dictionary<KeyCode, PlayerAction> actionForKey = new Dictionary<KeyCode, PlayerAction>
    {
        { KeyCode.LeftArrow, PlayerAction.MoveLeft },
        { KeyCode.RightArrow, PlayerAction.MoveRight },
        { KeyCode.DownArrow, PlayerAction.MoveDown },
        { KeyCode.UpArrow, PlayerAction.Rotate },
        { KeyCode.Space, PlayerAction.Fall },
    };

    readonly List<KeyCode> repeatingKeys = new List<KeyCode>()
    {
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.DownArrow
    };

    public PlayerAction? GetPlayerAction()
    {
        var actionKeyDown = GetActionKeyDown();
        if (actionKeyDown == KeyCode.None)
        {
            if (Input.GetKeyUp(pressedKey))
            {
                Cancel();
            }
            else
            {
                return GetActionForRepeatedKey();
            }

            return null;
        }

        StartKeyRepeatIfPossible(actionKeyDown);
        return actionForKey[actionKeyDown];
    }

    public void Update()
    {
    }

    public void Cancel()
    {
        pressedKey = KeyCode.None;
    }

    void StartKeyRepeatIfPossible(KeyCode key)
    {
        if (!repeatingKeys.Contains(key)) return;
        pressedKey = key;
        nextRepeatedKeyTime = Time.time + ConstantGame.Input.KeyRepeatDelay;
    }

    KeyCode GetActionKeyDown()
    {
        return actionForKey.Keys.FirstOrDefault(key => Input.GetKeyDown(key));
    }

    PlayerAction? GetActionForRepeatedKey()
    {
        if (pressedKey == KeyCode.None || !(Time.time >= nextRepeatedKeyTime)) return null;
        nextRepeatedKeyTime = Time.time + ConstantGame.Input.KeyRepeatInterval;
        return actionForKey[pressedKey];
    }
}