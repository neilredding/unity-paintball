using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SteamVR_TrackedController))]
public class ShootScript : MonoBehaviour {

    private SteamVR_TrackedController controller;
    public GameObject paintballPrefab;
    public float paintballVelocity;

	// Use this for initialization
	void Start () {
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += new ClickedEventHandler(FirePaintball);
	}

	// Update is called once per frame
	void Update ()
    {

    }

    void FirePaintball(object sender, ClickedEventArgs e)
    {
        Quaternion rot = transform.rotation;
        GameObject paintball = (GameObject)Instantiate(paintballPrefab, transform.position, rot);
        paintball.GetComponent<Rigidbody>().AddForce(paintball.transform.forward * paintballVelocity);
        Destroy(paintball, 2.0f);
    }
}
