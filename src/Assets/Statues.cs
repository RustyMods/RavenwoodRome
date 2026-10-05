using System.Collections.Generic;
using PieceManager;
using UnityEngine;

namespace RavenwoodRome;

public static partial class Assets
{
    private static Dictionary<string, string> sculptures = new()
    {
        ["piece_sculpture_athena_gold"] = "Athena 1",
        ["piece_sculpture_athena_stone"] = "Athena 2",
        ["piece_sculpture_augustus_gold"] = "Augustus 1",
        ["piece_sculpture_augustus_stone"] = "Augustus 2",
        ["piece_sculpture_goddess_gold"] = "Goddess 1",
        ["piece_sculpture_goddess_stone"] = "Goddess 2",
        ["piece_sculpture_man_gold"] = "Man 1",
        ["piece_sculpture_man_stone"] = "Man 2",
        ["piece_sculpture_midathrias_gold"] = "Midathrias 1",
        ["piece_sculpture_midathrias_stone"] = "Midathrias 2",
        ["piece_sculpture_putti_1_gold"] = "Putti 1",
        ["piece_sculpture_putti_1_stone"] = "Putti 2",
        ["piece_sculpture_putti_2_gold"] = "Putti 3",
        ["piece_sculpture_putti_2_stone"] = "Putti 4",
        ["piece_sculpture_putti_3_gold"] = "Putti 5",
        ["piece_sculpture_putti_3_stone"] = "Putti 6",
        ["piece_sculpture_putti_4_gold"] = "Putti 7",
        ["piece_sculpture_putti_4_stone"] = "Putti 8",
        ["piece_sculpture_putti_5_gold"] = "Putti 9",
        ["piece_sculpture_putti_5_stone"] = "Putti 10",
        ["piece_sculpture_soldier_gold"] = "Soldier 1",
        ["piece_sculpture_soldier_stone"] = "Soldier 2",
        ["piece_sculpture_woman_gold"] = "Woman 1",
        ["piece_sculpture_woman_stone"] = "Woman 2",
    };
    
    public static void LoadSculptures()
    {
        Dictionary<string, GameObject> largeVersions = new();
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
            build.Category.Set("Ravenwood");
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

            var large = UnityEngine.Object.Instantiate(build.Prefab, RavenwoodRomePlugin.rt);
            large.name = build.Prefab.name + "_large";
            for (int i = 0; i < large.transform.childCount; ++i)
            {
                var child = large.transform.GetChild(i);
                child.localScale *= 2;
            }
            largeVersions[name] = large;
        }

        foreach (var kvp in largeVersions)
        {
            var name = "Large " + kvp.Key;
            BuildPiece build = new BuildPiece(kvp.Value);
            var piece = build.Prefab.GetComponent<Piece>();
            piece.m_name += "_large";
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_stone");
            wnt.m_hitEffect = new EffectListRef("sfx_rock_hit", "vfx_HitSparks");
            wnt.m_destroyedEffect = new EffectListRef("sfx_rock_destroyed", "vfx_RockDestroyed_large");
            build.Name.English(name);
            build.Category.Set("Ravenwood");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Stone", 40, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
        }
    }    
}