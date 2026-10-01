using System.Collections.Generic;
using HarmonyLib;
using PieceManager;
using UnityEngine;

namespace RavenwoodRome;

public static partial class Assets
{
    private static List<GameObject> doors = [];

    public static void LoadDoors()
    {
        for (int i = 1; i < 5; ++i)
        {
            var id = "piece_rome_door_" + i;
            var name = "Roman Door";
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
            doors.Add(build.Prefab);
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.RockShader);
        }
    }

    [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake))]
    private static class Setup_Roman_Doors_SFX
    {
        private static void Postfix(ZNetScene __instance)
        {
            if (__instance.GetPrefab("darkwood_gate") is { } darkwood_gate &&
                darkwood_gate.TryGetComponent(out Door component))
            {
                for (int i = 0; i < doors.Count; ++i)
                {
                    var prefab = doors[i];
                    var door = prefab.GetComponent<Door>();
                    door.m_openEffects = component.m_openEffects;
                    door.m_closeEffects = component.m_closeEffects;
                }
            }
        }
    }
}