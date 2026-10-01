using System.Collections.Generic;
using PieceManager;

namespace RavenwoodRome;

public static partial class Assets
{
    private static Dictionary<string, string> architectures = new()
    {
        ["piece_large_platform_preset"] = "Large Platform",
        ["piece_rome_column_1"] = "Pillar",
        ["piece_rome_column_2"] = "Pillar",
        ["piece_rome_column_3"] = "Pillar",
        ["piece_rome_column_4"] = "Pillar",
        ["piece_rome_column_5"] = "Pillar",
        ["piece_rome_column_6"] = "Pillar",
        ["piece_rome_column_7"] = "Pillar",
        ["piece_rome_column_8"] = "Pillar",
        ["piece_rome_column_9"] = "Pillar",
        ["piece_rome_marble_fence"] = "Marble Fence",
        ["piece_rome_podest_1"] = "Pedestal",
        ["piece_rome_podest_2"] = "Pedestal",
        ["piece_rome_side_walk_1"] = "Side Walk",
        ["piece_rome_side_walk_2"] = "Side Walk",
        ["piece_rome_stair_1"] = "Roman Stairs",
        ["piece_rome_stair_2"] = "Roman Stairs",
        ["piece_rome_stair_3"] = "Roman Stairs",
        ["piece_rome_stone_fence"] = "Stone Fence",
        ["piece_rome_wall_1"] = "Roman Wall",
        ["piece_rome_wall_2"] = "Roman Wall",
        ["piece_rome_wall_3"] = "Roman Wall",
        ["piece_rome_wall_4"] = "Fresco Wall",
    };

    public static void LoadArchitectures()
    {
        foreach (var kvp in architectures)
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
            build.Category.Set("Rome");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Stone", 1, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }
    }
}