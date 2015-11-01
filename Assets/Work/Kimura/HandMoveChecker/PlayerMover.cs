using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour
{

    LeftHandMoveChecker left_hand_move_checker_;
    RightHandMoveChecker right_hand_move_chacker_;

    const int ONE_HAND_DISALLOW_ = 1;

    void Start()
    {
        left_hand_move_checker_ = FindObjectOfType<LeftHandMoveChecker>();
        right_hand_move_chacker_ = FindObjectOfType<RightHandMoveChecker>();

    }


    void Update()
    {
        BothhandsPush();
    }

    void BothhandsPush()
    {
        left_hand_move_checker_ = FindObjectOfType<LeftHandMoveChecker>();
        right_hand_move_chacker_ = FindObjectOfType<RightHandMoveChecker>();

        if (left_hand_move_checker_ == null || right_hand_move_chacker_ == null) return;

        Debug.Log(left_hand_move_checker_.HandMoveCheck().z);
        Debug.Log(right_hand_move_chacker_.HandMoveCheck().z);


        if (left_hand_move_checker_.HandMoveCheck().z == 1
            && right_hand_move_chacker_.HandMoveCheck().z == 1)
        {
            transform.Translate(0, 0, 0.1f);
        }
        else
        if (left_hand_move_checker_.HandMoveCheck().z == -1
            && right_hand_move_chacker_.HandMoveCheck().z == -1)
        {
            transform.Translate(0, 0, -0.1f);
        }

        if (left_hand_move_checker_.HandMoveCheck().x == 1
            && right_hand_move_chacker_.HandMoveCheck().x == 1)
        {
            transform.Translate(0.1f, 0, 0);
        }
        else
        if (left_hand_move_checker_.HandMoveCheck().x == -1
            && right_hand_move_chacker_.HandMoveCheck().x == -1)
        {
            transform.Translate(-0.1f, 0, 0);
        }


    }
}
