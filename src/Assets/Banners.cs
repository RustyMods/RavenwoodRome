using System.Collections.Generic;
using PieceManager;
using UnityEngine;

namespace RavenwoodRome;

public static partial class Assets
{
    public static void LoadBanners()
    {
        for (int i = 1; i < 7; ++i)
        {
            var id = "piece_banner_rome_" + i;
            var name = "Roman Banner";
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_hitEffect = new EffectListRef("sfx_wood_hit");
            wnt.m_destroyedEffect = new EffectListRef("sfx_wood_destroyed");
            build.Name.English(name);
            build.Category.Set("Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Wood", 1, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();

            if (i == 1)
            {
                var meshRenderer = build.Prefab.GetComponentInChildren<MeshRenderer>();
                var materials = meshRenderer.sharedMaterials;
                var metalMat = materials[0];
                var bannerMat =  materials[1];
                
                var metalDat = new MaterialData(metalMat, MaterialReplacer.ShaderType.RockShader);
                var bannerDat = new MaterialData(bannerMat, MaterialReplacer.ShaderType.VegetationShader);
            }
        }
    }
}