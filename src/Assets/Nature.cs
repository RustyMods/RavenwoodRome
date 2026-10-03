using System.Collections.Generic;
using PieceManager;
using UnityEngine;

namespace RavenwoodRome;

public static partial class Assets
{
    private static Dictionary<string, string> bushes = new()
    {
        ["piece_rome_bush_1"] = "Roman Bush"
    };

    private static Dictionary<string, string> grasses = new()
    {
        ["piece_rome_grass"] = "Roman Grass"
    };

    private static Dictionary<string, string> rocks = new()
    {
        ["piece_rome_rock_1"] = "Roman Rock",
        ["piece_rome_rock_2"] = "Roman Rock",
        ["piece_rome_rock_3"] = "Roman Rock",
        ["piece_rome_rock_4"] = "Roman Rock",
        ["piece_rome_rock_5"] = "Roman Rock",
        ["piece_rome_rock_6"] = "Roman Rock",
        ["piece_rome_rock_7"] = "Roman Rock",
        ["piece_rome_rock_8"] = "Roman Rock",
        ["piece_rome_rock_9"] = "Roman Rock",
        ["piece_rome_rock_10"] = "Roman Rock",
    };

    private static Dictionary<string, string> trees = new()
    {
        ["piece_rome_tree_1"] = "Roman Tree",
        ["piece_rome_tree_2"] = "Roman Tree",
        ["piece_rome_tree_3"] = "Roman Tree",
        ["piece_rome_tree_4"] = "Roman Tree",
        ["piece_rome_tree_5"] = "Roman Tree",
    };

    public static void LoadNature()
    {
        foreach (var kvp in bushes)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_hitEffect = new EffectListRef("sfx_bush_hit", "vfx_bush_puff");
            wnt.m_destroyedEffect = new EffectListRef("vfx_bush_destroyed", "sfx_bush_hit");
            build.Name.English(name);
            build.Category.Set("Ravenwood");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Wood", 1, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.VegetationShader);
        }

        foreach (var kvp in grasses)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_hitEffect = new EffectListRef("sfx_bush_hit", "vfx_bush_puff");
            wnt.m_destroyedEffect = new EffectListRef("vfx_bush_destroyed", "sfx_bush_hit");
            build.Name.English(name);
            build.Category.Set("Ravenwood");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Wood", 1, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            
            var meshRenderer = build.Prefab.GetComponentInChildren<MeshRenderer>();
            var materials = meshRenderer.sharedMaterials;
            var grass = materials[0];
            var grassData = new MaterialData(grass, MaterialReplacer.ShaderType.VegetationShader);
            grassData.floatProps["_Height"] = 5f;
            grassData.floatProps["_SwaySpeed"] = 10f;
            grassData.floatProps["_SwayDistance"] = 25f;
            grassData.floatProps["_RippleSpeed"] = 150f;
            grassData.floatProps["_RippleDistance"] = 2f;
            grassData.floatProps["_RippleDeadzoneMin"] = 2f;
            grassData.floatProps["_RippleDeadzoneMax"] = 3f;
            grassData.floatProps["_AddSnow"] = 1f;
            grassData.floatProps["_AddRain"] = 1f;       
            grassData.floatProps["_PushDistance"] = 0.4f;
            grassData.floatProps["_PushClothMode"] = 1f;
        }

        foreach (var kvp in rocks)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_stone");
            wnt.m_hitEffect = new EffectListRef("sfx_rock_hit", "vfx_RockHit");
            wnt.m_destroyedEffect = new EffectListRef("sfx_rock_destroyed", "vfx_RockDestroyed");
            build.Name.English(name);
            build.Category.Set("Ravenwood");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Stone", 1, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            
            var meshRenderer = build.Prefab.GetComponentInChildren<MeshRenderer>();
            var materials = meshRenderer.sharedMaterials;
            foreach (var material in materials)
            {
                var matData = new MaterialData(material, MaterialReplacer.ShaderType.RockShader);
                matData.floatProps["_MossAlpha"] = 0f;
            }
            
        }

        foreach (var kvp in trees)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_hitEffect = new EffectListRef("vfx_beech_cut", "sfx_tree_hit");
            wnt.m_destroyedEffect = new EffectListRef("vfx_beech_small1_destroy", "sfx_tree_fall");
            build.Name.English(name);
            build.Category.Set("Ravenwood");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("FineWood", 10, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            
            var meshRenderer = build.Prefab.GetComponentInChildren<MeshRenderer>();
            var materials = meshRenderer.sharedMaterials;
            var bark = materials[0];
            var leaves = materials[1];

            var barkData = new MaterialData(bark, MaterialReplacer.ShaderType.VegetationShader);
            barkData.floatProps["_Height"] = 35f;
            barkData.floatProps["_SwaySpeed"] = 10f;
            barkData.floatProps["_SwayDistance"] = 25f;
            barkData.floatProps["_RippleSpeed"] = 100f;
            barkData.floatProps["_RippleDistance"] = 0f;
            barkData.floatProps["_RippleDeadzoneMin"] = 0.47f;
            barkData.floatProps["_RippleDeadzoneMax"] = 2.65f;
            barkData.floatProps["_AddSnow"] = 1f;
            barkData.floatProps["_AddRain"] = 1f;
            var leavesData = new MaterialData(leaves, MaterialReplacer.ShaderType.VegetationShader);
            leavesData.floatProps["_Height"] = 35f;
            leavesData.floatProps["_SwaySpeed"] = 10f;
            leavesData.floatProps["_SwayDistance"] = 25f;
            leavesData.floatProps["_RippleSpeed"] = 150f;
            leavesData.floatProps["_RippleDistance"] = 2f;
            leavesData.floatProps["_RippleDeadzoneMin"] = 2f;
            leavesData.floatProps["_RippleDeadzoneMax"] = 3f;
            leavesData.floatProps["_AddSnow"] = 1f;
            leavesData.floatProps["_AddRain"] = 1f;
        }
    }
}