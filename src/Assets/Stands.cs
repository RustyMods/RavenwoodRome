using System.Collections.Generic;
using PieceManager;

namespace RavenwoodRome;

public static partial class Assets
{
    private static Dictionary<string, string> stands = new()
    {
        ["piece_market_stand_1"] = "Market Stand",
        ["piece_market_stand_2"] = "Market Stand",
        ["piece_market_stand_3"] = "Market Stand",
        ["piece_market_stand_4"] = "Market Stand",
        ["piece_rome_cloth_stand"] ="Cloth Stand",
        ["piece_rome_fruit_stand"] ="Fruit Stand",
    };

    public static void LoadStands()
    {
        foreach (var kvp in stands)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_destroyedEffect = new EffectListRef("sfx_wood_destroyed", "vfx_SawDust");
            build.Name.English(name);
            build.Category.Set("Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Wood", 1, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }
    }
}