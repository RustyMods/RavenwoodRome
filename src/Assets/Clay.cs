using System.Collections.Generic;
using PieceManager;
using UnityEngine;

namespace RavenwoodRome;

public static partial class Assets
{
    private static Dictionary<string, string> clayPots = new()
    {
        ["piece_amphora_1"] = "Amphora 1",
        ["piece_amphora_2"] = "Amphora 2",    
        ["piece_amphora_3"] = "Amphora 3",
        ["piece_amphora_4"] = "Amphora 4",
        ["piece_rome_pottery_1"] = "Pottery 1",
        ["piece_rome_pottery_2"] = "Pottery 2",
        ["piece_rome_pottery_3"] = "Pottery 3",
        ["piece_rome_pottery_4"] = "Pottery 4",
        ["piece_rome_pottery_5"] = "Pottery 5",
        ["piece_rome_pottery_6"] = "Pottery 6",
        ["piece_rome_pottery_7"] = "Pottery 7",
        ["piece_rome_pottery_8"] = "Pottery 8",
        ["piece_rome_pottery_9"] = "Pottery 9",
        ["piece_rome_pottery_10"] = "Pottery 10",
        ["piece_rome_pottery_11"] = "Pottery 11",
        ["piece_rome_pottery_12"] = "Pottery 12",
        ["piece_rome_pottery_13"] = "Pottery 13",
        ["piece_rome_vase_4"] = "Roman Vase 4",
        ["piece_rome_vase_5"] = "Roman Vase 5",
        ["piece_rome_vase_6"] = "Roman Vase 6",
    };
    public static void LoadClayPottery()
    {
        foreach (var kvp in clayPots)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_destroyedEffect = new EffectListRef("sfx_clay_pot_break");
            build.Name.English(name);
            build.Category.Set("Ravenwood");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("FineWood", 10, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();

            if (build.Prefab.TryGetComponent(out Container container))
            {
                container.m_openEffects = new EffectListRef("sfx_chest_open");
                container.m_closeEffects = new EffectListRef("sfx_chest_close");
                container.m_name = "$" + build.Prefab.name.Replace(" ", "_");
            }
            

            var meshRenderer = build.Prefab.GetComponentInChildren<MeshRenderer>();
            foreach (var material in meshRenderer.sharedMaterials)
            {
                var matData = new MaterialData(material, MaterialReplacer.ShaderType.RockShader);
                matData.floatProps["_MossAlpha"] = 0f;
            }
        }
    }    
}