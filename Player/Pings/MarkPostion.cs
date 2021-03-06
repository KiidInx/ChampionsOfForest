﻿using TheForest.Utils;
using UnityEngine;

namespace ChampionsOfForest
{
    public class MarkPostion : MarkObject
    {
        public MarkPostion(Vector3 pos)
        {
            Timestamp = Time.time + Duration;
            pingType = PingType.Location;
            this.position = pos;

        }


        public Vector3 position;
        const float Duration = 60;     // 1 min
        public bool Outdated()
        {
            return Timestamp < Time.time;
        }
        public void Draw()
        {
            Vector3 heading = position - LocalPlayer.Transform.position;

            if (Vector3.Dot(Cam.transform.forward, heading) > 0)
            {
                float distance = Vector3.Distance(Camera.main.transform.position, position);
                Vector3 pos = Camera.main.WorldToScreenPoint(position);
                pos.y = Screen.height - pos.y;
                float size = Mathf.Clamp(700 / distance, 16, 50);
                size *= ChampionsOfForest.MainMenu.Instance.rr;

                Rect r = new Rect(0, 0, 3.35f * size, size)
                {
                    center = pos
                };

                GUI.Label(r, distance.ToString("N1")+ 'm', new GUIStyle(GUI.skin.label) { fontSize = ((int)size), font = MainMenu.Instance.MainFont, alignment = TextAnchor.UpperCenter, wordWrap = false, clipping = TextClipping.Overflow });
                r.y += size+5;
                GUI.DrawTexture(r, Res.ResourceLoader.GetTexture(173));

            }
        }
    }
}