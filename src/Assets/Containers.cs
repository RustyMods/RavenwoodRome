using System.Collections.Generic;
using PieceManager;

namespace RavenwoodRome;

public static partial class Assets
{
    private static Dictionary<string, string> containers = new()
    {
        ["piece_rome_barrel_1"] = "Roman Barrel 1",
        ["piece_rome_barrel_2"] = "Roman Barrel 2",
        ["piece_rome_small_crate_1"] = "Roman Crate 1",
        ["piece_rome_small_crate_2"] = "Roman Crate 2",
        ["piece_rome_small_crate_3"] = "Roman Crate 3",
        ["piece_rome_small_crate_4"] = "Roman Crate 4",
    };

    public static void LoadContainers()
    {
        foreach (var kvp in containers)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            var container = build.Prefab.GetComponent<Container>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_destroyedEffect = new EffectListRef("sfx_wood_destroyed", "vfx_SawDust");
            container.m_openEffects = new EffectListRef("sfx_chest_open");
            container.m_closeEffects = new EffectListRef("sfx_chest_close");
            container.m_name = "$" + build.Prefab.name.Replace(" ", "_");
            build.Name.English(name);
            build.Category.Set("Ravenwood");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("FineWood", 10, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }
    }
}