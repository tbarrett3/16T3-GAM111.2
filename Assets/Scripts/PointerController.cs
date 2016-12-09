using UnityEngine;
using System.Collections;

public class PointerController : MonoBehaviour {

    public GameObject[] SpawnLocs;
    public int currentLoc;

    public KeyCode up, down;

    public Vector3 offset;


    public KeyCode placefire, placeWater, placeForest;

    public GameObject fireSpellPrefab, waterSpellPrefab, forestSpellPrefab;

    public KeyCode shootSpell;
    public GameObject[] LaneLocs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(down))
        {
            currentLoc++;
        }

        if (Input.GetKeyDown(up))
        {
            currentLoc--;
        }

        currentLoc = Mathf.Clamp(currentLoc, 0, SpawnLocs.Length-1);

        transform.position = SpawnLocs[currentLoc].transform.position + offset;

        if (Input.GetKeyDown(placefire))
        {
            SpawnItem(fireSpellPrefab);
        }
        else if (Input.GetKeyDown(placeWater))
        {
            SpawnItem(waterSpellPrefab);
        }
        else if (Input.GetKeyDown(placeForest))
        {
            SpawnItem(forestSpellPrefab);
        }

        if (Input.GetKeyDown(shootSpell))
        {
            SendSpell();
        }
    }

    public void SpawnItem(GameObject spellToCreate)
    {
        var currentSpellAtLoc = SpawnLocs[currentLoc].transform.childCount > 0 ? SpawnLocs[currentLoc].transform.GetChild(0) : null;

        if(currentSpellAtLoc != null)
        {
            Destroy(currentSpellAtLoc.gameObject);
        }

        GameObject spellInstance = Instantiate(spellToCreate, SpawnLocs[currentLoc].transform.position, Quaternion.identity) as GameObject;
        spellInstance.transform.parent = SpawnLocs[currentLoc].transform;
    }   

    public void SendSpell()
    {
        var currentSpellAtLoc = SpawnLocs[currentLoc].transform.childCount > 0 ? SpawnLocs[currentLoc].transform.GetChild(0) : null;

        if (currentSpellAtLoc != null)
        {
            GameObject spellToSend = SpawnLocs[currentLoc].transform.GetChild(0).gameObject;
            spellToSend.transform.parent = null;
            spellToSend.transform.position = LaneLocs[currentLoc].transform.position;
        }
        else
        {
            print("no spell");
        }
    }
}
