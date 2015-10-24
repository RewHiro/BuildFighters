using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour
{

    HandMoveChecker[] hand_move_checker_;

    public HandMoveChecker[] Hand_move_checker_
    {
        get
        {
            return hand_move_checker_;
        }

        set
        {
            hand_move_checker_ = value;
        }
    }

    void Start()
    {
        hand_move_checker_ = FindObjectsOfType<HandMoveChecker>();
    }


    void Update()
    {
        BothhandsPush();
    }

    void BothhandsPush()
    {
        hand_move_checker_ = FindObjectsOfType<HandMoveChecker>();

        if (!(hand_move_checker_.Length <= 1)) return;

        if (hand_move_checker_[0].HandMoveCheck() == HandMoveChecker.MoveType.ADVANCE 
            && hand_move_checker_[1].HandMoveCheck() == HandMoveChecker.MoveType.ADVANCE)
        {
            transform.Translate(0, 0, 0.1f);
        }
        else
        if (hand_move_checker_[0].HandMoveCheck() == HandMoveChecker.MoveType.BACKWARD
            && hand_move_checker_[1].HandMoveCheck() == HandMoveChecker.MoveType.BACKWARD)
        {
            transform.Translate(0, 0, -0.1f);
        }


    }
}
