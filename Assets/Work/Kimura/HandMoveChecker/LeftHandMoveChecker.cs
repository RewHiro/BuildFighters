using UnityEngine;
using System.Collections;

public class LeftHandMoveChecker : HandMoveChecker
{

    HandController hand_controller_ = null;

    RigidHand rigid_hand_;

    IsHandExist is_hand_exist_;

    [SerializeField]
    Vector3 left_hand_pos_zero_ = new Vector3(0, 0, 0);

   

    void Start()
    {
       

        max_hand_distance_ = 1;
        rigid_hand_ = GetComponent<RigidHand>();
        hand_controller_ = FindObjectOfType<HandController>();
        is_hand_exist_ = GetComponentInParent<IsHandExist>();

        hand_pos_ = rigid_hand_.GetPalmPosition();
        if (rigid_hand_.GetLeapHand().IsLeft)
        {
            hand_old_pos_ = left_hand_pos_zero_;
        }

        once_position_unification_ = false;
        distance_difference_ = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        if (rigid_hand_.GetLeapHand().IsLeft)
        {

            HandMoveCheck();
        }
    }

    public override Vector3 HandMoveCheck()
    {

        if (rigid_hand_.GetLeapHand().IsLeft)
        {
            hand_old_pos_ = left_hand_pos_zero_;

            hand_pos_ = rigid_hand_.GetPalmPosition();


            if (hand_pos_.z > hand_old_pos_.z)
            {
                distance_difference_.z = max_hand_distance_;
            }
            else

            if (hand_pos_.z < hand_old_pos_.z)
            {
                distance_difference_.z = -max_hand_distance_;
            }
            else
            {
                distance_difference_.z = 0;
            }

            if (hand_pos_.x > hand_old_pos_.x)
            {
                distance_difference_.x = max_hand_distance_;
            }
            else
            if (hand_pos_.x < hand_old_pos_.x)
            {
                distance_difference_.x = -max_hand_distance_;
            }
            else
            {
                distance_difference_.x = 0;
            }

        }

        return distance_difference_;
    }

}
