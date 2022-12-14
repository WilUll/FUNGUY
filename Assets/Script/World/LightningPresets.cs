using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Lightning Presets", menuName = "Scriptables/Lightning Preset", order = 1)]
public class LightningPresets : ScriptableObject
{
    public Gradient AmbientColor;
    public Gradient DirectionalLight;
    public Gradient FogColor;
}
