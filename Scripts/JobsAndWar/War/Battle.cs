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
    private static int nbrVikingBattle = 0;
    private static int nbrShieldMaidenBattle = 0;
    private static int nbrSoldierBattle = 0;

    // Getters and Setters

    // Functions

    public static void battleCourse(Expedition expedition){
        percentageLossCalculation(expedition.City.DificultyCity);
        nbrVikingBattle = expedition.NbrOfViking;
        nbrShieldMaidenBattle = expedition.NbrOfShieldMaiden;
        nbrSoldierBattle = expedition.City.NbSoldats;
        resultOfTheBattle(expedition);
    }

    // public static void battleCourseByDifficulty(ConstantsAndEnums.dificultyInGame difficulty){

    // }

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

    // faire un test pour cette fonction
    public static void resultOfTheBattle(Expedition expedition){
        while( (nbrVikingBattle > 0 || nbrShieldMaidenBattle > 0 ) && nbrSoldierBattle > 0 ){
            resultOfOneDuel(); // mettre un stop avant que ça n'atteigne 0?
        }
        // résultat?
        if ( nbrSoldierBattle == 0 ) { // battle won
            // fonction de récupération de loot
        } else if (nbrVikingBattle == 0 && nbrShieldMaidenBattle == 0){ // battle lost
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
