using UnityEngine;
using System.Collections;

public class IsHandExist : MonoBehaviour {

<<<<<<< HEAD

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


        
=======
    SkeletalHand[] skeletal_hand_;

    void Start ()
    {

    }

   public bool IsExistence()
    {
        skeletal_hand_ = GetComponentsInChildren<SkeletalHand>();


        if (!(skeletal_hand_.Length == 0)) return true;

        return false;
>>>>>>> 292285c372a16632ce70f013cd869414d789236f
    }

}
