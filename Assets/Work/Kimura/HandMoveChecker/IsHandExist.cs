using UnityEngine;
using System.Collections;

public class IsHandExist : MonoBehaviour {

    SkeletalHand[] skeletal_hand_;

    void Start ()
    {

    }

   public bool IsExistence()
    {
        skeletal_hand_ = GetComponentsInChildren<SkeletalHand>();


        if (!(skeletal_hand_.Length == 0)) return true;

        return false;
    }

}
