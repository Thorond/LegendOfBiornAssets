using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Battle {
    
    // Constructor

    // public Battle(){

    // }

    // Variables

    private static int percentageLossOfVikings = 0;
    private static float percentageLossOfSieldMaidens = 0;
    private static float percentageLossAcceptedWhenExplore = 20/100;
    private static float percentageLossAcceptedWhenPlunder = 50/100;
    private static float percentageLossAcceptedWhenRaze = 80/100;

    private static int nbrVikingStart = 0;
    private static int nbrShieldMaidenStart = 0;
    private static int nbrSoldierStart = 0;
    private static int nbrVikingBattle = 0;
    private static int nbrShieldMaidenBattle = 0;
    private static int nbrSoldierBattle = 0;

    // Getters and Setters

    // Functions

    public static void battleCourse(Expedition expedition){
        percentageLossCalculation(expedition.City.DificultyCity);
        nbrVikingStart = expedition.NbrOfViking;
        nbrShieldMaidenStart = expedition.NbrOfShieldMaiden;
        nbrSoldierStart = expedition.City.NbSoldats;
        nbrVikingBattle = expedition.NbrOfViking;
        nbrShieldMaidenBattle = expedition.NbrOfShieldMaiden;
        nbrSoldierBattle = expedition.City.NbSoldats;
        resultOfTheBattle(expedition);
    }

    public static void percentageLossCalculation(ConstantsAndEnums.dificultyInGame difficulty){
        if ( difficulty == ConstantsAndEnums.dificultyInGame.easy){
            percentageLossOfVikings = 20 / 100 ;
            percentageLossOfSieldMaidens = 25 / 100 ;
        } else if (difficulty == ConstantsAndEnums.dificultyInGame.medium){
            percentageLossOfVikings = 40 / 100 ;
            percentageLossOfSieldMaidens = 50 / 100 ;

        } else if (difficulty == ConstantsAndEnums.dificultyInGame.hard){
            percentageLossOfVikings = 60 / 100 ;
            percentageLossOfSieldMaidens = 80 / 100 ;

        }
    }

    public static bool lossAccepted(Expedition expedition, int nbrFighterBattle, int nbrFighterStart){
        if (expedition.AttackChosen == ConstantsAndEnums.possibleAttacks.explore){
            if ( nbrFighterBattle <= nbrFighterStart * percentageLossAcceptedWhenExplore ){
                return true;
            }
        } else if (expedition.AttackChosen == ConstantsAndEnums.possibleAttacks.plunder){
            if ( nbrFighterBattle <= nbrFighterStart * percentageLossAcceptedWhenPlunder ){
                return true;
            }
        } else if (expedition.AttackChosen == ConstantsAndEnums.possibleAttacks.raze){
            if ( nbrFighterBattle <= nbrFighterStart * percentageLossAcceptedWhenRaze ){
                return true;
            }
        } 
        return false;

    }

    // faire un test pour cette fonction
    public static void resultOfTheBattle(Expedition expedition){
        bool weLost = false;
        bool ennemyLost = false;
        while( !weLost && !ennemyLost ){
            resultOfOneDuel(); 
            weLost = lossAccepted(expedition,nbrVikingBattle + nbrShieldMaidenBattle,nbrVikingStart+nbrShieldMaidenStart);
            ennemyLost = lossAccepted(expedition,nbrSoldierBattle,nbrSoldierStart);
        }
        // résultat?
        if ( ennemyLost ) { // battle won
            // fonction de récupération de loot
        } else if ( weLost ){ // battle lost
            // fonction de CATASTROOOOOPHE
        }

        expedition.NbrOfViking = nbrVikingBattle;
        expedition.NbrOfShieldMaiden = nbrShieldMaidenBattle;
    }

    public static void resultOfOneDuel(){
        ConstantsAndEnums.people choice = vikingOrShieldMaiden(nbrVikingBattle,nbrShieldMaidenBattle); // on choisit proportionnelement entre un viking ou une SM
        if ( choice == ConstantsAndEnums.people.Viking){
            if (Random.Range(0,100) < percentageLossOfVikings ){
                nbrVikingBattle -= 1;
            } else{
                nbrSoldierBattle -=1;
            }
        } else {
            if (Random.Range(0,100) < percentageLossOfSieldMaidens ){
                nbrShieldMaidenBattle -= 1;
            } else{
                nbrSoldierBattle -=1;
            }
        }
    }

    public static ConstantsAndEnums.people vikingOrShieldMaiden(int viking, int sm){
        int percentageVikingPerSm = viking / (viking+sm);
        if ( Random.Range(0, 100) < percentageVikingPerSm ){
            return ConstantsAndEnums.people.Viking;
        } else {
            return ConstantsAndEnums.people.ShieldMaiden;
        }
    }


}
