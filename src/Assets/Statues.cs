using System.Collections.Generic;
using PieceManager;
using UnityEngine;

namespace RavenwoodRome;

public static partial class Assets
{
    private static Dictionary<string, string> sculptures = new()
    {
        ["piece_sculpture_athena_gold"] = "Athena",
        ["piece_sculpture_athena_stone"] = "Athena",
        ["piece_sculpture_augustus_gold"] = "Augustus",
        ["piece_sculpture_augustus_stone"] = "Augustus",
        ["piece_sculpture_goddess_gold"] = "Goddess",
        ["piece_sculpture_goddess_stone"] = "Goddess",
        ["piece_sculpture_man_gold"] = "Man",
        ["piece_sculpture_man_stone"] = "Man",
        ["piece_sculpture_midathrias_gold"] = "Midathrias",
        ["piece_sculpture_midathrias_stone"] = "Midathrias",
        ["piece_sculpture_putti_1_gold"] = "Putti",
        ["piece_sculpture_putti_1_stone"] = "Putti",
        ["piece_sculpture_putti_2_gold"] = "Putti",
        ["piece_sculpture_putti_2_stone"] = "Putti",
        ["piece_sculpture_putti_3_gold"] = "Putti",
        ["piece_sculpture_putti_3_stone"] = "Putti",
        ["piece_sculpture_putti_4_gold"] = "Putti",
        ["piece_sculpture_putti_4_stone"] = "Putti",
        ["piece_sculpture_putti_5_gold"] = "Putti",
        ["piece_sculpture_putti_5_stone"] = "Putti",
        ["piece_sculpture_soldier_gold"] = "Soldier",
        ["piece_sculpture_soldier_stone"] = "Soldier",
        ["piece_sculpture_woman_gold"] = "Woman",
        ["piece_sculpture_woman_stone"] = "Woman",
    };
    
    public static void LoadSculptures()
    {
        foreach (var kvp in sculptures)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_stone");
            wnt.m_hitEffect = new EffectListRef("sfx_rock_hit", "vfx_HitSparks");
            wnt.m_destroyedEffect = new EffectListRef("sfx_rock_destroyed", "vfx_RockDestroyed");
            build.Name.English(name);
            build.Category.Set("Ravenwood Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Stone", 20, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            
            // MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.RockShader);

            var meshRenderer = build.Prefab.GetComponentInChildren<MeshRenderer>();
            var materials = meshRenderer.sharedMaterials;
            foreach (var material in materials)
            {
                var matData = new MaterialData(material, MaterialReplacer.ShaderType.RockShader);
                matData.floatProps["_MossAlpha"] = 0f;
                // matData.floatProps["_MetalGloss"] = 1f;
                // matData.floatProps["_Metallic"] = 0.75f;
                
            }
        }
    }    
}