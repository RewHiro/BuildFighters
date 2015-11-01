using UnityEngine;
using System.Collections;

public class LeftOrRightHandChecker : MonoBehaviour {

    RigidHand rigid_hand_;

    LeftHandMoveChecker left_hand_move_checker_;

    RightHandMoveChecker right_hand_move_checker_;

	void Start ()
    {
        rigid_hand_ = GetComponent<RigidHand>();
        left_hand_move_checker_ = GetComponent<LeftHandMoveChecker>();
        right_hand_move_checker_ = GetComponent<RightHandMoveChecker>();
    }
	
	void Update ()
    {
        LeftOrRightHandCheck();
    }


    void LeftOrRightHandCheck()
    {
        if (rigid_hand_.GetLeapHand().IsLeft)
        {
            left_hand_move_checker_ = GetComponent<LeftHandMoveChecker>();
            right_hand_move_checker_ = GetComponent<RightHandMoveChecker>();

            left_hand_move_checker_.enabled = true;
            right_hand_move_checker_.enabled = false;
        }
        else
        if(rigid_hand_.GetLeapHand().IsRight)
        {
            left_hand_move_checker_ = GetComponent<LeftHandMoveChecker>();
            right_hand_move_checker_ = GetComponent<RightHandMoveChecker>();

            left_hand_move_checker_.enabled = false;
            right_hand_move_checker_.enabled = true;

        }
    }
}
