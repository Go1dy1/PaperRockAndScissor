using System;
using System.IO;
using UnityEditor.PackageManager;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace LevelPlay.Installer.Editor
{
    [InitializeOnLoad]
    public class LevelPlayInstaller
    {
        const string k_PackagePath = "Packages/com.unity.services.levelplay/LevelPlay/Editor/IronSource_IntegrationManager.unitypackage";
        const string k_PackageName = "com.unity.services.levelplay";

        static LevelPlayInstaller()
        {
            Events.registeredPackages += EventsOnRegisteredPackages;
        }

        static void EventsOnRegisteredPackages(PackageRegistrationEventArgs args)
        {
            var isPackageInstalled = args.added.Any(info => info.name == k_PackageName);
            var isPackageUpdated   = args.changedTo.Any(info => info.name == k_PackageName);

            if (isPackageInstalled || isPackageUpdated)
            {
                InstallPackage();
            }
        }

        static void InstallPackage()
        {
            var absolutePath = Path.GetFullPath(k_PackagePath);
            AssetDatabase.ImportPackage(absolutePath, false);
        }
    }
}
