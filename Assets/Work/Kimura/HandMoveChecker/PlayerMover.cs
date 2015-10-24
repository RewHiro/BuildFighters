using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour
{

    HandMoveChecker[] hand_move_checker;


    void Start()
    {
        hand_move_checker = FindObjectsOfType<HandMoveChecker>();
    }


    void Update()
    {
        BothhandsPush();
    }

    void BothhandsPush()
    {
        hand_move_checker = FindObjectsOfType<HandMoveChecker>();

        if (!(hand_move_checker.Length == 2)) return;

        if (hand_move_checker[0].HandMoveCheck() == HandMoveChecker.MoveType.ADVANCE 
            && hand_move_checker[1].HandMoveCheck() == HandMoveChecker.MoveType.ADVANCE)
        {
            transform.Translate(0, 0, 0.1f);
        }
        else
        if (hand_move_checker[0].HandMoveCheck() == HandMoveChecker.MoveType.BACKWARD
            && hand_move_checker[1].HandMoveCheck() == HandMoveChecker.MoveType.BACKWARD)
        {
            transform.Translate(0, 0, -0.1f);
        }


    }
}
