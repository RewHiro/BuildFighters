using UnityEngine;
using System.Collections;

public class HandMoveChecker : MonoBehaviour
{
    [System.NonSerialized]
    public Vector3 hand_pos_;

    [System.NonSerialized]
    public Vector3 hand_old_pos_;

    [System.NonSerialized]
    public bool once_position_unification_;

    [System.NonSerialized]
    public Vector3 distance_difference_;

    [System.NonSerialized]
    public float max_hand_distance_;


    public virtual Vector3  HandMoveCheck() { return new Vector3(0,0,0); }

}
