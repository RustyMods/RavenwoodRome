using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace RavenwoodRome;

public class Highlightable : MonoBehaviour
{
    public Color color = new Color(0.6f, 0.8f, 1f);
    public void Highlight()
    {
        MaterialMan.instance.SetValue(gameObject, ShaderProps._EmissionColor, color * 0.4f);
        MaterialMan.instance.SetValue(gameObject, ShaderProps._Color, color);
        CancelInvoke(nameof(ResetHighlight));
        Invoke(nameof(ResetHighlight), 0.2f);
    }

    public void ResetHighlight()
    {
        MaterialMan.instance.ResetValue(gameObject, ShaderProps._Color);
        MaterialMan.instance.ResetValue(gameObject, ShaderProps._EmissionColor);
    }

    [HarmonyPatch(typeof(Player), nameof(Player.UpdateWearNTearHover))]
    private static class Player_UpdateWearNTearHover
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var method = AccessTools.Method(typeof(Player_UpdateWearNTearHover), nameof(GetWearNTearOrHighlight));

            return new CodeMatcher(instructions)
                .MatchStartForward(new CodeMatch(ins =>
                    ins.opcode == OpCodes.Callvirt &&
                    ins.operand is MethodInfo mi &&
                    mi.Name == nameof(GetComponent) &&
                    mi.IsGenericMethod &&
                    mi.GetGenericArguments()[0] == typeof(WearNTear)))
                .ThrowIfInvalid("Could not find GetComponent<WearNTear>() in UpdateWearNTearHover")
                .SetInstruction(new CodeInstruction(OpCodes.Call, method))
                .InstructionEnumeration();
        }

        private static WearNTear GetWearNTearOrHighlight(Piece piece)
        {
            var wnt = piece.GetComponent<WearNTear>();
            if (wnt == null && piece.TryGetComponent(out Highlightable highlightable))
            {
                highlightable.Highlight();
            }
            return wnt;
        }
    }
}