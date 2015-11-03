using UnityEngine;
using System.Collections;

public class HandInput : MonoBehaviour
{
    [SerializeField]
    float difference_refeerence_ = 1.0f;

    Vector3 reference_point_ = Vector3.zero;
    bool is_left_ = false;

    public bool isLeftHand
    {
        get
        {
            return is_left_;
        }
    }


    public bool isRighthand
    {
        get
        {
            return is_left_;
        }
    }

    public float getLeftHandVerticalValue
    {
        get
        {
            var value = reference_point_ - gameObject.transform.position;
            value.y = 0;
            return 0.0f;
        }
    }

    void Awake()
    {

    }

    void Start()
    {
        if (GetComponent<HandModel>().GetLeapHand().IsLeft)
        {
            difference_refeerence_ *= -1;
            is_left_ = true;
        }



        var parent = gameObject.transform.parent;

        reference_point_ =
            parent.position +
            parent.right * difference_refeerence_;
    }

    void Update()
    {
        Debug.Log(GetComponent<HandModel>().GetLeapHand().PalmPosition);

        var parent = gameObject.transform.parent;

        reference_point_ =
            parent.position +
            parent.right * difference_refeerence_;
    }
}
