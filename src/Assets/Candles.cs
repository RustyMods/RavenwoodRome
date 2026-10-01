using System.Collections.Generic;
using HarmonyLib;
using PieceManager;
using UnityEngine;

namespace RavenwoodRome;

public static partial class Assets
{
    public static void LoadCandles()
    {
        for (int i = 1; i < 7; ++i)
        {
            var id = "piece_rome_candle_" + i;
            var name = "Roman Candle";
            
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_destroyedEffect = new EffectListRef("sfx_build_hammer_default", "fx_candle_off");
            build.Name.English(name);
            build.Category.Set("Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Wood", 1, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();

            build.Prefab.AddComponent<RomanCandle>();
            
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }
    }

    public class RomanCandle : MonoBehaviour
    {
        public void Start()
        {
            if (ZNetScene.instance.GetPrefab("Candle_resin") is { } candle_resin)
            {
                var high = candle_resin.transform.Find("high").gameObject;
                var fire = transform.Find("fire");
                var fx = Instantiate(high, fire.transform);
                fx.transform.localPosition = new Vector3(0f, -0.057f, 0f);
                fire.gameObject.SetActive(true);
            }
        }
    }
}