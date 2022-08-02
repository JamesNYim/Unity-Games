using System.Collections;
using UnityEngine;

namespace Game
{
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
        public float displayRate;
        public float animationTime;
        public float timeToDisplay;
        private bool animationDone;
        private bool hasRolled;
        public cardObject[] cardToSpawn;
        private GameObject droppedCardPrefab;
        private GameObject droppedCard;
        private GameObject card;
        public Player player;


        private void cardDropRates()
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

        private IEnumerator rollingCard()
        {
            yield return new WaitForSeconds(timeToDisplay);
            cardDropRates();
            //Getting a random percent number
            int random = Random.Range(0, 100);
            //Debug.Log("randomNum: " + random);     
            for (int i = 0; i < cardToSpawn.Length; i++)
            {
                //Debug.Log("currentCard minDropRate: " + cardToSpawn[i].minDropRate); 
                //Debug.Log("currentCard maxDropRate: " + cardToSpawn[i].maxDropRate); 
                if (random >= cardToSpawn[i].minDropRate && random <= cardToSpawn[i].maxDropRate) //Checking which card is supposed to be spawned
                {
                    //Variables
                    cardObject currentCard = cardToSpawn[i];
                    GameObject card = currentCard.card;
                    Debug.Log("Card given: " + card.name);

                    //Creating the object in the game
                    card.transform.position = new Vector3(0, 0, 0);

                    //Displaying the card
                    droppedCardPrefab = Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity, transform);
                    droppedCardPrefab.name = ("cardPrefab");

                    //Giving the card
                    player.giveCharacter(card.name, 1);
                    player.printCharacters();
                    break;
                    
                    

                }
            }
            hasRolled = true;

        }  

        private void rollDisplay()
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
            if (animationDone)
            {
                CancelInvoke("rollDisplay");
            }
                    
        }

        private IEnumerator rollAnimation(Player player)
        {
            hasRolled = false;
            Debug.Log("Started stopAnimation at: " + Time.time);
            yield return new WaitForSeconds(animationTime);
            animationDone = true;
            Debug.Log("Ended stopAnimation at: " + Time.time);
            Debug.Log("givingCard at: " + Time.time);
            StartCoroutine(rollingCard());
            
        }

        public void rolling()
        {
            if (hasRolled)
            {
                Destroy(card);
                Destroy(droppedCardPrefab);
            }
            
            Debug.Log("Rolling");
            animationDone = false;
            InvokeRepeating("rollDisplay", 0, displayRate);
            StartCoroutine(rollAnimation(player));
        }
        
        
    }
}
