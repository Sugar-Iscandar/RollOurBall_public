using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMovable
{
    Rigidbody PlayerRigidbody
    {
        get;
        set;
    }

    bool IsDevelopFloating
    {
        get;
        set;
    }
}
