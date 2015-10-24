using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour
{

    HandMoveChecker[] hand_move_checkers_;

   const int ONE_HAND_DISALLOW_ = 1;

    void Start()
    {
        hand_move_checkers_ = FindObjectsOfType<HandMoveChecker>();
    }


    void Update()
    {
        BothhandsPush();
        Debug.Log(hand_move_checkers_.Length);
    }

    void BothhandsPush()
    {
        hand_move_checkers_ = FindObjectsOfType<HandMoveChecker>();

        if (hand_move_checkers_.Length <= ONE_HAND_DISALLOW_) return;

        if (hand_move_checkers_[0].HandMoveCheck() == HandMoveChecker.MoveType.ADVANCE 
            && hand_move_checkers_[1].HandMoveCheck() == HandMoveChecker.MoveType.ADVANCE)
        {
            transform.Translate(0, 0, 0.1f);
        }
        else
        if (hand_move_checkers_[0].HandMoveCheck() == HandMoveChecker.MoveType.BACKWARD
            && hand_move_checkers_[1].HandMoveCheck() == HandMoveChecker.MoveType.BACKWARD)
        {
            transform.Translate(0, 0, -0.1f);
        }


    }
}
