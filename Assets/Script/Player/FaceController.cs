using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceController : MonoBehaviour
{
    [SerializeField] FaceClass[] faces;
    
    [SerializeField] Emotion currentEmotion;

    // private void OnValidate()
    // {
    //     FaceClass CurrentClass = new FaceClass();
    //     foreach (FaceClass face in faces)
    //     {
    //         face.Eyes.SetActive(face.Emotion == currentEmotion);
    //         face.Mouth.SetActive(face.Emotion == currentEmotion);
    //         face.Eyebrows.SetActive(face.Emotion == currentEmotion);
    //         face.Face.SetActive(face.Emotion == currentEmotion);
    //
    //         if (face.Emotion == currentEmotion)
    //         {
    //             CurrentClass = face;
    //         }
    //     }
    //
    //     CurrentClass.Eyes.SetActive(true);
    //     CurrentClass.Mouth.SetActive(true);
    //     CurrentClass.Eyebrows.SetActive(true);
    //     CurrentClass.Face.SetActive(true);
    // }
}

[Serializable]
class FaceClass
{
    public Emotion Emotion;
    public GameObject Eyes;
    public GameObject Mouth;
    public GameObject Eyebrows;
    public GameObject Face;
}

enum Emotion
{
    Neutral,
    Happy,
    Angry,
    Sad,
    Sick,
    Scared
}
