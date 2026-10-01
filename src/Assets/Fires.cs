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
            build.Category.Set("Ravenwood Rome");
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

    public class RomanFire : MonoBehaviour
    {
        public void Start()
        {
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
            fire.SetActive(true);
        }
    }
}