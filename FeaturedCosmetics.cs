using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Ermology.FeaturedCosmetics
{
    [System.Serializable]
    public class  cosmetics
    {
        public string cosmetic;
        public GameObject prefab;
    }
    public class FeaturedCosmetics : MonoBehaviour
    {
        public string link;
        public float delay;
        public cosmetics[] cosmetics;
        [Space(15f)]
        public Transform place1;
        public Transform place2;
        public Transform place3;
        [Space(15f)]
        public string[] featured;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Load());
        }

        IEnumerator Load()
        {
            yield return new WaitForSeconds(delay);
            using (UnityWebRequest w = UnityWebRequest.Get(link))
            {
                yield return w.SendWebRequest();
                if (w.result != UnityWebRequest.Result.Success)
                {
                    yield break;
                }
                featured = w.downloadHandler.text.Split(',');
                for (int i = 0; i < featured.Length; i++)
                {
                    featured[i] = featured[i].Trim();
                }
                foreach (var c in cosmetics)
                {
                    if(c.cosmetic == featured[0])
                    {
                        GameObject cos = Instantiate(c.prefab, place1.position, place1.rotation);
                        cos.transform.parent = place1;
                    }
                    if (c.cosmetic == featured[1])
                    {
                        GameObject cos = Instantiate(c.prefab, place2.position, place2.rotation);
                        cos.transform.parent = place2;
                    }
                    if (c.cosmetic == featured[2])
                    {
                        GameObject cos = Instantiate(c.prefab, place3.position, place3.rotation);
                        cos.transform.parent = place3;
                    }
                }
            }
        }
    }
}
