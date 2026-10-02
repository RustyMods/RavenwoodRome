using System.Collections.Generic;
using HarmonyLib;
using PieceManager;
using UnityEngine;

namespace RavenwoodRome;

public static partial class Assets
{
    private static Dictionary<string, string> candles = new()
    {
        ["piece_rome_candle_1"] = "Roman Candle",
        ["piece_rome_candle_2"] = "Roman Candle",
        ["piece_rome_candle_3"] = "Roman Candle",
        ["piece_rome_candle_4"] = "Roman Candle",
        ["piece_rome_candle_5"] = "Roman Candle",
        ["piece_rome_candle_6"] = "Roman Candle",
    };
    public static void LoadCandles()
    {
        foreach (var kvp in candles)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_destroyedEffect = new EffectListRef("sfx_build_hammer_default", "fx_candle_off");
            build.Name.English(name);
            build.Category.Set("Ravenwood Rome");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("Honey", 10, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();

            build.Prefab.AddComponent<RomanCandle>();
            
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }
    }

    public class RomanCandle : MonoBehaviour, Interactable
    {
        public ZNetView m_nview;
        public GameObject m_fire;

        public void Awake()
        {
            m_nview = GetComponent<ZNetView>();
            if (!m_nview || m_nview.GetZDO() == null) return;
            m_nview.Register(nameof(RPC_UpdateState), RPC_UpdateState);
        }

        public void RPC_UpdateState(long sender)
        {
            var state = m_nview.GetZDO().GetBool(ZDOVars.s_state);
            m_fire.SetActive(state);
        }
        public void Start()
        {
            if (ZNetScene.instance.GetPrefab("Candle_resin") is { } candle_resin)
            {
                var high = candle_resin.transform.Find("high").gameObject;
                var fire = transform.Find("fire");
                var fx = Instantiate(high, fire.transform);
                fx.transform.localPosition = new Vector3(0f, -0.057f, 0f);
                fire.gameObject.SetActive(m_nview.GetZDO().GetBool(ZDOVars.s_state));
                m_fire = fire.gameObject;
            }
        }

        public bool Interact(Humanoid user, bool hold, bool alt)
        {
            var state = m_nview.GetZDO().GetBool(ZDOVars.s_state);
            m_nview.GetZDO().Set(ZDOVars.s_state, !state);
            m_nview.InvokeRPC(ZNetView.Everybody, nameof(RPC_UpdateState));
            return true;
        }

        public bool UseItem(Humanoid user, ItemDrop.ItemData item) => false;
    }
}