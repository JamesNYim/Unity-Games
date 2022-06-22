using System.Collections;
using UnityEngine;
[System.Serializable]

public class cardObject
{
    public GameObject card;
    public float dropRate;
    [HideInInspector] public float minDropRate, maxDropRate;

}
 public class RandomCardSpawn : MonoBehaviour
{
    //Variables
    private float nextSpawnTime;
    public float displayRate;
    public float endRollAnimationTime;
    private float currentTime;

    private bool isRolling = false;
    private bool hasRolled = false;
    public cardObject[] cardToSpawn;
    private GameObject droppedCard;
    private GameObject droppedCardPrefab;

    void cardDropRates()
    {
        //Getting spawn rates
        for (int i = 0; i < cardToSpawn.Length; i++)
        {
            if (i == 0)
            {
                cardToSpawn[i].minDropRate = 0;
                cardToSpawn[i].maxDropRate = cardToSpawn[i].dropRate - 1;
            }
            else
            {
                cardToSpawn[i].minDropRate = cardToSpawn[i - 1].maxDropRate + 1;
                cardToSpawn[i].maxDropRate = cardToSpawn[i].minDropRate + cardToSpawn[i].dropRate - 1;
            }
        }
    }

    void rollingCard()
    {
        //Getting a random percent number
        int random = Random.Range(0, 100);
            
        for (int i = 0; i < cardToSpawn.Length; i++)
        {
            if (random >= cardToSpawn[i].minDropRate && random <= cardToSpawn[i].maxDropRate) //Checking which card is supposed to be spawned
            {
                //Variables
                cardObject currentCard = cardToSpawn[random];
                GameObject card = currentCard.card;

                //Creating the object in the game
                GameObject droppedCard = new GameObject("cardObject");
                droppedCard.transform.position = new Vector3(0, 0, 0);
                droppedCard.transform.parent = transform;

                //Displaying the card
                droppedCardPrefab = Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity, transform);
                droppedCardPrefab.name = ("cardPrefab");
            }
        }

    }  

    void rollDisplay()
    {
            int random = Random.Range(0, cardToSpawn.Length);
            //Variables
            cardObject currentCard = cardToSpawn[random];
            GameObject card = currentCard.card;

            //Creating the object in the game
            GameObject cardObject = new GameObject("cardObject");
            cardObject.transform.position = new Vector3(0, 0, 0);
            cardObject.transform.parent = transform;

            //Displaying the card
            GameObject cardPrefab = Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity, transform);
            cardPrefab.name = ("cardPrefab");
                    
            //Destroying the card 
            Destroy(cardObject, displayRate);
            Destroy(cardPrefab, displayRate);  
    }

    bool rollAnimation()
    {
        endRollAnimationTime -= Time.deltaTime;
        if (endRollAnimationTime >= 0.0f)
        {
            if (nextSpawnTime < Time.time)
            {
                rollDisplay();
                nextSpawnTime = Time.time + displayRate;
            }
        }
        rollingCard();
        return true;
    }

    public void rolling()
    {
    
        isRolling = true;
        currentTime = endRollAnimationTime;
        hasRolled = false;
    }
    
    void Start()
    {
        isRolling = false;
        hasRolled = false;
    }

    void Update()
    {
        
        if (isRolling)
        {
            currentTime -= Time.deltaTime;
            if (currentTime >= 0.0f)
            {
                if (nextSpawnTime < Time.time)
                {
                    rollDisplay();
                    nextSpawnTime = Time.time + displayRate;
                }
            }
            else
            {
                hasRolled = true;
                currentTime = endRollAnimationTime;
                isRolling = false;
            }
        }
        if (hasRolled)
        {
            Destroy(droppedCardPrefab);
            Destroy(droppedCard);
            rollingCard();
            //hasRolled = false;
        }
        
    }
}
