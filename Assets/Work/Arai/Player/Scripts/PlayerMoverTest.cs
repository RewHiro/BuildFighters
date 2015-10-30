using UnityEngine;
using System.Collections;

public class PlayerMoverTest : MonoBehaviour
{
    void Start()
    {
        player_controller_ = GetComponent<PlayerController>();

        var air_frame_parameter = FindObjectOfType<AirFrameParameter>();
        var id = GetComponent<Identificationer>().id;

        MOVE_SPEED = air_frame_parameter.GetMoveSpeed(id);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {

        var vartical_axis = player_controller_.getInputVerticalValue;
        var horizontal_axis = player_controller_.getInputHorizontalValue;

        if (vartical_axis == 0.0f &&
            horizontal_axis == 0.0f)
            return;

        var direction = gameObject.transform.forward;
        var cross = Vector3.Cross(direction, gameObject.transform.up).normalized;

        direction = direction * vartical_axis;
        direction += -cross * horizontal_axis;

        var slope = 0.0f;
        if (vartical_axis == 0.0f)
        {
            slope = Mathf.Abs(horizontal_axis);
        }
        else if (horizontal_axis == 0.0f)
        {
            slope = Mathf.Abs(vartical_axis);
        }
        else
        {
            slope = (Mathf.Abs(horizontal_axis) + Mathf.Abs(vartical_axis)) * 0.5f;
        }

        gameObject.transform.localPosition +=
            direction.normalized * MOVE_SPEED * slope;
    }

    PlayerController player_controller_ = null;
    float MOVE_SPEED = 0.0f;
}
