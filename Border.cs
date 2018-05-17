using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Border : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;
    public static int pause = 0;
    public int width;
    public int height;
    public int size = 5;
    //public GameObject tilePrefab;
    private GameObject[,] allTiles;
    public GameObject[] dots;
    public GameObject[,] allDots = new GameObject[5, 5];
    public static int[,] can_move = new int[5, 5];
    public int dotz;
    public int boardz;
    public Text scoreDisplay;
    public int greycombine = 0;
    public int newdot = 0;

    private int degree = 0;
    private int start_x = -2;
    private int start_y = -2;
    private int score = 0;
    private int combine = 0;
    private string score_str = "Score:  ";
    public static int rotating = 0;
    private int afterInit = 0;

    // Use this for initialization
    void Start () {
        
        //this.transform.Rotate(0, 0, 90, Space.World);
        Setup();
        init_has_move();
        //this.transform.Rotate(0, 0, 180, Space.World);
        // dataRotate_n90();

    }
	// Update is called once per frame
	void Update () {
        //Debug.Log(pause);

        //this.transform.Rotate(Vector3.right * Time.deltaTime);
        //StartCoroutine(combine_dots());

        //if (pause == 0)
        //{
        //if (combine == 1)

        //{
        
        wait();
    
        //}
    }

///////////////////////////////////////////////////////////////////////
    //add new dot within the empty space
    void addDots()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (allDots[i, j] == null)
                {
                    int fifity = UnityEngine.Random.Range(0, 2);
                    int dotToUse = 4;
                    if (fifity == 1)
                    {
                        dotToUse = UnityEngine.Random.Range(0, dots.Length - 1);
                    }
                    //int dotToUse = 4;
                    //get the gameobject location from the allDot location
                    //int[] curr_location = getLocation(col_location, j);
                    Vector3 tempPosition = new Vector3(i, j, dotz);
                    GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                    dot.transform.parent = this.transform;
                    dot.name = "(" + i + "," + j + "," + dotz + ")";
                    allDots[i, j] = dot;

                    j--;
                }
            }
        }
    }

    void changeColor()
    {
        //check if the color is grey
        //if the second dot is the same dot as the first
        //first find all the grey dot
        List<int> rowLst = new List<int>();
        List<int> colLst = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (allDots[i, j].tag == "Grey")
                {
                    rowLst.Add(i);
                    colLst.Add(j);
                }
            }
        }

        //if the list is larger than 2
        //find 2 spot for the dot change
        if (rowLst.Count > 2)
        {
            //find two different dot
            int firstDotIndex = UnityEngine.Random.Range(0, rowLst.Count);
            int secondDotIndex = UnityEngine.Random.Range(0, colLst.Count);
            while (firstDotIndex == secondDotIndex)
            {
                secondDotIndex = UnityEngine.Random.Range(0, colLst.Count);
            }
            int color = UnityEngine.Random.Range(0, 4);


            //change the first dot
            Destroy(allDots[rowLst[firstDotIndex], colLst[firstDotIndex]]);
            Vector3 tempPosition = new Vector3(rowLst[firstDotIndex], colLst[firstDotIndex], dotz);
            GameObject dot = Instantiate(dots[color], tempPosition, Quaternion.identity);
            dot.transform.parent = this.transform;
            dot.name = "(" + rowLst[firstDotIndex] + "," + colLst[firstDotIndex] + "," + dotz + ")";
            allDots[rowLst[firstDotIndex], colLst[firstDotIndex]] = dot;

            //change the second dot
            Destroy(allDots[rowLst[secondDotIndex], colLst[secondDotIndex]]);
            tempPosition = new Vector3(rowLst[secondDotIndex], colLst[secondDotIndex], dotz);
            dot = Instantiate(dots[color], tempPosition, Quaternion.identity);
            dot.transform.parent = this.transform;
            dot.name = "(" + rowLst[secondDotIndex] + "," + colLst[secondDotIndex] + "," + dotz + ")";
            allDots[rowLst[secondDotIndex], colLst[secondDotIndex]] = dot;


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
                    if (sameTag == "Grey" && greycombine == 0)
                    {

                    }
                    //find if there is the same color 
                    else if (next_index <= 4 && allDots[i, next_index].tag == sameTag)
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
                            Destroy(same_dot);
                            Destroy(allDots[i, next_index]);
                            //same_dot.newx = i;
                            //same_dot.newy = j;
                            //same_dot.distroy = 1;
                            allDots[i, next_index] = null;
                            next_index++;
                        }
                        //do one match at a time
                        //StartCoroutine(moveDown(i));

                        //moveDown(i);
                        //change the color of two dots, when the color dots combine
                        if (sameTag != "Grey")
                        {
                            changeColor();
                        }
                        //yield return new WaitForSeconds(2);
                        break;
                    }


                }
            }
        }
        greycombine = 0;

    }

    void combine_dotsHelper()
    {

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (allDots[i, j] != null)
                {

                    Dot dot = allDots[i, j].GetComponent<Dot>();
                    int next_index = j + 1;
                    //while if the color is the same, reomve the one that are the same
                    //and only keep the first one
                    //Debug.Log("location" + i + next_index);
                    //Debug.Log("this is the object" + allDots[i, next_index]);
                    while (next_index < 5 && allDots[i, next_index].tag == dot.tag)

                    {
                        Debug.Log("this is next index " + next_index);
                        //combine size add togather

                        Dot same_dot = allDots[i, next_index].GetComponent<Dot>();
                        dot.size += same_dot.size;
                        //destory the dot that has been combine
                        //Destroy(same_dot);
                        //Destroy(allDots[i, next_index]);
                        //same_dot.newx = i;
                        //same_dot.newy = j;
                        same_dot.distroy = 1;
                        //allDots[i, next_index] = null;
                        next_index++;
                    }
                }
            }
        }
    }

    //destroy the dot in the data
    public void destroyDot()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (allDots[i, j].GetComponent<Dot>().distroy == 1)
                {
                    Destroy(allDots[i, j].GetComponent<Dot>());
                    Destroy(allDots[i, j]);
                    allDots[i, j] = null;
                }
            }
        }
    }

    //drop the dots if it is in the correct opening
    private void drop()
    {
        if (allDots[1, 0].tag != "Grey")
        {
               drop_helper();
        }
        else
        {
            //if it is green and it the correct location
            if (allDots[1, 0].tag == "Green" && (int)this.transform.rotation.eulerAngles.z == 0)
            {
                drop_helper();
            }
            else if (allDots[1, 0].tag == "Yellow" && (int)this.transform.rotation.eulerAngles.z == 270)
            {
                drop_helper();
            }
            else if (allDots[1, 0].tag == "Red" && (int)this.transform.rotation.eulerAngles.z == 90)
            {
                drop_helper();
            }
            else if (allDots[1, 0].tag == "Blue" && (int)this.transform.rotation.eulerAngles.z == 180)
            {
                drop_helper();
            }
        }
    }

    //do the drop motion and other task
    private void drop_helper()
    {
        score += allDots[1, 0].GetComponent<Dot>().size;
        allDots[1, 0].GetComponent<CircleCollider2D>().enabled = true;
        allDots[1, 0].GetComponent<Rigidbody2D>().gravityScale = 5;
        allDots[1, 0] = null;
        moveDown(1);
    }

    //rotate the data set 90 degree
    private void dataRotate_90()
    {
        GameObject[,] new_allDots = new GameObject[5, 5];
        int i = 0;
        int j = 0;
        int new_i = 0;
        int new_j = 4;

        while (i < 5 && new_j >= 0)
        {
            while (j < 5 && new_i < 5)
            {
                new_allDots[i, j] = allDots[new_i, new_j];
                j++;
                new_i++;
            }
            //reset
            j = 0;
            new_i = 0;
            //increment
            i++;
            new_j--;
        }
        allDots = new_allDots;
    }

    //rotate the data set -90 degree
    private void dataRotate_n90()
    {
        GameObject[,] new_allDots = new GameObject[5, 5];
        int i = 0;
        int j = 0;
        int new_i = 4;
        int new_j = 0;

        while (i < 5 && new_j < 5)
        {
            while (j < 5 && new_i >= 0)
            {
                //Debug.Log(allDots[new_i, new_j]);
                new_allDots[i, j] = allDots[new_i, new_j];
                //increment
                j++;
                new_i--;
            }
            //reset
            new_i = 4;
            j = 0;
            //increment
            i++;
            new_j++;
        }
        for (int i1 = 0; i1 < 5; i1++)
        {
            for (int i2 = 0; i2 < 5; i2++)
            {
                //Debug.Log(new_allDots[i1, i2]);
                //Debug.Log("this is debug");
            }
        }
        allDots = new_allDots;
    }

    private int hasPauseGame()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                //Debug.Log(can_move.Length);
                if (allDots[i, j] != null)
                {
                    Dot dot = allDots[i, j].GetComponent<Dot>();

                    if (dot.pause_game == 1)
                    {
                        return 1;
                    }
                }
            }
        }
        return 0;
    }

    public void init_has_move()
    {
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                can_move[i, j] = 0;
                //Debug.Log(can_move[i, j]);
            }
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
                //create new vector
                Vector3 new_location = new Vector3(col_location, j - total_null, dotz);
                Dot same_dot = allDots[col_location, j].GetComponent<Dot>();
                //get the previous location for lerp movement
                Vector3 prev_location = same_dot.transform.position;
                same_dot.newx = new_location.x;
                same_dot.newy = new_location.y;
                same_dot.pause_game = 1;
                same_dot.set_space(10);
                StartCoroutine(same_dot.activate_moveDot());
                //allDots[col_location, j].transform.position = Vector3.Lerp(prev_location, new_location, .4f);
                //move the dot to the updated position
                //allDots[col_location, j].transform.position = new_location;
                //set the object into the new location of allDot
                same_dot.dataIndexX = col_location;
                same_dot.dataIndexY = j - total_null;
                //while(hasPauseGame() == 1)
                //{
                //}
                allDots[col_location, j - total_null] = allDots[col_location, j];
                allDots[col_location, j] = null;

            }
            j++;
        }
        j = 4;

        /*
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
        */

        addDots();
    }

    private void moveDown2()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                int nullcount = 0;
                if(allDots[i, j] == null)
                {
                    nullcount++;
                }else if(nullcount > 0)
                {
                    
                    Dot dot = allDots[i, j].GetComponent<Dot>();
                    dot.newx = i;
                    dot.newy = j - nullcount;
                    dot.pause_game = 1;
                    dot.set_space(10);
                    StartCoroutine(dot.activate_moveDot());
                    allDots[i, j - nullcount] = allDots[i, j];
                    allDots[i, j] = null;
                }
            }
        }
    }

    void print_dot()
    {
        //Debug.Log("this is the dot list");
        for (int i1 = 0; i1 < 5; i1++)
        {
            string line = "";
            for (int i2 = 0; i2 < 5; i2++)
            {
                line += " " + "(";
                //Debug.Log(line);
            }
        }
    }

    //rotate the whole box
    IEnumerator rotate()
    {
        if(Input.GetMouseButtonUp(0)){
           
            // this.transform.Rotate(0, 0, -90, Space.World);
            // screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            // Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z - 1);
            //Debug.Log(Input.mousePosition.x);
            
            if (Input.mousePosition.x >= 130)
            {
                //  while (this.gameObject.transform.rotation.z != this.gameObject.transform.rotation.z + 90)
                //Debug.Log("greather than 130");
                //this.transform.Rotate(0, 0, -90, Space.World);
                StartCoroutine(slowDownRotation(-90));
                yield return new WaitForSeconds(.5f);
                dataRotate_n90();
                greycombine = 1;
                afterInit = 1;
            }
            else if (Input.mousePosition.x < 130)
            {
                // while (this.gameObject.transform.rotation.z != this.gameObject.transform.rotation.z - 90)
                //Debug.Log("less than 130");
                //this.transform.Rotate(0, 0, 90, Space.World);
                StartCoroutine(slowDownRotation(90));
                yield return new WaitForSeconds(.5f);
                dataRotate_90();
                greycombine = 1;
                afterInit = 1;
            }
            // Debug.Log("this is rotation" + (int)this.transform.rotation.eulerAngles.z);
            //Debug.Log(allDots[0, 0].tag);
        }
        rotating = 0;
    }

    //update the score
    public void ScoreUpdate()
    {
        scoreDisplay.text = score_str + score.ToString();
    }

    IEnumerator slowDownRotation(int degree)
    {
        int angle = degree / 5;
        int a = 0;
        rotating = 1;
        while (a < 5)
        {
            this.transform.Rotate(0, 0, angle, Space.World);
            a++;
            yield return new WaitForSeconds(.01f);
        }
        
    }

    private void Setup()
    {
        allDots = new GameObject[width, height];

        addDots();
        changeColor();
    }

    //testing code, happen on click
    void test()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("press");
            combine_dotsHelper();

            moveDown2();
        }
    }
    
    //initial setup
    void wait()
    {
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                if (rotating == 1 || (allDots[i, j] != null &&
                    allDots[i,j].GetComponent<Dot>().pause_game == 1)
                    )
                {
                    return;
                }
            }
        }
        if (rotating == 0)
        {
            StartCoroutine(rotate());
        }
        //rotate();
        //if(rotating == 1)
        //{
        //    return;
        //}

        if (afterInit == 1)
        {
            //combine_dots();
            combine_dotsHelper();
            destroyDot();
            moveDown2();
            //
            //}
            //test();
            //chosse_combine_dot();
            //drop();
            //ScoreUpdate();
            //addDots();
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
