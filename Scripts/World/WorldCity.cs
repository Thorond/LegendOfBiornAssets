using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCity
{


    // Constructor 

    public WorldCity(){

        //City[] cities = new City[20];
        // private List<City> cities = new List<City>();

        lindisfarne = new City("Lindisfarne", 20, City.dificultyInGame.easy, new Loot(100, 100, 100, 4));
        dublin = new City("Dublin", 40, City.dificultyInGame.easy, new Loot(150, 50, 120, 2));
        york = new City("York", 5, City.dificultyInGame.easy, new Loot(50, 130, 80, 6));
        novgorod = new City("Novgorod", 70, City.dificultyInGame.easy, new Loot(160, 40, 90, 5));
        kiov = new City("Kiov", 10, City.dificultyInGame.easy, new Loot(60, 150, 150, 4));
        constantinople = new City("Constantinople", 15, City.dificultyInGame.easy, new Loot(120, 120, 120, 3));
        bagdad = new City("Bagdad", 30, City.dificultyInGame.easy, new Loot(40, 50, 200, 7));
        paris = new City("Paris", 65, City.dificultyInGame.easy, new Loot(200, 50, 100, 5));
        bordeaux = new City("Bordeaux", 50, City.dificultyInGame.easy, new Loot(160, 70, 100, 3));
        luna = new City("Luna", 25, City.dificultyInGame.easy, new Loot(80, 120, 110, 4));
        lisbonne = new City("Lisbonne", 55, City.dificultyInGame.easy, new Loot(180, 90, 90, 6));
    }

    // Variables 
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
