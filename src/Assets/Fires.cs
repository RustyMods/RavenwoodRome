using System.Collections.Generic;
using PieceManager;
using UnityEngine;

namespace RavenwoodRome;

public static partial class Assets
{
    private static Dictionary<string, string> fireProps = new()
    {
        ["piece_rome_firebowl"] = "Roman Fire Bowl",
        ["piece_rome_light_post"] = "Roman Street Lamp"
    };

    public static void LoadFireProps()
    {
        foreach (var kvp in fireProps)
        {
            var id = kvp.Key;
            var name = kvp.Value;
            
            BuildPiece build = new BuildPiece("ravenwood_rome", id);
            var piece = build.Prefab.GetComponent<Piece>();
            var wnt = build.Prefab.GetComponent<WearNTear>();
            piece.m_placeEffect = new EffectListRef("vfx_Place_wood_pole", "sfx_build_hammer_default");
            wnt.m_destroyedEffect = new EffectListRef("sfx_build_hammer_default", "fx_candle_off");
            build.Name.English(name);
            build.Category.Set("Ravenwood");
            build.Usage.Set(Piece.UsageTagFlags.Decor);
            build.RequiredItems.Add("FineWood", 10, true);
            build.RequiredItems.Add("Bronze", 2, true);
            build.RequiredItems.Add("Coal", 10, true);
            build.Crafting.Set(CraftingTable.Workbench);
            build.Snapshot();

            build.Prefab.AddComponent<RomanFire>();
            
            MaterialReplacer.RegisterGameObjectForShaderSwap(build.Prefab, MaterialReplacer.ShaderType.PieceShader);
        }
    }

    public class RomanFire : MonoBehaviour, Interactable
    {
        public ZNetView m_nview;
        public GameObject m_fire;
        public void Awake()
        {
            m_nview = GetComponent<ZNetView>();
            if (!m_nview || m_nview.GetZDO() == null) return;
            m_nview.Register(nameof(RPC_UpdateState), RPC_UpdateState);
        }
        public void Start()
        {
            if (!m_nview || m_nview.GetZDO() == null) return;
            var attach = transform.Find("MOCK_piece_brazierfloor01");
            var source = ZNetScene.instance.GetPrefab("piece_brazierfloor01");
            var ashlayer = source.transform.Find("ashlayer").gameObject;
            var _enabled_high = source.transform.Find("_enabled_high").gameObject;
            var _enabled = source.transform.Find("_enabled").gameObject;
            var ash = Instantiate(ashlayer, attach);
            ash.transform.localPosition = new Vector3(0f, -0.321f, 0f);
            var coals = Instantiate(_enabled, attach);
            coals.transform.localPosition = new Vector3(0f, -0.34f, 0f);
            coals.SetActive(true);
            var fire = Instantiate(_enabled_high, attach);
            fire.transform.localPosition = new Vector3(0f, -0.34f, 0f);
            fire.SetActive(m_nview.GetZDO().GetBool(ZDOVars.s_state));
            m_fire = fire;
        }

        public void RPC_UpdateState(long sender)
        {
            var state = m_nview.GetZDO().GetBool(ZDOVars.s_state);
            m_fire.SetActive(state);
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