using System.Collections.Generic;
using UnityEngine;

namespace PieceManager;

public class MaterialData
{
    public static List<Material> processedMaterials = [];
    public Material material;
    public MaterialReplacer.ShaderType shaderType;
    public Dictionary<string, float> m_floatProperties = new();
    public Dictionary<string, string> textureTransfer = new();
    
    public MaterialData(Material material, MaterialReplacer.ShaderType shaderType)
    {
        this.material = material;
        this.shaderType = shaderType;
        MaterialReplacer.materialsToSet.Add(this);
    }

    public void Process()
    {
        if (processedMaterials.Contains(material)) return;
        
        var glossMap = material.GetTexture("_MetallicGlossMap");
        
        material.shader = MaterialReplacer.GetShaderForType(material.shader,  shaderType, material.shader.name);
        
        if (material.HasProperty("_MetallicTex"))
        {
            material.SetTexture("_MetallicTex", glossMap);
        }
        
        //
        foreach (var kvp in m_floatProperties)
        {
            if (material.HasProperty(kvp.Key))
            {
                material.SetFloat(kvp.Key, kvp.Value);
            }
        }
        
        processedMaterials.Add(material);
    }
}

///// PIECE SHADER
// _MainTex
// _BumpMap
// _EmissionMap
// _NoiseTex
// _MetallicTex
// _Cutoff
// _BumpScale
// _Glossiness
// _Metallic
// _Cull
// _AddRain
// _ColorFoldout
// _EmissionSpacer
// _MetallicAlphaGloss
// _MiscFoldout
// _MoveableObject
// _NoiseFoldout
// _NormalFoldout
// _RippleDistance
// _RippleFreq
// _SmoothnessFoldout
// _TriplanarFoldout
// _TriplanarLocalPos
// _TriplanarMap
// _TriplanarScale
// _TwoSidedNormals
// _ValueNoise
// _ValueNoiseVertex


///// ROCK SHADER
// _MainTex
// _BumpMap
// _EmissiveTex
// _GlossMap
// _MetalTex
// _MossTex
// _BumpScale
// _Glossiness
// _Metallic
// _AddSnow
// _AddRain
// _ColorFoldout
// _EmissionSpacer
// _NormalFoldout
// _RippleDistance
// _RippleFreq
// _SmoothnessFoldout
// _TriplanarMap
// _TriplanarScale
// _MetalGloss
// _EndFoldout
// _FresnelPower
// _MossAlpha
// _MossBlend
// _MossFoldout
// _MossGloss
// _MossNormal
// _MossTransition
// _SmoothnessSpacer
// _UseGlossMap
// _WaterlineOffset



///// VEGETATION SHADER
// _Cutoff
// _BumpScale
// _Glossiness
// _Metallic
// _Cull
// _AddSnow
// _AddRain
// _Height
// _RippleDeadzoneMax
// _RippleDeadzoneMin
// _RippleDistance
// _RippleSpeed
// _SwayDistance
// _SwaySpeed
// _TwoSidedNormals
// _MetalGloss
// _CamCull
// _PushDistance
// _MossAlpha
// _MossBlend
// _MossNormal
// _MossTransition
// _SphereNormals
// _SphereOffset
// _PushClothMode
// _SnowSparkleLum
// _USEMETALMAP
// _UV2Height
// _MainTex
// _BumpMap
// _EmissiveTex
// _MetalTex
// _MossTex