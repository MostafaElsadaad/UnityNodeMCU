#define Graph_And_Chart_PRO
using ChartAndGraph;
using UnityEngine;

public class StreamingGraph : MonoBehaviour {
    public GraphChart Graph;
    public GraphChart Graph2;
    public GraphChart Graph3;
    public GraphChart Graphx;
    public GraphChart Graph2x;
    public GraphChart Graph3x;
    public int TotalPoints = 5;
    float lastTime = 0f;
    float lastX = 0f;
    float lastTime2 = 0f;
    float lastX2 = 0f;
    float lastTime3 = 0f;
    float lastX3 = 0f;
    //---------
    float lastTimex = 0f;
    float lastXx = 0f;
    float lastTime2x = 0f;
    float lastX2x = 0f;
    float lastTime3x = 0f;
    float lastX3x = 0f;
    public Databasemanager dbm;
    void Start() {
        if (Graph == null) // the ChartGraph info is obtained via the inspector
            return;
        float x = 3f * TotalPoints;
        Graph.DataSource.StartBatch(); // calling StartBatch allows changing the graph data without redrawing the graph for every change
        Graph.DataSource.ClearCategory("Player 1"); // clear the "Player 1" category. this category is defined using the GraphChart inspector
                                                       //Graph.DataSource.ClearCategory("Player 2"); // clear the "Player 2" category. this category is defined using the GraphChart inspector

        Graph2.DataSource.StartBatch(); // calling StartBatch allows changing the graph data without redrawing the graph for every change
        Graph2.DataSource.ClearCategory("Player 1"); // clear the "Player 1" category. this category is defined using the GraphChart inspector

        Graph3.DataSource.StartBatch(); // calling StartBatch allows changing the graph data without redrawing the graph for every change
        Graph3.DataSource.ClearCategory("Player 1"); // clear the "Player 1" category. this category is defined using the GraphChart inspector

        Graphx.DataSource.StartBatch(); // calling StartBatch allows changing the graph data without redrawing the graph for every change
        Graphx.DataSource.ClearCategory("Player 1"); // clear the "Player 1" category. this category is defined using the GraphChart inspector
                                                    //Graph.DataSource.ClearCategory("Player 2"); // clear the "Player 2" category. this category is defined using the GraphChart inspector

        Graph2x.DataSource.StartBatch(); // calling StartBatch allows changing the graph data without redrawing the graph for every change
        Graph2x.DataSource.ClearCategory("Player 1"); // clear the "Player 1" category. this category is defined using the GraphChart inspector

        Graph3x.DataSource.StartBatch(); // calling StartBatch allows changing the graph data without redrawing the graph for every change
        Graph3x.DataSource.ClearCategory("Player 1"); // clear the "Player 1" category. this category is defined using the GraphChart inspector


        Graph.DataSource.AddPointToCategory("Player 1", System.DateTime.Now - System.TimeSpan.FromSeconds(x), 15); // each time we call AddPointToCategory 
        Graph2.DataSource.AddPointToCategory("Player 1", System.DateTime.Now - System.TimeSpan.FromSeconds(x), 20);
        Graph3.DataSource.AddPointToCategory("Player 1", System.DateTime.Now - System.TimeSpan.FromSeconds(x), 0);

        Graphx.DataSource.AddPointToCategory("Player 1", System.DateTime.Now - System.TimeSpan.FromSeconds(x), 15); // each time we call AddPointToCategory 
        Graph2x.DataSource.AddPointToCategory("Player 1", System.DateTime.Now - System.TimeSpan.FromSeconds(x), 20);
        Graph3x.DataSource.AddPointToCategory("Player 1", System.DateTime.Now - System.TimeSpan.FromSeconds(x), 0);


        Graph.DataSource.AddPointToCategory("Player 1", System.DateTime.Now - System.TimeSpan.FromSeconds(x), 40); // each time we call AddPointToCategory 
        Graph2.DataSource.AddPointToCategory("Player 1", System.DateTime.Now - System.TimeSpan.FromSeconds(x), 100);
        Graph3.DataSource.AddPointToCategory("Player 1", System.DateTime.Now - System.TimeSpan.FromSeconds(x), 10);
        
        Graphx.DataSource.AddPointToCategory("Player 1", System.DateTime.Now - System.TimeSpan.FromSeconds(x), 40); // each time we call AddPointToCategory 
        Graph2x.DataSource.AddPointToCategory("Player 1", System.DateTime.Now - System.TimeSpan.FromSeconds(x), 100);
        Graph3x.DataSource.AddPointToCategory("Player 1", System.DateTime.Now - System.TimeSpan.FromSeconds(x), 10);




        Graph.DataSource.EndBatch(); // finally we call EndBatch , this will cause the GraphChart to redraw itself
        Graph2.DataSource.EndBatch();                         // Graph2.DataSource.EndBatch();
        Graph3.DataSource.EndBatch();
        
        Graphx.DataSource.EndBatch(); // finally we call EndBatch , this will cause the GraphChart to redraw itself
        Graph2x.DataSource.EndBatch();                         // Graph2.DataSource.EndBatch();
        Graph3x.DataSource.EndBatch();
    }

    void Update() {
        float time = Time.time;
        if (lastTime + 2f < time) {
            lastTime = time;
            lastX += Random.value * 3f;
            Graph.DataSource.AddPointToCategoryRealtime("Player 1", System.DateTime.Now, dbm.temp, 1f); // each time we call AddPointToCategory 

        }

        if (lastTime2 + 2f < time) {
            lastTime2 = time;
            lastX2 += Random.value * 3f;
            //            System.DateTime t = ChartDateUtility.ValueToDate(lastX);
            Graph2.DataSource.AddPointToCategoryRealtime("Player 1", System.DateTime.Now, dbm.humi, 1f); // each time we call AddPointToCategory 
        }

        if (lastTime3 + 2f < time) {
            lastTime3 = time;
            lastX3 += Random.value * 3f;
            //            System.DateTime t = ChartDateUtility.ValueToDate(lastX);
            Graph3.DataSource.AddPointToCategoryRealtime("Player 1", System.DateTime.Now, dbm.water, 1f); // each time we call AddPointToCategory 
        }
        //-------------------------------------------------------------clones

        if (lastTimex + 2f < time) {
            lastTimex = time;
            lastXx += Random.value * 3f;
            Graphx.DataSource.AddPointToCategoryRealtime("Player 1", System.DateTime.Now, dbm.temp, 1f); // each time we call AddPointToCategory 

        }

        if (lastTime2x + 2f < time) {
            lastTime2x = time;
            lastX2x += Random.value * 3f;
            //            System.DateTime t = ChartDateUtility.ValueToDate(lastX);
            Graph2x.DataSource.AddPointToCategoryRealtime("Player 1", System.DateTime.Now, dbm.humi, 1f); // each time we call AddPointToCategory 
        }

        if (lastTime3x + 2f < time) {
            lastTime3x = time;
            lastX3x += Random.value * 3f;
            //            System.DateTime t = ChartDateUtility.ValueToDate(lastX);
            Graph3x.DataSource.AddPointToCategoryRealtime("Player 1", System.DateTime.Now, dbm.water, 1f); // each time we call AddPointToCategory 
        }


    }
}
