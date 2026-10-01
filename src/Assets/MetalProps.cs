using System.Collections.Generic;
using PieceManager;
using UnityEngine;

namespace RavenwoodRome;

public static partial class Assets
{
    private static Dictionary<string, string> metalProps = new()
    {
        ["piece_rome_bronze_pot"] = "Bronze Pot",
        ["piece_rome_door_knob_lion"] = "Door Knob",
        ["piece_rome_post_1"] = "Roman Post",
        ["piece_rome_shield_1"] = "Roman Shield",
        ["piece_rome_shield_2"] = "Roman Shield",
        ["piece_rome_spear_1"] = "Roman Spear",
        ["piece_rome_sword_1"] = "Roman Sword",
        ["piece_rome_vase_1"] = "Metal Vase",
        ["piece_rome_vase_2"] = "Metal Vase",
        ["piece_rome_vase_3"] = "Metal Vase",
        ["piece_rome_weapon_stand_2"] = "Roman Weapon Stand",
        ["piece_rome_weapon_stand_3"] = "Roman Weapon Stand"
    };

    public static void LoadMetalProps()
    {
        foreach (var kvp in metalProps)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_metal");
            wnt.m_destroyedEffect = new EffectListRef("sfx_metal_blocked", "sfx_SawDust");
            build.Name.English(name);
            build.Category.Set("Ravenwood Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Wood", 10, true);
            build.RequiredItems.Add("Bronze",1,true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();
            var meshRenderer = build.Prefab.GetComponentInChildren<MeshRenderer>();
            foreach (var material in meshRenderer.sharedMaterials)
            {
                var matData = new MaterialData(material, MaterialReplacer.ShaderType.RockShader);
                matData.m_floatProperties["_MossAlpha"] = 0f;
            }        
        }
    }
}