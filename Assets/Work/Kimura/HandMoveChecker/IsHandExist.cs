using UnityEngine;
using System.Collections;

public class IsHandExist : MonoBehaviour {


    SkeletalHand[] skeletal_hand_;



    void Start ()
    {

    }

    void Update ()
    {
    }

   public bool IsExistence()
    {
        skeletal_hand_ = GetComponentsInChildren<SkeletalHand>();


        if (skeletal_hand_.Length == 0)
        {
            return false;
        }
        else
        {
            return true;
        }


        
    }

}
