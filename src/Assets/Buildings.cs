using System.Collections.Generic;
using PieceManager;

namespace RavenwoodRome;

public static partial class Assets
{
    private static readonly Dictionary<string, string> buildings = new()
    {
        // ["piece_rome_amphitheatre"] = "Amphitheatre",
        // ["piece_rome_arch_build"] = "Triumphant Arch",
        // ["piece_rome_large_temple"] = "Large Temple",
        // ["piece_rome_senate"] = "Senate",
        // ["piece_rome_small_temple"] = "Small Temple",
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
    
    private static void LoadSenate()
    {
        var build = new BuildPiece("ravenwood_rome", "piece_rome_senate");
        var piece = build.Prefab.GetComponent<Piece>();
        var wnt = build.Prefab.GetComponent<WearNTear>();
        piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_stone");
        wnt.m_hitEffect = new EffectListRef("sfx_rock_hit", "vfx_HitSparks");
        wnt.m_destroyedEffect = new EffectListRef("sfx_rock_destroyed", "vfx_RockDestroyed_large");
        build.Name.English("Senate");
        build.Category.Set("Ravenwood Rome");
        build.Usage.Set(Piece.UsageTagFlags.Architecture);
        build.RequiredItems.Add("Coins", 1500, true);
        build.RequiredItems.Add("Stone", 500, true);
        build.RequiredItems.Add("FineWood", 500, true);
        build.RequiredItems.Add("BronzeNails", 250, true);
        build.Crafting.Set(CraftingTable.Workbench);
        build.Snapshot();
    }

    private static void LoadLargeTemple()
    {
        var build = new BuildPiece("ravenwood_rome", "piece_rome_large_temple");
        var piece = build.Prefab.GetComponent<Piece>();
        var wnt = build.Prefab.GetComponent<WearNTear>();
        piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_stone");
        wnt.m_hitEffect = new EffectListRef("sfx_rock_hit", "vfx_HitSparks");
        wnt.m_destroyedEffect = new EffectListRef("sfx_rock_destroyed", "vfx_RockDestroyed_large");
        build.Name.English("Large Temple");
        build.Category.Set("Ravenwood Rome");
        build.Usage.Set(Piece.UsageTagFlags.Architecture);
        build.RequiredItems.Add("Coins", 1000, true);
        build.RequiredItems.Add("Stone", 400, true);
        build.RequiredItems.Add("FineWood", 400, true);
        build.RequiredItems.Add("BronzeNails", 200, true);
        build.Crafting.Set(CraftingTable.Workbench);
        build.Snapshot();
    }
    
    private static void LoadSmallTemple()
    {
        var build = new BuildPiece("ravenwood_rome", "piece_rome_small_temple");
        var piece = build.Prefab.GetComponent<Piece>();
        var wnt = build.Prefab.GetComponent<WearNTear>();
        piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_stone");
        wnt.m_hitEffect = new EffectListRef("sfx_rock_hit", "vfx_HitSparks");
        wnt.m_destroyedEffect = new EffectListRef("sfx_rock_destroyed", "vfx_RockDestroyed_large");
        build.Name.English("Small Temple");
        build.Category.Set("Ravenwood Rome");
        build.Usage.Set(Piece.UsageTagFlags.Architecture);
        build.RequiredItems.Add("Coins", 500, true);
        build.RequiredItems.Add("Stone", 250, true);
        build.RequiredItems.Add("FineWood", 250, true);
        build.RequiredItems.Add("BronzeNails", 125, true);
        build.Crafting.Set(CraftingTable.Workbench);
        build.Snapshot();
    }

    private static void LoadAmphitheatre()
    {
        var build = new BuildPiece("ravenwood_rome", "piece_rome_amphitheatre");
        var piece = build.Prefab.GetComponent<Piece>();
        var wnt = build.Prefab.GetComponent<WearNTear>();
        piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_stone");
        wnt.m_hitEffect = new EffectListRef("sfx_rock_hit", "vfx_HitSparks");
        wnt.m_destroyedEffect = new EffectListRef("sfx_rock_destroyed", "vfx_RockDestroyed_large");
        build.Name.English("Amphitheatre");
        build.Category.Set("Ravenwood Rome");
        build.Usage.Set(Piece.UsageTagFlags.Architecture);
        build.RequiredItems.Add("Coins", 4000, true);
        build.RequiredItems.Add("Stone", 1000, true);
        build.RequiredItems.Add("BronzeNails", 500, true);
        build.Crafting.Set(CraftingTable.Workbench);
        build.Snapshot();
    }
    
    private static void LoadTriumphantArch()
    {
        var build = new BuildPiece("ravenwood_rome", "piece_rome_arch_build");
        var piece = build.Prefab.GetComponent<Piece>();
        var wnt = build.Prefab.GetComponent<WearNTear>();
        piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_stone");
        wnt.m_hitEffect = new EffectListRef("sfx_rock_hit", "vfx_HitSparks");
        wnt.m_destroyedEffect = new EffectListRef("sfx_rock_destroyed", "vfx_RockDestroyed_large");
        build.Name.English("Triumphant Arch");
        build.Category.Set("Ravenwood Rome");
        build.Usage.Set(Piece.UsageTagFlags.Architecture);
        build.RequiredItems.Add("FineWood", 200, true);
        build.RequiredItems.Add("Stone", 200, true);
        build.RequiredItems.Add("RoundLog", 100, true);
        build.RequiredItems.Add("BronzeNails", 50, true);
        build.Crafting.Set(CraftingTable.Workbench);
        build.Snapshot();
    }
    
    public static void LoadBuildings()
    {
        LoadAmphitheatre();
        LoadLargeTemple();
        LoadSmallTemple();
        LoadSenate();
        LoadTriumphantArch();
        
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
            build.Category.Set("Ravenwood Rome");
            build.Usage.Set(Piece.UsageTagFlags.Architecture);
            build.RequiredItems.Add("FineWood", 200, true);
            build.RequiredItems.Add("Stone", 200, true);
            build.RequiredItems.Add("RoundLog", 40, true);
            build.RequiredItems.Add("BronzeNails", 20, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }
    }
}