using System.Collections.Generic;
using PieceManager;
using UnityEngine;

namespace RavenwoodRome;

public static partial class Assets
{
    private static Dictionary<string, string> banners = new()
    {
        ["piece_banner_rome_1"] = "Roman Banner",
        ["piece_banner_rome_2"] = "Roman Banner",
        ["piece_banner_rome_3"] = "Roman Banner",
        ["piece_banner_rome_4"] = "Roman Banner",
        ["piece_banner_rome_5"] = "Roman Banner",
        ["piece_banner_rome_6"] = "Roman Banner",
    };
    public static void LoadBanners()
    {
        bool loadedMat = false;
        
        foreach (var kvp in banners)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_hitEffect = new EffectListRef("sfx_wood_hit");
            wnt.m_destroyedEffect = new EffectListRef("sfx_wood_destroyed");
            build.Name.English(name);
            build.Category.Set("Ravenwood Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Wood", 10, true);
            build.RequiredItems.Add("Tin", 1, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();

            if (!loadedMat)
            {
                var meshRenderer = build.Prefab.GetComponentInChildren<MeshRenderer>();
                var materials = meshRenderer.sharedMaterials;
                var metalMat = materials[0];
                var bannerMat =  materials[1];
                
                var metalDat = new MaterialData(metalMat, MaterialReplacer.ShaderType.RockShader);
                var bannerDat = new MaterialData(bannerMat, MaterialReplacer.ShaderType.VegetationShader);
                bannerDat.m_floatProperties["_AddRain"] = 1f;
                bannerDat.m_floatProperties["_Height"] = 15f;
                bannerDat.m_floatProperties["_SwaySpeed"] = 15f;
                bannerDat.m_floatProperties["_RippleSpeed"] = 50f;
                bannerDat.m_floatProperties["_RippleDistance"] = 0.5f;
                bannerDat.m_floatProperties["_RippleDeadzoneMin"] = 0f;
                bannerDat.m_floatProperties["_RippleDeadzoneMax"] = 0f;
                bannerDat.m_floatProperties["_PushDistance"] = 0.4f;
                bannerDat.m_floatProperties["_PushClothMode"] = 1f;
                bannerDat.m_floatProperties["_CamCull"] = 0f;
                bannerDat.m_floatProperties["_TwoSidedNormals"] = 0f;
                loadedMat = true;
            }
        }
    }
}