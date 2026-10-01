using System.Collections.Generic;
using PieceManager;

namespace RavenwoodRome;

public static partial class Assets
{
    private static Dictionary<string, string> baskets = new()
    {
        ["piece_basket_berries"] = "Berry Basket",
        ["piece_basket_empty"] = "Basket",
        ["piece_basket_fruit"] = "Fruit Basket",
        ["piece_basket_grains"] =  "Grains Basket",
    };

    public static void LoadBaskets()
    {
        foreach (var kvp in baskets)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_smallitem", "sfx_build_hammer_default");
            wnt.m_hitEffect = new EffectListRef("sfx_hit");
            wnt.m_destroyedEffect = new EffectListRef("sfx_wood_hit");
            build.Name.English(name);
            build.Category.Set("Ravenwood Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Wood", 1, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }
    }
}