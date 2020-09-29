using System;
using System.Linq;
using System.Collections.Generic;
using ChampionsOfForest.Effects;

namespace ChampionsOfForest.Player
{
    public static class SpellDataBase
    {
        public static Dictionary<int, Spell> spellDictionary = new Dictionary<int, Spell>();
        public static int[] SortedSpellIDs;
        public static void Reset()
        {
            foreach (var spell in spellDictionary.Values)
            {
                spell.Cooldown = spell.BaseCooldown;
            }
        }
        public static void Initialize()
        {
            try
            {
                spellDictionary = new Dictionary<int, Spell>();
                FillSpells();
               List<int> SortedSpellIDsTemp = new List<int>(spellDictionary.Keys);
                SortedSpellIDsTemp.Sort((x, y) => spellDictionary[x].Levelrequirement.CompareTo(spellDictionary[y].Levelrequirement));
                SortedSpellIDs = SortedSpellIDsTemp.ToArray();
               // ModAPI.Log.Write("SETUP: SPELL DB");

            }
            catch (Exception ex)
            {

                ModAPI.Log.Write(ex.ToString());
            }
        }

        public static void FillSpells()
        {
            Spell bh = new Spell(1, 119, 20, 50, 120, "Schwarzes Loch", "Zaubert ein Schwarzes Loch, das jeden Gegner einsaugt und DMG/s verursacht.")
            {
                active = SpellActions.CreatePlayerBlackHole,

            };
            Spell healingDome = new Spell(2, 122, 6, 80, 70, "Heilende Aura", "Erschafft eine Sphäre aus verdunstetem Aloe Vera, das alle Spieler, innerhalb der Sphäre, heilt. Mithilfe Diverser Ausrüstung kann der Effekt ausgeweitet werden um Debuffs zu entfernen. Hängt zusammen mit dem Heilmultiplikator sowie der Zauber Verstärkung.")
            {
                active = SpellActions.CreateHealingDome,

            };
            new Spell(3, 121, 3, 25, 12, "Sprung", "Teleportiert dich über eine kurze Distanz.")
            {
                active = SpellActions.DoBlink,
                CastOnRelease = true,
                aim = SpellActions.DoBlinkAim,
                
            };
            new Spell(4, 120, 10, 100, 45, "Sonnenerruption", "Eine Lichtsäule heilt alle Spieler die sich darin befinden und erhöht die Bewegungsgeschwindigkeit um +25%, wärend es den Gegner um -25% Verlangsamt sowie Schaden zufügt.")
            {
                active = SpellActions.CastFlare,
                
            };
            new Spell(5, 118, 8, 50, "Aktiver Schild", "das Wirken dieses Zaubers, zieht permanent Energie solange er Aktiv ist, erhöht die Verteidigung und Absorbiert Schaden. Die Stärke des Schildes wächst bis zu einem gewissen Maximum. Wird der Zauber durch einen anderen abgebrochen, bleibt der Schild solange bestehen bis seine Stärke wieder auf 0 gefallen ist.")
            {
                active = SpellActions.CastSustainShieldActive,
                passive = SpellActions.CastSustainShielPassive,
                usePassiveOnUpdate = true,
            
            };
            new Spell(6, 117, 2, 10, 0.4f, "Weitblick", "Nimmt Ressourcen in einem kleinen Radius um dich herum Automatisch auf.")
            {
                active = AutoPickupItems.DoPickup,            
            };
            new Spell(7, 115, 17, 25, 2f, "Schwarze Flamme", "Entzündet deine Waffe mit einer Dunklen Flamme, die alle deine Angriffe Verstärken.")
            {
                active =BlackFlame.Toggle,            
            };
            new Spell(8,123, 12, 80, 110, "Kriegsschrei", "Stärkt dich und alle Spieler in deiner Umgebung für 2 Minuten.")
            {
                active =SpellActions.CastWarCry,            
            };
            new Spell(9, 114, 15, 100, 35, "Portal", "Wirkt ein Portal das 2 Orte miteinander Verbindet. Erlaubt es dem Spieler schnell von A nach B zu gelangen, und Ressourcen zu Transportieren.")
            {
                active =SpellActions.CastPortal,            
            };
            new Spell(10, 125, 30, 90, 20, "Verzauberter Pfeil", "Ein Großer Pfeil wird bei Wirkung dieses Zaubers in die Richtung abgeschossen in die du schaust. Verlangsamt jeden Gegner bei einem Treffer und fügt großen Schaden zu.")
            {
                active =SpellActions.CastMagicArrow,            
            };
            new Spell(11, 127, 35, 10, 10, "Multischuss", "Attacken-Modifizierer: Verzaubert deine Bögen sodass du mehrere Pfeile auf einmal Abschießen kannst. Verstärkbar durch Perks. Energie wird verbraucht nach jedem Schuss, sowie je nachdem wieviele Pfeile verschießt werden.")
            {
                active =SpellActions.ToggleMultishot,            
            };
            new Spell(12, 133, 40,50, 150, "Gold", "Du wirst für 40 Sekunden Immun gegen jegliche Stun's und die Geschwindigkeit mit der du Zuschlägst steigt um +20%.")
            {
                active =Gold.Cast,            
            };
            new Spell(13, 132, 7, 40, 15, "Säuberung", "Alle Spieler die sich im Radius dieses Zaubers befinden, werden von jeglichen Debuffs befreit. Neutralisiert Vergiftung.")
            {
                active =SpellActions.CastPurge,            
            };
            new Spell(14, 128, 20, 280, 40, "Einfrieren", "Gegner die sich im Radius befinden, werden für 12 Sekunden um -90% verlangsamt, wärend sie kontinuierlich Schaden erleiden.")
            {
                active =SpellActions.CastSnapFreeze,            
            };
            new Spell(15, 131, 25, 15, 180, "Berserker", "Für kurze Zeit, steigt dein Schaden sowie deine Angriffsgeschwindigkeit, Bewegungsgeschwindigkeit und du erhältst unbegrenzt Ausdauer, jedoch steigt der erlittene Schaden.")
            {
                active =Berserker.Cast,            
            };
            new Spell(16, 130, 42, 300, 90, "Lichtkugel", "Eine sich Langsam vorwärts bewegende Lichtkugel, richtet Schaden an Feinden an, bei Kontakt oder wenn dieser zu lange wirkt, Explodiert die Lichtkugel und fügt 320% deines Zauberschadens an.")
            {
                active =SpellActions.CastBallLightning,            
            };
            new Spell(17, 134, 3, 0, 1, "Bash", "Attack modifier\nEvery attack slows enemies for 2 seconds, and increases their damage taken by 16%")
            {
                passive =SpellActions.BashPassiveEnabled,            
            };
            new Spell(18, 136, 1, 0, 1, "Frenzy", "Attack modifier\nEvery attack enrages you, increasing damage all damage by 7.5%. Up to 5 stacks.")
            {
                passive = x=> SpellActions.Frenzy = x,            
            };
            new Spell(19, 135, 27, 40, 10, "Suchender Pfeil", "Casting spell empowers arrow, causing all arrows to head in the same direction for 30 seconds. While active, arrows deal more damage, the further target they hit, headshots deal double damage and bodyshots slow enemies by 20% for 4 seconds.")
            {
                active = SpellActions.SeekingArrow_Active,
            };
            new Spell(20, 137, 4, 0, 1, "Fokus", "Passively, when landing a headshot, next projectile will deal 100% more damage and slow the enemy by 20%. When landing a body shot, next projectile will deal only 20% more damage, but attack speed is increased.")
            {
                passive = x => SpellActions.Focus = x,
            };
            new Spell(21, 140, 8, 0, 1, "Parieren", "Passively, when parrying an enemy, deal magic damage to enemies around the target. Additionally, gain energy, heal yourself for a small amount and get stun immunity for 10 seconds after parrying.")
            {
                passive = x => SpellActions.Parry = x,
            };
            new Spell(22, 141, 50, 400, 300, "Cataclysmus", "Creates a fire tornado that ignites enemies, slows them and deals damage.")
            {
                active = ()=> SpellActions.CastCataclysm(),
            };
            new Spell(23, 165, 11, 75, 8, "Blutgetränkte Pfeile", "Sacrifice your own vitals to empower your next arrow. Drains percent of your current health and adds lost health as damage.")
            {
                active = ()=> SpellActions.CastBloodInfArr(),
            };
            //new Spell(24, 165, 1, 1, 2, "Corpse Explosion", "")
            //{
            //    active = () => SpellActions.CastCorpseExplosion(),
            //};
            //new Spell(25, 165, 1, 1, "Devour", "...")
            //{
            //    active = () =>
            //};
        }
    }
}
