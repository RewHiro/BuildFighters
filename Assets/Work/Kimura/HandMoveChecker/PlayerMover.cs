using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour
{

<<<<<<< HEAD
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


=======
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


>>>>>>> 292285c372a16632ce70f013cd869414d789236f
    }
}
