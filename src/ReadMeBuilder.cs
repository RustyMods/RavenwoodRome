using System.IO;
using System.Linq;
using System.Text;
using BepInEx;
using HarmonyLib;
using PieceManager;

namespace RavenwoodRome;

public static class ReadMeBuilder
{
    public static bool buildReadme = false;
    
    [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake))]
    private static class ZNetScene_Awake
    {
        private static void Postfix()
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
                    "https://raw.githubusercontent.com/RustyMods/RavenwoodRome/master/BuildableNature/Icons/" +
                    iconId;
                var resources = build.RequiredItems.Requirements
                    .Select(r => $"<li>{r.itemName} x {r.amount}</li>");
                
                IconExport.ExportSprite(component.m_icon, Path.Combine(Paths.ConfigPath, "BuildableNature"), component.name);


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
}