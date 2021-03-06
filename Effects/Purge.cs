﻿using ChampionsOfForest.Player;
using System.Linq;
using TheForest.Items;
using TheForest.Utils;
using UnityEngine;

namespace ChampionsOfForest.Effects
{
    public class Purge : MonoBehaviour
    {
        private float speed = -30;
        float radius = 5;
        private static Material mat;
        public static void Cast(Vector3 pos, float radius, bool heal,bool damageBonus)
        {
            if (mat == null)
            {
                mat = new Material(Shader.Find("Particles/Additive"));
                mat.SetColor("_TintColor", new Color(1, 1, 0.0f, 0.5f));
                mat.mainTexture = Res.ResourceLoader.GetTexture(126);
            }


            GameObject o = GameObject.CreatePrimitive(PrimitiveType.Quad);
            o.transform.position = pos + Vector3.up * 10;
            o.transform.rotation = Quaternion.Euler(90, 0, 0);
            o.RemoveComponent(typeof(Collider));
            o.GetComponent<Renderer>().material = mat;
            Purge p1 = o.AddComponent<Purge>();
            p1.radius = radius;

            GameObject p2 = Instantiate(o);
            Purge pu2 = p2.GetComponent<Purge>();
            pu2.speed *= 30;
            pu2.radius = radius;
            p2.transform.position -= Vector3.up * 20;

            if ((LocalPlayer.Transform.position - pos).sqrMagnitude < radius * radius)
            {
                PurgeLocalPlayer(heal, damageBonus);
            }

        }
        private static void PurgeLocalPlayer(bool heal, bool bonusDamage)
        {
            int[] keys = BuffDB.activeBuffs.Keys.ToArray();
            int a = heal?1:0;
            for (int i = 0; i < keys.Length; i++)
            {
                if (BuffDB.activeBuffs[keys[i]].isNegative)
                {
                    BuffDB.activeBuffs[keys[i]].ForceEndBuff(keys[i]);
                }
            }
            ModdedPlayer.instance.StunDuration = 0;
            ModdedPlayer.instance.RootDuration= 0;

                if (heal)
                {
                    float healAmount = (ModdedPlayer.instance.MaxHealth - LocalPlayer.Stats.Health);
            if (bonusDamage)
            {
                    float buffAmount =1+( healAmount / ModdedPlayer.instance.MaxHealth) * 3;
                    BuffDB.AddBuff(9, 90, buffAmount,6.5f);
            }
                healAmount *= 0.4f * ModdedPlayer.instance.HealingMultipier;
                    LocalPlayer.Stats.Health += healAmount;
                    LocalPlayer.Stats.HealthTarget += healAmount;
                    LocalPlayer.Stats.Energy += (ModdedPlayer.instance.MaxEnergy - LocalPlayer.Stats.Energy) * 0.5f;
                }


        }

        private void Start()
        {
            Destroy(gameObject, 2);
            transform.localScale = Vector3.one * radius / 2;
        }

        private void Update()
        {
            transform.localScale += Vector3.one * Time.deltaTime * radius / 2;
            transform.position += Vector3.up * Time.deltaTime * speed;
            transform.Rotate(Vector3.up * 80 * speed * Time.deltaTime, Space.World);
        }

    }
   
}
