using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_stats : MonoBehaviour {

    public static int[] basic_stats = { 0, 0, 0, 0, 0, 0 };
    /**
     * 0: Total health value
     * 1: Player Speed
     * 2: Base attack Power
     * 3: Base attack speed
     * 4: Health Pick-Up value
     * 5: Health Pick-up spawn rate 
     **/

    public static int level_unlock = 0; //keeps track of the levels the player has defeated

    public static int total_points = 0; //the amount of points the player has built up
}
