using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INetworkController
{
    float HorizontalInputMovement { get; }
    float VerticalInputMovement { get;}
    float HorizontalMouseMovement { get; }
    float VerticalMouseMovement { get;}
}
