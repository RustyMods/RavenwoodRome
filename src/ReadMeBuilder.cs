using System.IO;
using System.Linq;
using System.Text;
using BepInEx;
using HarmonyLib;
using PieceManager;

namespace RavenwoodRome;

public static class ReadMeBuilder
{
    private static bool buildReadme = false;
    private static bool exportSprites = false;

    static ReadMeBuilder()
    {
        RavenwoodRomePlugin.instance._harmony.Patch(
            AccessTools.DeclaredMethod(typeof(ZNetScene), nameof(ZNetScene.Awake)),
            postfix: new HarmonyMethod(AccessTools.DeclaredMethod(typeof(ReadMeBuilder), nameof(Build))));
    }

    public static void Init(bool exportIcons = true)
    {
        buildReadme = true;
        exportSprites = exportIcons;
    }
    public static void Build()
    {
        if (!buildReadme) return;
            
        var path = Path.Combine(Paths.ConfigPath, "RavenwoodRome");
        Directory.CreateDirectory(path);

        var sb = new StringBuilder();
        sb.AppendLine("# Ravenwood Rome");
        sb.AppendLine();

        foreach (var build in BuildPiece.registeredPieces)
        {
            var component = build.Prefab.GetComponent<Piece>();
            var internalId = component.name;
            var unLocalizedName = component.m_name;
            var unLocalizedDescription = component.m_description;
            var iconId = component.name + ".png";
            var iconUrl =
                "https://github.com/RustyMods/RavenwoodRome/blob/master/Icons/" +
                iconId;
            var resources = build.RequiredItems.Requirements
                .Select(r => $"<li>{r.itemName} x {r.amount}</li>");
            
            if (exportSprites)
            {
                IconExport.ExportSprite(component.m_icon, path, component.name);
            }

            sb.AppendLine("<table width=\"100%\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine(
                $"    <td rowspan=\"4\" width=\"128\" align=\"center\" valign=\"middle\"><img src=\"{iconUrl}\" width=\"128\" height=\"128\" alt=\"{internalId}\"></td>");
            sb.AppendLine($"    <td><b>Internal ID:</b> <code>{internalId}</code></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine($"  <tr><td><b>Name:</b> {unLocalizedName}</td></tr>");
            sb.AppendLine($"  <tr><td><b>Description:</b> {unLocalizedDescription}</td></tr>");
            sb.AppendLine("  <tr><td><b>Resources:</b>");
            sb.AppendLine("    <ul>");
            foreach (var resource in resources)
            {
                sb.AppendLine($"      {resource}");
            }

            sb.AppendLine("    </ul>");
            sb.AppendLine("  </td></tr>");
            sb.AppendLine("</table>");
            sb.AppendLine();
        }

        File.WriteAllText(Path.Combine(path, "README.md"), sb.ToString());
    }
}