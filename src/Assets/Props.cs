using System.Collections.Generic;
using PieceManager;

namespace RavenwoodRome;

public static partial class Assets
{
    private static Dictionary<string, string> props = new()
    {
        ["piece_apple_green"] = "Roman Apple",
        ["piece_apple_red"] = "Roman Apple",
        ["piece_rome_book_1"] = "Roman Book",
        ["piece_rome_book_2"] = "Roman Book",
        ["piece_rome_bread_1"] = "Roman Bread",
        ["piece_rome_bread_2"] = "Roman Bread",
        ["piece_rome_cloth_folded_1"] = "Roman Cloth",
        ["piece_rome_cloth_folded_2"] = "Roman Cloth",
        ["piece_rome_cloth_folded_3"] = "Roman Cloth",
        ["piece_rome_hanging_cloth_1"] = "Roman Hanging Cloth",
        ["piece_rome_hanging_cloth_2"] = "Roman Hanging Cloth",
        ["piece_rome_hanging_cloth_3"] =  "Roman Hanging Cloth",
        ["piece_rome_hanging_fruit_1"] = "Roman Hanging Fruits",
        ["piece_rome_hanging_fruit_2"] =  "Roman Hanging Fruits",
        ["piece_rome_peach"] = "Roman Peach",
        ["piece_rome_rope_1"] = "Roman Rope",
        ["piece_rome_rope_2"] = "Roman Rope",
        ["piece_rome_rope_3"] = "Roman Rope",
        ["piece_rome_rope_4"] = "Roman Rope",
        ["piece_rome_rope_5"] = "Roman Rope",
        ["piece_rome_rope_6"] = "Roman Rope",
        ["piece_rome_scroll_1"] = "Roman Scroll",
        ["piece_rome_scroll_2"] = "Roman Scroll",
        ["piece_rome_scroll_3"] = "Roman Scroll",
        ["piece_rome_weapon_stand_1"] = "Roman Weapon Stand",
        ["piece_rome_window_cover_1"] = "Roman Window Cover",
        ["piece_rome_window_cover_2"] = "Roman Window Cover",

    };

    private static Dictionary<string, string> shelves = new()
    {
        ["piece_rome_shelf_1"] = "Roman Shelf",
        ["piece_rome_shelf_2"] = "Roman Shelf",
        ["piece_rome_shelf_3"] = "Roman Shelf",
        ["piece_rome_shelf_4"] = "Roman Shelf",
        ["piece_rome_shelf_5"] = "Roman Shelf",
    };
    

    private static Dictionary<string, string> tables = new()
    {
        ["piece_rome_desk"] = "Roman Desk",
        ["piece_rome_table_1"] =  "Roman Table",
        ["piece_rome_table_2"] = "Roman Table",
        ["piece_rome_table_3"] = "Roman Table",
        ["piece_rome_table_4"] = "Roman Table",
        ["piece_rome_table_5"] = "Roman Table",
        ["piece_rome_table_6"] = "Roman Table",
    };

    private static Dictionary<string, string> fences = new()
    {
        ["piece_rome_wood_fence_1"] = "Roman Fence",
        ["piece_rome_wood_fence_2"] = "Roman Fence",
    };

    private static Dictionary<string, string> beds = new()
    {
        ["piece_rome_bed_1"] = "Roman Bed",
    };

    public static void LoadProps()
    {
        foreach (var kvp in props)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_destroyedEffect = new EffectListRef("sfx_wood_destroyed", "vfx_SawDust");
            build.Name.English(name);
            build.Category.Set("Ravenwood Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("FineWood", 2, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }

        foreach (var kvp in shelves)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_destroyedEffect = new EffectListRef("sfx_wood_destroyed", "vfx_SawDust");
            build.Name.English(name);
            build.Category.Set("Ravenwood Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("FineWood", 10, true);
            build.RequiredItems.Add("BronzeNails", 2, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }

        foreach (var kvp in tables)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_destroyedEffect = new EffectListRef("sfx_wood_destroyed", "vfx_SawDust");
            build.Name.English(name);
            build.Category.Set("Ravenwood Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("FineWood", 10, true);
            build.RequiredItems.Add("BronzeNails", 2, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }
        
        foreach (var kvp in fences)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_destroyedEffect = new EffectListRef("sfx_wood_destroyed", "vfx_SawDust");
            build.Name.English(name);
            build.Category.Set("Ravenwood Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Wood", 10, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }

        foreach (var kvp in beds)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_destroyedEffect = new EffectListRef("sfx_wood_destroyed", "vfx_SawDust");
            build.Name.English(name);
            build.Category.Set("Ravenwood Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("FineWood", 10, true);
            build.RequiredItems.Add("Bronze", 2, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }
    }
}