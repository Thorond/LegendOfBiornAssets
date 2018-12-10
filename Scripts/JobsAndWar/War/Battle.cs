using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Battle {
    
    // Constructor

    // public Battle(){

    // }

    // Variables

    private static float percentageLossOfVikings = 0;
    private static float percentageLossOfSieldMaidens = 0;
    private static float percentageLossAcceptedWhenExplore = 80f/100f;
    private static float percentageLootRetrievedWhenExplore = 20f/100f;
    private static float percentageLossAcceptedWhenPlunder = 50f/100f;
    private static float percentageLootRetrievedWhenPlunder = 90f/100f;
    private static float percentageLossAcceptedWhenRaze = 20f/100f;
    private static float percentageLootRetrievedWhenRaze = 100f/100f;

    private static float nbrVikingStart = 0;
    private static float nbrShieldMaidenStart = 0;
    private static float nbrSoldierStart = 0;
    private static float nbrVikingBattle = 0;
    private static float nbrShieldMaidenBattle = 0;
    private static float nbrSoldierBattle = 0;

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
            percentageLossOfVikings = 20f / 100f ;
            percentageLossOfSieldMaidens = 25f / 100f ;
        } else if (difficulty == ConstantsAndEnums.dificultyInGame.medium){
            percentageLossOfVikings = 40f / 100f ;
            percentageLossOfSieldMaidens = 50f / 100f ;

        } else if (difficulty == ConstantsAndEnums.dificultyInGame.hard){
            percentageLossOfVikings = 60f / 100f ;
            percentageLossOfSieldMaidens = 80f / 100f ;

        }
    }

    public static bool lossAccepted(Expedition expedition, float nbrFighterBattle, float nbrFighterStart){
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
        // résultat
        expedition.NbrOfRemainingViking = (int)nbrVikingBattle;
        expedition.NbrOfRemainingSM = (int)nbrShieldMaidenBattle;
        if ( ennemyLost ) { // battle won
            Debug.Log("We won");
            expedition.BattleStatus = ConstantsAndEnums.battleStatus.won;
            // fonction de récupération de loot
            award(expedition);
        } else if ( weLost ){ // battle lost
            Debug.Log("We lost");
            expedition.BattleStatus = ConstantsAndEnums.battleStatus.lost;
            // on rentre avec ce qu'il nous reste
        }

    }

    public static void resultOfOneDuel(){
        ConstantsAndEnums.people choice = vikingOrShieldMaiden(nbrVikingBattle,nbrShieldMaidenBattle); // on choisit proportionnelement entre un viking ou une SM
        if ( choice == ConstantsAndEnums.people.Viking){
            if (Random.Range(0,100) < percentageLossOfVikings * 100){
                nbrVikingBattle -= 1;
            } else{
                nbrSoldierBattle -=1;
            }
        } else {
            if (Random.Range(0,100) < percentageLossOfSieldMaidens * 100 ){
                nbrShieldMaidenBattle -= 1;
            } else{
                nbrSoldierBattle -=1;
            }
        }
    }

    public static ConstantsAndEnums.people vikingOrShieldMaiden(float viking, float sm){
        float percentageVikingPerSm = viking / (viking+sm);
        if ( Random.Range(0, 100) < percentageVikingPerSm ){
            return ConstantsAndEnums.people.Viking;
        } else {
            return ConstantsAndEnums.people.ShieldMaiden;
        }
    }

    public static void award(Expedition expedition){
        if (expedition.AttackChosen == ConstantsAndEnums.possibleAttacks.explore){
           awardBydifficulty(expedition,percentageLootRetrievedWhenExplore);
        } else if (expedition.AttackChosen == ConstantsAndEnums.possibleAttacks.plunder){
           awardBydifficulty(expedition,percentageLootRetrievedWhenPlunder);
        } else if (expedition.AttackChosen == ConstantsAndEnums.possibleAttacks.raze){
           awardBydifficulty(expedition,percentageLootRetrievedWhenRaze);
        } 
    }

    public static void awardBydifficulty(Expedition expedition,float percentageLoot){
        float pourcentageGold = (float)expedition.City.LootDetail.Gold / (float)(expedition.City.LootDetail.Gold + expedition.City.LootDetail.Wood + expedition.City.LootDetail.Iron);
        float pourcentageWood = (float)expedition.City.LootDetail.Wood / (float)(expedition.City.LootDetail.Gold + expedition.City.LootDetail.Wood + expedition.City.LootDetail.Iron);
        // float pourcentageIron = (float)expedition.City.LootDetail.Iron / (float)(expedition.City.LootDetail.Gold + expedition.City.LootDetail.Wood + expedition.City.LootDetail.Iron);
       
        bool maxGoldRetrieve = false;
        bool maxWoodRetrieve = false;
        bool maxIronRetrieve = false;
        while ( expedition.GoldBroughtBack + expedition.WoodBroughtBack + expedition.IronBroughtBack <= expedition.SpaceForLoots
            && !(maxGoldRetrieve && maxWoodRetrieve && maxIronRetrieve) ){
            float choice = Random.Range(0,100);
            if ( choice  < pourcentageGold * 100 ){
                if (expedition.GoldBroughtBack >= percentageLoot * expedition.City.LootDetail.Gold 
                    || expedition.GoldBroughtBack == expedition.City.LootDetail.Gold ){
                    maxGoldRetrieve = true;
                }
                if ( !maxGoldRetrieve ){
                    expedition.GoldBroughtBack += 1;
                }
            } else if ( choice  < ( pourcentageGold + pourcentageWood) * 100 ){
                if (expedition.WoodBroughtBack >= percentageLoot * expedition.City.LootDetail.Wood 
                    || expedition.WoodBroughtBack == expedition.City.LootDetail.Wood ){
                    maxWoodRetrieve = true;
                }
                if ( !maxWoodRetrieve ){
                    expedition.WoodBroughtBack += 1;
                }
            } else {
                if (expedition.IronBroughtBack >= percentageLoot * expedition.City.LootDetail.Iron 
                    || expedition.IronBroughtBack == expedition.City.LootDetail.Iron ){
                    maxIronRetrieve = true;
                }
                if ( !maxIronRetrieve ){
                    expedition.IronBroughtBack += 1;
                }
            }
        }
        expedition.SlaveBroughtBack = Mathf.Min(Mathf.RoundToInt(percentageLoot * expedition.City.LootDetail.Slaves),
                                                expedition.SpaceForMen - (expedition.NbrOfRemainingViking + expedition.NbrOfRemainingSM));
    }
}
