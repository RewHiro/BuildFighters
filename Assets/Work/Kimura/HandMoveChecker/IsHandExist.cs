using UnityEngine;
using System.Collections;

public class IsHandExist : MonoBehaviour {


    SkeletalHand[] skeletal_hand_;

    bool once_position_unification_;


    void Start ()
    {
        once_position_unification_ = false;

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

   public bool HandAppearOrVanish()
    {
        if (IsExistence() == true
            && once_position_unification_ == false)
        {
            once_position_unification_ = true;
        }
        else
        if (IsExistence() == false
            && once_position_unification_ == true)
        {
            once_position_unification_ = false;
        }

       return once_position_unification_;
    }
}
