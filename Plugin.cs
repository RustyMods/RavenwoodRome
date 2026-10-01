using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using ServerSync;

namespace RavenwoodRome;

[BepInPlugin(ModGUID, ModName, ModVersion)]
public class RavenwoodRomePlugin : BaseUnityPlugin
{
    internal const string ModName = "RavenwoodRome";
    internal const string ModVersion = "1.0.2";
    internal const string Author = "RustyMods";
    private const string ModGUID = Author + "." + ModName;
    private static readonly string ConfigFileName = ModGUID + ".cfg";
    private static readonly string ConfigFileFullPath = Paths.ConfigPath + Path.DirectorySeparatorChar + ConfigFileName;
    internal static string ConnectionError = "";
    private readonly Harmony _harmony = new(ModGUID);

    public static readonly ManualLogSource RavenwoodRomeLogger = BepInEx.Logging.Logger.CreateLogSource(ModName);

    private static readonly ConfigSync ConfigSync = new(ModGUID)
        { DisplayName = ModName, CurrentVersion = ModVersion, MinimumRequiredVersion = ModVersion };

    public enum Toggle
    {
        On = 1,
        Off = 0
    }

    private static ConfigEntry<Toggle> _serverConfigLocked = null!;

    public void Awake()
    {
        var saveOnSet = Config.SaveOnConfigSet;
        Config.SaveOnConfigSet = false;

        _serverConfigLocked = config("1 - General", "Lock Configuration", Toggle.On,
            "If on, the configuration is locked and can be changed by server admins only.");
        _ = ConfigSync.AddLockingConfigEntry(_serverConfigLocked);

        ReadMeBuilder.buildReadme = true;
        
        Assets.LoadBuildings();
        Assets.LoadSculptures();
        Assets.LoadBanners();
        Assets.LoadBaskets();
        Assets.LoadCandles();
        Assets.LoadChairs();
        Assets.LoadContainers();
        Assets.LoadDoors();
        Assets.LoadFireProps();
        Assets.LoadMetalProps();
        Assets.LoadProps();
        Assets.LoadArchitectures();
        Assets.LoadStands();
        Assets.LoadClayPottery();
        var assembly = Assembly.GetExecutingAssembly();
        _harmony.PatchAll(assembly);
        SetupWatcher();

        if (saveOnSet)
        {
            Config.SaveOnConfigSet = saveOnSet;
            Config.Save();
        }
    }


    private void OnDestroy()
    {
        Config.Save();
    }

    private void SetupWatcher()
    {
        FileSystemWatcher watcher = new(Paths.ConfigPath, ConfigFileName);
        watcher.Changed += ReadConfigValues;
        watcher.Created += ReadConfigValues;
        watcher.Renamed += ReadConfigValues;
        watcher.IncludeSubdirectories = true;
        watcher.SynchronizingObject = ThreadingHelper.SynchronizingObject;
        watcher.EnableRaisingEvents = true;
    }

    private void ReadConfigValues(object sender, FileSystemEventArgs e)
    {
        if (!File.Exists(ConfigFileFullPath)) return;
        try
        {
            RavenwoodRomeLogger.LogDebug("ReadConfigValues called");
            Config.Reload();
        }
        catch
        {
            RavenwoodRomeLogger.LogError($"There was an issue loading your {ConfigFileName}");
            RavenwoodRomeLogger.LogError("Please check your config entries for spelling and format!");
        }
    }


    private ConfigEntry<T> config<T>(string group, string name, T value, ConfigDescription description,
        bool synchronizedSetting = true)
    {
        ConfigDescription extendedDescription =
            new(
                description.Description +
                (synchronizedSetting ? " [Synced with Server]" : " [Not Synced with Server]"),
                description.AcceptableValues, description.Tags);
        var configEntry = Config.Bind(group, name, value, extendedDescription);
        //var configEntry = Config.Bind(group, name, value, description);

        var syncedConfigEntry = ConfigSync.AddConfigEntry(configEntry);
        syncedConfigEntry.SynchronizedConfig = synchronizedSetting;

        return configEntry;
    }

    private ConfigEntry<T> config<T>(string group, string name, T value, string description,
        bool synchronizedSetting = true)
    {
        return config(group, name, value, new ConfigDescription(description), synchronizedSetting);
    }
}