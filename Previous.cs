using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Previous : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;

    public int width;
    public int height;
    //public GameObject tilePrefab;
    private GameObject[,] allTiles;
    public GameObject[] dots;
    public GameObject[,] allDots = new GameObject[5, 5];
    public int dotz;
    public int boardz;

    private int degree = 0;
    private int start_x = -2;
    private int start_y = -2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void chosse_combine_dot()
    {

        if ((int)this.transform.rotation.eulerAngles.z == 90)
        {
            combine_dots_90();
        }
        else if ((int)this.transform.rotation.eulerAngles.z == 270)
        {
            combine_dots_n90();
        }
        else if ((int)this.transform.rotation.eulerAngles.z == 180)
        {
            combine_dots_180();
        }
        else
        {
            combine_dots();
        }
    }
    //help dot move down from the empty
    private void moveDown(int col_location)
    {

        int j = 0;
        int k = 0;
        int total_null = 0;
        //location of the null list
        //                         stop at
        //                            |
        //                            V
        //[1, 2, 3, null, null, null, 4, 6, 7]

        while (j <= 4)
        {
            if (allDots[col_location, j] == null)
            {
                total_null++;
                k = j;

            }
            j++;
        }

        j = k + 1;


        //shift to fill up the null location
        //     new location 4     pre location
        //           |                |
        //           V                V
        //[1, 2, 3, null, null, null, 4, 6, 7]
        //result:
        //[1, 2, 3, 4, 6, 7, null, null, null]
        while (j < 5 && j >= 0)
        {
            if (allDots[col_location, j] != null)
            {
                //get the gameobject location of the null cell
                // int[] curr_location = getLocation(col_location, j + total_null);
                //create new vector
                Vector3 new_location = new Vector3(col_location, j - total_null, dotz);
                allDots[col_location, j].transform.position = new_location;
                //allDots[col_location, j].transform.Translate(col_location, j - total_null, dotz);
                //set the object into the new location of allDot
                allDots[col_location, j - total_null] = allDots[col_location, j];
                allDots[col_location, j] = null;
            }
            j++;
        }
        j = 4;
        //fill in the null with new dot
        //result:
        //[1, 2, 3, 4, 6, 7, newdot, newdot, newdot]

        while (j >= 0 && allDots[col_location, j] == null)
        {
            int dotToUse = UnityEngine.Random.Range(0, dots.Length);
            //get the gameobject location from the allDot location
            //int[] curr_location = getLocation(col_location, j);
            Vector3 tempPosition = new Vector3(col_location, j, dotz);
            GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
            dot.transform.parent = this.transform;
            dot.name = "(" + col_location + "," + j + "," + dotz + ")";
            allDots[col_location, j] = dot;

            j--;
        }


    }
    //combie the dot with the same color
    private void combine_dots()
    {


        for (int i = 0; i <= 4; i++)
        {
            for (int j = 0; j <= 4; j++)
            {
                if (allDots[i, j] != null)
                {
                    string sameTag = allDots[i, j].tag;
                    int next_index = j + 1;
                    //find if there is the same color 
                    if (next_index <= 4 && allDots[i, next_index].tag == sameTag)
                    {
                        //while if the color is the same, reomve the one that are the same
                        //and only keep the first one
                        while (next_index <= 4 && allDots[i, next_index].tag == sameTag)
                        {
                            //combine size add togather
                            Dot dot = allDots[i, j].GetComponent<Dot>();
                            Dot same_dot = allDots[i, next_index].GetComponent<Dot>();
                            dot.size += same_dot.size;
                            //destory the dot that has been combine
                            Destroy(allDots[i, next_index]);
                            allDots[i, next_index] = null;
                            next_index++;
                        }
                        //do one match at a time
                        moveDown(i);
                        break;
                    }
                }
            }


        }

    }

    //help dot move down from the empty
    private void moveDown_180(int col_location)
    {
        this.transform.Rotate(0, 0, -180, Space.World);
        int j = 4;
        int k = 0;
        int total_null = 0;
        //location of the null list
        //                         stop at
        //                            |
        //                            V
        //[1, 2, 3, null, null, null, 4, 6, 7]

        while (j >= 0)
        {
            if (allDots[col_location, j] == null)
            {
                total_null++;
                k = j;

            }
            j--;
        }

        j = k - 1;


        //shift to fill up the null location
        //     new location 4     pre location
        //           |                |
        //           V                V
        //[1, 2, 3, null, null, null, 4, 6, 7]
        //result:
        //[1, 2, 3, 4, 6, 7, null, null, null]
        while (j < 5 && j >= 0)
        {
            if (allDots[col_location, j] != null)
            {
                //get the gameobject location of the null cell
                // int[] curr_location = getLocation(col_location, j + total_null);
                //create new vector
                Vector3 new_location = new Vector3(col_location, j + total_null, dotz);
                allDots[col_location, j].transform.position = new_location;
                //allDots[col_location, j].transform.Translate(col_location, j - total_null, dotz);
                //set the object into the new location of allDot
                allDots[col_location, j + total_null] = allDots[col_location, j];
                allDots[col_location, j] = null;
            }
            j--;
        }
        j = 0;
        //fill in the null with new dot
        //result:
        //[1, 2, 3, 4, 6, 7, newdot, newdot, newdot]

        while (j <= 4 && allDots[col_location, j] == null)
        {
            int dotToUse = UnityEngine.Random.Range(0, dots.Length);
            //get the gameobject location from the allDot location
            //int[] curr_location = getLocation(col_location, j);
            Vector3 tempPosition = new Vector3(col_location, j, dotz);
            GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
            dot.transform.parent = this.transform;
            dot.name = "(" + col_location + "," + j + "," + dotz + ")";
            allDots[col_location, j] = dot;

            j++;
        }

        this.transform.Rotate(0, 0, 180, Space.World);
    }
    //combie the dot with the same color
    private void combine_dots_180()
    {
        for (int i = 4; i >= 0; i--)
        {
            for (int j = 4; j >= 0; j--)
            {
                if (allDots[i, j] != null)
                {
                    string sameTag = allDots[i, j].tag;
                    int next_index = j - 1;
                    //find if there is the same color 
                    if (next_index >= 0 && allDots[i, next_index].tag == sameTag)
                    {
                        //while if the color is the same, reomve the one that are the same
                        //and only keep the first one
                        while (next_index >= 0 && allDots[i, next_index].tag == sameTag)
                        {
                            //combine size add togather
                            Dot dot = allDots[i, j].GetComponent<Dot>();
                            Dot same_dot = allDots[i, next_index].GetComponent<Dot>();
                            dot.size += same_dot.size;
                            //destory the dot that has been combine
                            Destroy(allDots[i, next_index]);
                            allDots[i, next_index] = null;
                            next_index--;
                        }
                        //do one match at a time
                        moveDown_180(i);
                        break;
                    }
                }
            }


        }

    }

    //help dot move down from the empty
    private void moveDown_90(int col_location)
    {
        this.transform.Rotate(0, 0, -90, Space.World);
        int i = 0;
        int k = 0;
        int total_null = 0;
        //location of the null list
        //                         stop at
        //                            |
        //                            V
        //[1, 2, 3, null, null, null, 4, 6, 7]

        while (i <= 4)
        {
            if (allDots[i, col_location] == null)
            {
                total_null++;
                k = i;

            }
            i++;
        }

        i = k + 1;


        //shift to fill up the null location
        //     new location 4     pre location
        //           |                |
        //           V                V
        //[1, 2, 3, null, null, null, 4, 6, 7]
        //result:
        //[1, 2, 3, 4, 6, 7, null, null, null]
        while (i < 5 && i >= 0)
        {
            if (allDots[i, col_location] != null)
            {
                //get the gameobject location of the null cell
                // int[] curr_location = getLocation(col_location, j + total_null);
                //create new vector
                Vector3 new_location = new Vector3(i - total_null, col_location, dotz);
                allDots[i, col_location].transform.position = new_location;
                //allDots[col_location, j].transform.Translate(col_location, j - total_null, dotz);
                //set the object into the new location of allDot
                allDots[i - total_null, col_location] = allDots[i, col_location];
                allDots[i, col_location] = null;
            }
            i++;
        }
        i = 4;
        //fill in the null with new dot
        //result:
        //[1, 2, 3, 4, 6, 7, newdot, newdot, newdot]

        while (i >= 0 && allDots[i, col_location] == null)
        {
            int dotToUse = UnityEngine.Random.Range(0, dots.Length);
            //get the gameobject location from the allDot location
            //int[] curr_location = getLocation(col_location, j);
            Vector3 tempPosition = new Vector3(i, col_location, dotz);
            GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
            dot.transform.parent = this.transform;
            dot.name = "(" + i + "," + col_location + "," + dotz + ")";
            allDots[i, col_location] = dot;

            i--;
        }
        this.transform.Rotate(0, 0, 90, Space.World);


    }
    //combie the dot with the same color
    private void combine_dots_90()
    {

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                //Debug.Log(allDots[i, j].tag);
            }
        }
        for (int j = 4; j >= 0; j--)
        {
            for (int i = 0; i <= 4; i++)
            {
                if (allDots[i, j] != null)
                {
                    string sameTag = allDots[i, j].tag;
                    int next_index = i + 1;
                    //find if there is the same color 
                    if (next_index <= 4 && allDots[next_index, j].tag == sameTag)
                    {
                        //while if the color is the same, reomve the one that are the same
                        //and only keep the first one
                        while (next_index <= 4 && allDots[next_index, j].tag == sameTag)
                        {
                            //combine size add togather
                            Dot dot = allDots[i, j].GetComponent<Dot>();
                            Dot same_dot = allDots[next_index, j].GetComponent<Dot>();
                            dot.size += same_dot.size;
                            //destory the dot that has been combine
                            Destroy(allDots[next_index, j]);
                            allDots[next_index, j] = null;
                            next_index++;
                        }
                        //do one match at a time
                        moveDown_90(j);
                        break;
                    }
                }
            }


        }

    }

    //help dot move down from the empty
    private void moveDown_n90(int col_location)
    {
        this.transform.Rotate(0, 0, 90, Space.World);
        int i = 4;
        int k = 0;
        int total_null = 0;
        //location of the null list
        //                         stop at
        //                            |
        //                            V
        //[1, 2, 3, null, null, null, 4, 6, 7]

        while (i >= 0)
        {
            if (allDots[i, col_location] == null)
            {
                total_null++;
                k = i;

            }
            i--;
        }

        i = k - 1;


        //shift to fill up the null location
        //     new location 4     pre location
        //           |                |
        //           V                V
        //[1, 2, 3, null, null, null, 4, 6, 7]
        //result:
        //[1, 2, 3, 4, 6, 7, null, null, null]
        while (i < 5 && i >= 0)
        {
            if (allDots[i, col_location] != null)
            {
                //get the gameobject location of the null cell
                // int[] curr_location = getLocation(col_location, j + total_null);
                //create new vector
                Vector3 new_location = new Vector3(i + total_null, col_location, dotz);
                Vector3 prev_location = allDots[i, col_location].transform.position;
                allDots[i, col_location].transform.position = Vector3.Lerp(prev_location, new_location, .2f);
                allDots[i, col_location].transform.position = new_location;
                //allDots[col_location, j].transform.Translate(col_location, j - total_null, dotz);
                //set the object into the new location of allDot
                allDots[i + total_null, col_location] = allDots[i, col_location];
                allDots[i, col_location] = null;
            }
            i--;
        }
        i = 0;
        //fill in the null with new dot
        //result:
        //[1, 2, 3, 4, 6, 7, newdot, newdot, newdot]

        while (i <= 4 && allDots[i, col_location] == null)
        {
            int dotToUse = UnityEngine.Random.Range(0, dots.Length);
            //get the gameobject location from the allDot location
            //int[] curr_location = getLocation(col_location, j);
            Vector3 tempPosition = new Vector3(i, col_location, dotz);
            GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
            dot.transform.parent = this.transform;
            dot.name = "(" + i + "," + col_location + "," + dotz + ")";
            allDots[i, col_location] = dot;

            i++;
        }

        this.transform.Rotate(0, 0, -90, Space.World);


    }
    //combie the dot with the same color
    private void combine_dots_n90()
    {

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                //Debug.Log(allDots[i, j].tag);
            }
        }
        for (int j = 0; j <= 4; j++)
        {
            for (int i = 4; i >= 0; i--)
            {
                if (allDots[i, j] != null)
                {
                    string sameTag = allDots[i, j].tag;
                    int next_index = i - 1;
                    //find if there is the same color 
                    if (next_index >= 0 && allDots[next_index, j].tag == sameTag)
                    {
                        //while if the color is the same, reomve the one that are the same
                        //and only keep the first one
                        while (next_index >= 0 && allDots[next_index, j].tag == sameTag)
                        {
                            //combine size add togather
                            Dot dot = allDots[i, j].GetComponent<Dot>();
                            Dot same_dot = allDots[next_index, j].GetComponent<Dot>();
                            dot.size += same_dot.size;
                            //destroy the dot that has been combine
                            Destroy(allDots[next_index, j]);
                            allDots[next_index, j] = null;
                            next_index--;
                        }
                        //do one match at a time
                        moveDown_n90(j);
                        break;
                    }
                }
            }


        }

    }
}
