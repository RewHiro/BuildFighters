﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerRotater : NetworkBehaviour
{
    void Start()
    {
        player_controller_ = GetComponent<PlayerController>();

        var air_frame_parameter = FindObjectOfType<AirFrameParameter>();
        var id = GetComponent<Identificationer>().id;

        SWING_SPEED = air_frame_parameter.GetSwingSpeed(id);
    }

    void Update()
    {
        var rotate_value = player_controller_.getRotateValue;
        if (rotate_value == 0.0f) return;

        gameObject.transform.Rotate(gameObject.transform.up, rotate_value * SWING_SPEED * Time.deltaTime);
    }

    PlayerController player_controller_ = null;
    float SWING_SPEED = 0.0f;
}
