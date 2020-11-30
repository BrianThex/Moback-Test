using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.MobackTest.Base.Interactable.Paint
{
    public class Paintable : MonoBehaviour
    {
        public Texture2D brushCursor;
        public GameObject brush;
        public Material brushMaterial;
        public float brushSize = 0.0025f;

        public bool facingClass;

        void Update()
        {
            if (Player.StateManager.instance.PlayerState == Player.StateManager.State.DrawBoard)
            {
                Cursor.visible = true;

                if (Input.GetMouseButton(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.tag == "WhiteBoard")
                        {
                            GameObject go = Instantiate(brush, hit.point + Vector3.forward * 0.1f, Quaternion.Euler(0, 0, -90), transform);
                            go.transform.localScale = Vector3.one * brushSize;

                            GameObject go2 = Instantiate(brush, hit.point + Vector3.back, Quaternion.Euler(0, 180, -90), transform);
                            go2.GetComponent<Material>().color = Invert(brushMaterial.color);
                        }
                    }
                }
            }
        }
        public static Color Invert(Color rgbColor)
        {
            float h, s, v;
            Color.RGBToHSV(rgbColor, out h, out s, out v);
            return Color.HSVToRGB((h + 0.5f) % 1, s, v);
        }
    }
}

