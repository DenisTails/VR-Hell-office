using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListController : MonoBehaviour
{

    [SerializeField]
    private GameObject deadListPref;
    [SerializeField]
    private GameObject ticketPref;
    [SerializeField]
    private GameObject visitorsListPref;
    [SerializeField]
    private GameObject actionsListPref;
    [SerializeField]
    private GameObject actualSealPref;

    [SerializeField]
    private GameObject documentListPref;

    [SerializeField]
    private GameObject badPref;

    [SerializeField]
    private GameObject goodPref;

    [SerializeField]
    private GameObject payPref;

    [SerializeField]
    private GameObject placeforlistToSpawn;

    private DeadListHolder currDeadList;
    private ActionsListHolder currActionsList;

    private GameObject ticket;
    private GameObject deadList;
    private GameObject actionsList;
    private GameObject visitorsList;
    private GameObject documentsList;


    private List<DeadListHolder> visitors = new List<DeadListHolder>();
    private List<bool> visited = new List<bool>();
    private int totalvisits = 0;

    private bool isInProcess = false;

    public void Generate(){

        if (totalvisits >= 7 || isInProcess) {
            Instantiate(payPref, SetPosition(), new Quaternion(-180,120,180,0));
            return;
        }
        else isInProcess = true;

        int i = 0;

        while(true){
            if (!visited[i]) {
                if (Randomizer.GetRandomInt(0,2) == 1){
                    currDeadList = visitors[i];
                    totalvisits++;
                    visited[i] = true;
                    break;
                }
            }
            i = (i + 1) % 7;
        }

        currActionsList = new ActionsListHolder();

        SpawnDeadList();
        SpawnTicket();
        SpawnActions();
        SpawnDocumentList();
    }

    public void Revert(){
        Destroy(ticket);
        Destroy(deadList);
        Destroy(actionsList);
        Destroy(documentsList);
    }

    public void FinalVerdict(bool userSentToHeaven){

        if (!isInProcess) return;

        bool hasToHeaven = 
            currDeadList.IsCorrectSeal() && 
            currActionsList.IsCorrectSeal() && 
            currActionsList.IsPositiveKarma();

        if (userSentToHeaven == hasToHeaven) {
            Instantiate(goodPref, SetPosition(), new Quaternion(-180,120,180,0));
        }
        else {
            Instantiate(badPref, SetPosition(), new Quaternion(-180,120,180,0));
        }

        isInProcess = false;
    }

    private Vector3 SetPosition(){
        Vector3 pos = placeforlistToSpawn.transform.position;
        float x = placeforlistToSpawn.GetComponent<Collider>().bounds.size.x;
        float z = placeforlistToSpawn.GetComponent<Collider>().bounds.size.z;
        pos.x += Randomizer.GetRandomFloat(-x/2, x/2);
        pos.z += Randomizer.GetRandomFloat(-z/2, z/2);
        return pos;
    }

    private void SpawnDeadList(){
        deadList = Instantiate(deadListPref, SetPosition(), new Quaternion(180,120,180,0));
        deadList.GetComponent<IDeadListHolderSettable>().Set(currDeadList);
    }

    private void SpawnTicket(){
        TicketHolder t = new TicketHolder();
        ticket = Instantiate(ticketPref, SetPosition(), new Quaternion(-180,120,180,0));
        ticket.GetComponent<ITicketHolderSettable>().Set(t);
    }

    private void SpawnVisitors(){
        visitorsList = Instantiate(visitorsListPref, SetPosition(), new Quaternion(-180,120,180,0));
        visitorsList.GetComponent<IVisitorsHolderSettable>().Set(visitors);
    }

    private void SpawnActions(){
        actionsList = Instantiate(actionsListPref, SetPosition(), new Quaternion(-180,120,180,0));
        actionsList.GetComponent<IActionsHolderSettable>().Set(currActionsList);
    }

    private void SpawnSeal() {
        Instantiate(actualSealPref, SetPosition(), new Quaternion(-180,120,180,0));
    }

    private void SpawnDocumentList() {
        documentsList = Instantiate(documentListPref, SetPosition(), new Quaternion(-180,120,180,0));
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 7; i++){
            visitors.Add(new DeadListHolder());
            visited.Add(false);
        }
        SpawnVisitors();
        SpawnSeal();
        Debug.Log(visitors.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
