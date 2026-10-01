using System.Collections.Generic;
using PieceManager;

namespace RavenwoodRome;

public static partial class Assets
{
    private static Dictionary<string, string> chairs = new()
    {
        ["piece_rome_chair_1"] = "Roman Chair",
        ["piece_rome_chair_2"] = "Roman Chair",
    };
    public static void LoadChairs()
    {
        foreach (var kvp in chairs)
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