using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCity
{


    // Constructor 

    public WorldCity(){

        cities = new City[11];

        // 11 villes pour le moment 

        lindisfarne = new City("Lindisfarne", 20, ConstantsAndEnums.dificultyInGame.easy,30, new Loot(100, 100, 100, 4)); // 1
        dublin = new City("Dublin", 40, ConstantsAndEnums.dificultyInGame.easy,30, new Loot(150, 50, 120, 2)); // 2
        york = new City("York", 5, ConstantsAndEnums.dificultyInGame.easy,30, new Loot(50, 130, 80, 6)); // 3
        novgorod = new City("Novgorod", 70, ConstantsAndEnums.dificultyInGame.easy,30, new Loot(160, 40, 90, 5)); // 4
        kiov = new City("Kiov", 10, ConstantsAndEnums.dificultyInGame.easy,30, new Loot(60, 150, 150, 4)); // 5
        constantinople = new City("Constantinople", 15, ConstantsAndEnums.dificultyInGame.easy,30, new Loot(120, 120, 120, 3)); // 6
        bagdad = new City("Bagdad", 30, ConstantsAndEnums.dificultyInGame.easy,30, new Loot(40, 50, 200, 7)); // 7
        paris = new City("Paris", 65, ConstantsAndEnums.dificultyInGame.easy,30, new Loot(200, 50, 100, 5)); // 8
        bordeaux = new City("Bordeaux", 50, ConstantsAndEnums.dificultyInGame.easy,30, new Loot(160, 70, 100, 3)); // 9
        luna = new City("Luna", 25, ConstantsAndEnums.dificultyInGame.easy,30, new Loot(80, 120, 110, 4)); // 10
        lisbonne = new City("Lisbonne", 55, ConstantsAndEnums.dificultyInGame.easy,30, new Loot(180, 90, 90, 6)); // 11

        cities[0] = lindisfarne;
        cities[1] = dublin;
        cities[2] = york;
        cities[3] = novgorod;
        cities[4] = kiov;
        cities[5] = constantinople;
        cities[6] = bagdad;
        cities[7] = paris;
        cities[8] = bordeaux;
        cities[9] = luna;
        cities[10] = lisbonne;
    }

    // Variables 

    private City[] cities;
    private City lindisfarne;
    private City dublin;
    private City york;
    private City novgorod;
    private City kiov;
    private City constantinople;
    private City bagdad;
    private City paris;
    private City bordeaux;
    private City luna;
    private City lisbonne;


    // Getters and Setters
    public City[] Cities{get{return cities;}}
    public City Lindisfarne{get{return lindisfarne;}}
    public City Dublin{get{return dublin;}}
    public City York{get{return york;}}
    public City Novgorod{get{return novgorod;}}
    public City Kiov{get{return kiov;}}
    public City Constantinople{get{return constantinople;}}
    public City Bagdad{get{return bagdad;}}
    public City Paris{get{return paris;}}
    public City Bordeaux{get{return bordeaux;}}
    public City Luna{get{return luna;}}
    public City Lisbonne{get{return lisbonne;}}



    


}
