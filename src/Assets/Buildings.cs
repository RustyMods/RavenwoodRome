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
        ["piece_rome_house_1"] = "Roman House",
        ["piece_rome_house_2"] = "Roman House",
        ["piece_rome_house_3"] = "Roman House",
        ["piece_rome_house_4"] = "Roman House",
        ["piece_rome_house_5"] = "Roman House",
        ["piece_rome_house_6"] = "Roman House",
        ["piece_rome_house_7"] = "Roman House",
        ["piece_rome_house_8"] = "Roman House",
        ["piece_rome_house_9"] = "Roman House",
        ["piece_rome_house_10"] = "Roman House",
        ["piece_rome_house_11"] = "Roman House",
        ["piece_rome_house_12"] = "Roman House",
        ["piece_rome_house_13"] = "Roman House",
        ["piece_rome_house_14"] = "Roman House",
        ["piece_rome_house_15"] = "Roman House",
        ["piece_rome_house_16"] = "Roman House",
        ["piece_rome_house_17"] = "Roman House",
        ["piece_rome_house_18"] = "Roman House",
        ["piece_rome_house_19"] = "Roman House",
        ["piece_rome_house_20"] = "Roman House",
    };
    
    public static void LoadBuildings()
    {
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