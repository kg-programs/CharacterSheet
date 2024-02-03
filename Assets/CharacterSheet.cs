using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour{
    //variables
    [SerializeField] string name = "name";
    [SerializeField] int bonus = 0;
    [SerializeField] bool weapon = true;
    [SerializeField] [Range(-5,5)] int STR = 0;
    [SerializeField][Range(-5, 5)] int DEX = 0;
    int hitMod;
    int d20;
    int enemyAC;
    int hitChance;
    int outcome;
    // Start is called before the first frame update
    void Start(){
        //Hit modifier
        if (weapon != true){
            hitMod = STR + bonus;
        }
        else{
            if(STR >= DEX){
                hitMod = STR + bonus;
            }
            else{
                hitMod = DEX + bonus;
            }
        }
        //randoms
        d20 = Random.Range(0, 20);
        enemyAC = Random.Range(10, 20);
        //results
        hitChance = hitMod + d20;
        if(hitChance > enemyAC){
            if(hitChance-enemyAC >= 5){
                outcome = 1;
            }
            else { 
                outcome = 2; 
            }
        }
        else if(hitChance == enemyAC){
            outcome = 3;
        }
        else{
            if(enemyAC-hitChance >= 8){
                outcome = 4;
            }
            else {  
                outcome = 5;
            }
        }
        //print out
        if(hitMod >= 0){
            Debug.Log(name + "'s hit modifier is +" + hitMod);
        }
        else{
            Debug.Log(name + "'s hit modifier is " + hitMod);
        }
        Debug.Log("Enemy AC is " + enemyAC);
        Debug.Log(name + " rolled a " + d20);
        switch (outcome){
            case 1: Debug.Log("The enemy has been hit so hard the loot has atomized and can no longer be collected");
                break;
            case 2: Debug.Log("The enemy has been hit and has dropped rusty sword");
                break;
            case 3: Debug.Log("You and the enemy have struck each other. you both die");
                break;
            case 4: Debug.Log("You miss and trip over a rock killing your self in the process (Wow even I the narator am surprized by your lack of awareness)");
                break;
            case 5: Debug.Log("You miss and the enemy strikes you down. (your underleveled head to Simulated Universe to level up)");
                break;
        }
    }

    // Update is called once per frame
    void Update(){
        
    }
}
