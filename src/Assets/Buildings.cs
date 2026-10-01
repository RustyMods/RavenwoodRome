using System.Collections.Generic;
using PieceManager;

namespace RavenwoodRome;

public static partial class Assets
{
    private static readonly Dictionary<string, string> buildings = new()
    {
        ["piece_rome_amphitheatre"] = "Amphitheatre",
        ["piece_rome_arch_build"] = "Triumphant Arch",
        ["piece_rome_large_temple"] = "Large Temple",
        ["piece_rome_senate"] = "Senate",
        ["piece_rome_small_temple"] = "Small Temple",
    };
    
    public static void LoadBuildings()
    {
        for (int i = 1; i < 21; ++i)
        {
            var id = "piece_rome_house_" + i;
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_stone");
            wnt.m_hitEffect = new EffectListRef("sfx_rock_hit", "vfx_HitSparks");
            wnt.m_destroyedEffect = new EffectListRef("sfx_rock_destroyed", "vfx_RockDestroyed_large");
            build.Name.English("Roman House");
            build.Category.Set("Rome");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Wood", 1, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }

        foreach (var kvp in buildings)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_stone");
            wnt.m_hitEffect = new EffectListRef("sfx_rock_hit", "vfx_HitSparks");
            wnt.m_destroyedEffect = new EffectListRef("sfx_rock_destroyed", "vfx_RockDestroyed_large");
            build.Name.English(name);
            build.Category.Set("Rome");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("Wood", 1, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }
    }
}