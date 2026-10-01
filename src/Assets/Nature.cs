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
        // ["piece_rome_tree_5"] = "Roman Tree",
    };

    private static string lastTree = "piece_rome_tree_5";
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
            build.Category.Set("Rome");
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
            build.Category.Set("Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Wood", 1, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.VegetationShader);
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
            build.Category.Set("Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Stone", 1, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.RockShader);
        }

        bool treeMatRegistered = false;
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
            build.Category.Set("Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Wood", 1, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();

            if (!treeMatRegistered)
            {
                var meshRenderer = build.Prefab.GetComponentInChildren<MeshRenderer>();
                var materials = meshRenderer.sharedMaterials;
                var bark = materials[0];
                var leaves = materials[1];

                var barkData = new MaterialData(bark, MaterialReplacer.ShaderType.VegetationShader);
                barkData.m_floatProperties["_Height"] = 35f;
                barkData.m_floatProperties["_SwaySpeed"] = 10f;
                barkData.m_floatProperties["_SwayDistance"] = 25f;
                barkData.m_floatProperties["_RippleSpeed"] = 100f;
                barkData.m_floatProperties["_RippleDistance"] = 0f;
                barkData.m_floatProperties["_RippleDeadzoneMin"] = 0.47f;
                barkData.m_floatProperties["_RippleDeadzoneMax"] = 2.65f;
                barkData.m_floatProperties["_AddSnow"] = 1f;
                barkData.m_floatProperties["_AddRain"] = 1f;
                var leavesData = new MaterialData(leaves, MaterialReplacer.ShaderType.VegetationShader);
                leavesData.m_floatProperties["_Height"] = 35f;
                leavesData.m_floatProperties["_SwaySpeed"] = 10f;
                leavesData.m_floatProperties["_SwayDistance"] = 25f;
                leavesData.m_floatProperties["_RippleSpeed"] = 150f;
                leavesData.m_floatProperties["_RippleDistance"] = 2f;
                leavesData.m_floatProperties["_RippleDeadzoneMin"] = 2f;
                leavesData.m_floatProperties["_RippleDeadzoneMax"] = 3f;
                leavesData.m_floatProperties["_AddSnow"] = 1f;
                leavesData.m_floatProperties["_AddRain"] = 1f;
                treeMatRegistered = true;
            }
        }

        SetupLastTree();
        
    }

    private static void SetupLastTree()
    {
        var build = new BuildPiece("ravenwood_rome", lastTree);
        var piece = build.Prefab.GetComponent<Piece>();
        var wnt = build.Prefab.GetComponent<WearNTear>();
        piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
        wnt.m_hitEffect = new EffectListRef("vfx_beech_cut", "sfx_tree_hit");
        wnt.m_destroyedEffect = new EffectListRef("vfx_beech_small1_destroy", "sfx_tree_fall");
        build.Name.English("Roman Tree");
        build.Category.Set("Rome");
        build.Usage.Set(Piece.UsageTagFlags.Decor);
        build.RequiredItems.Add("Wood", 1, true);
        build.Crafting.Set(CraftingTable.Workbench);
        build.Snapshot();
        
        var meshRenderer = build.Prefab.GetComponentInChildren<MeshRenderer>();
        var materials = meshRenderer.sharedMaterials;
        var leaves = materials[1];
        
        var leavesData = new MaterialData(leaves, MaterialReplacer.ShaderType.VegetationShader);
        leavesData.m_floatProperties["_Height"] = 35f;
        leavesData.m_floatProperties["_SwaySpeed"] = 10f;
        leavesData.m_floatProperties["_SwayDistance"] = 25f;
        leavesData.m_floatProperties["_RippleSpeed"] = 150f;
        leavesData.m_floatProperties["_RippleDistance"] = 2f;
        leavesData.m_floatProperties["_RippleDeadzoneMin"] = 2f;
        leavesData.m_floatProperties["_RippleDeadzoneMax"] = 3f;
        leavesData.m_floatProperties["_AddSnow"] = 1f;
        leavesData.m_floatProperties["_AddRain"] = 1f;
    }
}