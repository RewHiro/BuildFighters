using UnityEngine;
using System.Collections;

public class HandMoveChecker : MonoBehaviour {

    HandController hand_controller_ = null;

    Vector3 hand_pos_;
    Vector3 hand_old_pos_;

    SkeletalHand[] hand1;



    void Start()
    {
        hand_controller_ = FindObjectOfType<HandController>();
        //hand_pos_ = new Vector3[hand1.Length];
        //hand_old_pos_ = new Vector3[hand1.Length];


    }


    void Update()
    {
        HandMoveCheck();
    }

    void HandMoveCheck()
    {

        foreach (var hand in FindObjectsOfType<SkeletalHand>())
        {

            hand_pos_ = hand.GetPalmPosition();

            if (hand_pos_.z > hand_old_pos_.z + 0.3f)
            {

                transform.Translate(0, 0, 0.1f);
                return;
            }
            hand_old_pos_ = hand_pos_;
        }


        //hand1 = FindObjectsOfType<SkeletalHand>();

        //for (int i = 0; i < hand1.Length; ++i)
        //{
        //    hand_pos_[i] = hand1.GetPalmPosition();
        //}
    }

}
