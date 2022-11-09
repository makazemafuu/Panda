using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Reverbation : MonoBehaviour
{
    public Vector3 centreZone = Vector3.zero;
    public float radiusStartEffect = 10;

    public AudioMixer mixer;

    [System.Serializable]
    public class TrackedObject
    {
        public Transform transform;
        //public string MixerParameter = "Undefined Tracked Param";
        public float MinVal = 0;
        public float MaxVal = 0;
    }

    public TrackedObject[] trackedObjects;

    public void Update()
    {
        //On v�rifie tous les objets track�s
        foreach (TrackedObject t in trackedObjects)
        {
            //Calcul de la distance au centre de la zone (ne pas oublier de transformer le vecteur centre du rep�re local au rep�re global)
            float distToT = Vector3.Distance(transform.TransformPoint(centreZone), t.transform.position);
            //La valeur de l'effet : Min + (Max-Min) * distanceNormalis�e
            float effectVal = t.MinVal + (t.MaxVal - t.MinVal) * (1.0f - (distToT / radiusStartEffect));
            //On ajoute le param�tre au mixer
            //mixer.SetFloat(t.MixerParameter, effectVal);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.TransformPoint(centreZone), radiusStartEffect);
    }
}