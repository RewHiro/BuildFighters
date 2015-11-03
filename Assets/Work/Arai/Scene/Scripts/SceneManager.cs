﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public enum Type
    {
        TITLE,
        GAME,
        MENU,
        CUSTOMIZE,
        RESULT,
    }

    enum FadeStatus
    {
        STOP,
        FADE_OUT,
        FADE_IN
    }

    [System.Serializable]
    public struct Data
    {
        public Type type_;
        public GameObject scene_;
    }

    [SerializeField]
    Data[] datas_ = null;

    [SerializeField]
    Type type_ = Type.TITLE;

    public void Trasition(Type type)
    {
        type_ = type;
        var background = GameObject.FindGameObjectWithTag("Background");
        if (background == null) throw new System.Exception();
        background_ = background.GetComponent<Image>();
    }

    void Awake()
    {
        scene_list_ = datas_.ToDictionary(data => data.type_, data => data.scene_);

        scene_ = scene_list_.ContainsKey(type_) ? scene_list_[type_] : scene_list_[Type.TITLE];

        var scene = Instantiate(scene_);
        scene.name = scene_list_[type_].name;

    }

    void Start()
    {
        var background = GameObject.FindGameObjectWithTag("Background");
        if (background == null) throw new System.Exception();
        background_ = background.GetComponent<Image>();
    }

    void Update()
    {
        if (FadeStatus.STOP == fade_status_) return;
        FadeOut();
        FadeIn();
    }

    void FadeOut()
    {
        if (FadeStatus.FADE_OUT != fade_status_) return;
    }

    void FadeIn()
    {
        if (FadeStatus.FADE_IN != fade_status_) return;
        alpha_ += -Time.deltaTime;
        if (alpha_ >= 1.0f)
        {
            fade_status_ = FadeStatus.STOP;
            alpha_ = 1.0f;
        }
        background_.color = new Color(0, 0, 0, alpha_);
    }

    Dictionary<Type, GameObject> scene_list_ = new Dictionary<Type, GameObject>();
    GameObject scene_ = null;
    Image background_ = null;
    FadeStatus fade_status_ = FadeStatus.FADE_IN;
    float alpha_ = 1.0f;
}
