using CalamityMod;
using CalamityMod.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CalTestHelpers.UI
{
    public abstract class BossDeathUIRenderer : GrandUIRenderer
    {
        public enum Boss
        {
            KingSlime,
            DesertScourge,
            EyeOfCthulhu,
            Crabulon,
            EaterOfWorlds,
            BrainOfCthulhu,
            HiveMind,
            Perforators,
            QueenBee,
			Deerclops,
            Skeletron,
            SlimeGod,
            WallOfFlesh,
			QueenSlime,
            Cryogen,
            TheTwins,
            BrimstoneElemental,
            TheDestroyer,
            TheAquaticScourge,
            SkeletronPrime,
            Cloneamitas,
            Plantera,
            Leviathan,
            AstrumAureus,
            Golem,
            PlaguebringerGoliath,
			EmpressOfLight,
            DukeFishron,
            Ravager,
            LunaticCultist,
            AstrumDeus,
            MoonLord,
            ProfanedGuardians,
            Dragonfolly,
            Providence,
            CeaselessVoid,
            StormWeaver,
            Signus,
            Polterghast,
            OldDuke,
            DevourerOfGods,
            Yharon,
            Draedon,
            SupremeCalamitas,
            All
        }

        public override Vector2 TopLeftLocation => new Vector2(Main.screenWidth - 660 - 350 * ResolutionRatio, 40);
    }
}