using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;

namespace CalTestHelpers
{
    public static class FightInformationPrintManager
    {
        public static bool SaveFightInformation()
        {
            try
            {
                string path = string.Concat(new object[]
                {
                    Main.SavePath,
                    Path.DirectorySeparatorChar,
                    "Fight Information",
                    Path.DirectorySeparatorChar
                });
                Directory.CreateDirectory(path);

                string fileName = $"{path}fightinfo-({DateTime.Now.Day}-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}).txt";
                string fileContents = string.Empty;

                // Armor.
                fileContents += "Armor: ";
                for (int i = 0; i < 3; i++)
                {
                    if (Main.LocalPlayer.armor[i].IsAir)
                        fileContents += "[Empty]";
                    else
                        fileContents += Main.LocalPlayer.armor[i].Name;

                    if (i < 2)
                        fileContents += ", ";
                }
                fileContents += "\n";

                // Accessories and reforge setups.
                fileContents += "Accessories: ";
                Dictionary<int, int> reforgeInformation = new Dictionary<int, int>();
                for (int i = 3; i < Main.LocalPlayer.extraAccessorySlots + 8; i++)
                {
                    if (Main.LocalPlayer.armor[i].IsAir)
                        fileContents += "[Empty]";
                    else
                    {
                        fileContents += Main.LocalPlayer.armor[i].Name;

                        int prefix = Main.LocalPlayer.armor[i].prefix;
                        if (prefix >= 0 && prefix < Lang.prefix.Length)
                        {
                            if (!reforgeInformation.ContainsKey(prefix))
                                reforgeInformation[prefix] = 0;
                            reforgeInformation[prefix]++;
                        }
                    }

                    if (i < Main.LocalPlayer.extraAccessorySlots + 7)
                        fileContents += ", ";
                }
                fileContents += "\n";

                // Reforges.
                fileContents += "Reforge Counts: ";
                foreach (int prefix in reforgeInformation.Keys)
                    fileContents += $"{Lang.prefix[prefix].Value}: {reforgeInformation[prefix]}, ";
                fileContents = string.Concat(fileContents.Take(fileContents.Length - 2));
                fileContents += "\n";

                // Buffs.
                fileContents += "Buffs: ";
                for (int i = 0; i < Player.MaxBuffs; i++)
                {
                    int buffID = Main.LocalPlayer.buffType[i];
                    if (Main.debuff[buffID] || Main.pvpBuff[buffID] || Main.projPet[buffID] || Main.lightPet[buffID] || Main.vanityPet[buffID])
                        continue;

                    if (buffID <= 0)
                        continue;

                    fileContents += Lang.GetBuffName(buffID);
                    fileContents += ", ";
                }
                fileContents = string.Concat(fileContents.Take(fileContents.Length - 2));
                fileContents += "\n";

                // Minion Count.
                fileContents += $"Minion Slots: {Main.LocalPlayer.maxMinions}\n";

                // Fight information.
                double averageDPS = CalTestHelpersWorld.BossKillDPS.Count == 0 ? 0f : CalTestHelpersWorld.BossKillDPS.Average();
                double maxDPS = CalTestHelpersWorld.BossKillDPS.Count == 0 ? 0f : CalTestHelpersWorld.BossKillDPS.Max();
                string timeString = TimeSpan.FromSeconds(CalTestHelpersWorld.BossKillTimeFrames / 60f).ToString(@"hh\:mm\:ss");
                fileContents += $"Time Elapsed: {timeString}\n" +
                                $"Average DPS: {averageDPS}\n" +
                                $"Maximum DPS: {maxDPS}\n" +
                                $"DPS Instability Factor: {(maxDPS + 1f) / (averageDPS + 1f)}\n";

                // Empty conclusion.
                fileContents += "Conclusion: ";

                File.WriteAllText(fileName, fileContents);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}