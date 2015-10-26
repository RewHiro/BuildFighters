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
    }

    void BothhandsPush()
    {
        hand_move_checkers_ = FindObjectsOfType<HandMoveChecker>();

        if (hand_move_checkers_.Length <= ONE_HAND_DISALLOW_) return;

        if (hand_move_checkers_[0].HandMoveCheck().z == 1
            && hand_move_checkers_[1].HandMoveCheck().z == 1)
        {
            transform.Translate(0, 0, 0.1f);
        }
        else
        if (hand_move_checkers_[0].HandMoveCheck().z == -1
            && hand_move_checkers_[1].HandMoveCheck().z == -1)
        {
            transform.Translate(0, 0, -0.1f);
        }

        if (hand_move_checkers_[0].HandMoveCheck().x == 1
            && hand_move_checkers_[1].HandMoveCheck().x == 1)
        {
            transform.Translate(0.1f, 0, 0);
        }
        else
        if (hand_move_checkers_[0].HandMoveCheck().x == -1
            && hand_move_checkers_[1].HandMoveCheck().x == -1)
        {
            transform.Translate(-0.1f, 0, 0);
        }


    }
}
