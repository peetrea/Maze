using System.Collections;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public enum MazeGenerationAlgorithm
    {
        PureRecursive,
        RecursiveTree,
        RandomTree,
        OldestTree,
        RecursiveDivision,
    }

    public MazeGenerationAlgorithm Algorithm = MazeGenerationAlgorithm.PureRecursive;
    public bool FullRandom = false;
    public int RandomSeed = 12345;
    public GameObject Floor = null;
    public GameObject Wall = null;
    public GameObject Pillar = null;
    int Rows;
    int Columns;
    int Enemys;
    public float CellWidth = 5;
    public float CellHeight = 5;
    public bool AddGaps = true;
    public GameObject GoalPrefab = null;
    public GameObject FinishPrefab = null;
    public GameObject EnemyPrefab;

    private BasicMazeGenerator mMazeGenerator = null;

    void Start()
    {
        Rows = SaveSystem.LoadInt("Rows");
        Columns = SaveSystem.LoadInt("Columns");
        Enemys = SaveSystem.LoadInt("Enemys");
        for (int i = 0; i < Enemys; i++)
        {
            int randomRow = Random.Range(0, Rows);
            int randomColumn = Random.Range(0, Columns);
            float x = randomColumn * (CellWidth + (AddGaps ? 0.2f : 0));
            float z = randomRow * (CellHeight + (AddGaps ? 0.2f : 0));

            Instantiate(EnemyPrefab, new Vector3(x, 1f, z), Quaternion.identity);
        }
        if (!FullRandom)
        {
            Random.seed = RandomSeed;
        }
        switch (Algorithm)
        {
            case MazeGenerationAlgorithm.PureRecursive:
                mMazeGenerator = new RecursiveMazeGenerator(Rows, Columns);
                break;
            case MazeGenerationAlgorithm.RecursiveTree:
                mMazeGenerator = new RecursiveTreeMazeGenerator(Rows, Columns);
                break;
            case MazeGenerationAlgorithm.RandomTree:
                mMazeGenerator = new RandomTreeMazeGenerator(Rows, Columns);
                break;
            case MazeGenerationAlgorithm.OldestTree:
                mMazeGenerator = new OldestTreeMazeGenerator(Rows, Columns);
                break;
            case MazeGenerationAlgorithm.RecursiveDivision:
                mMazeGenerator = new DivisionMazeGenerator(Rows, Columns);
                break;
        }
        mMazeGenerator.GenerateMaze();
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                float x = column * (CellWidth + (AddGaps ? 0.2f : 0));
                float z = row * (CellHeight + (AddGaps ? 0.2f : 0));
                MazeCell cell = mMazeGenerator.GetMazeCell(row, column);
                GameObject tmp;
                tmp = Instantiate(Floor, new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0)) as GameObject;
                tmp.transform.parent = transform;
                if (cell.WallRight)
                {
                    tmp = Instantiate(Wall, new Vector3(x + CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 90, 0)) as GameObject;
                    tmp.transform.parent = transform;
                }
                if (cell.WallFront)
                {
                    tmp = Instantiate(Wall, new Vector3(x, 0, z + CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    tmp.transform.parent = transform;
                }
                if (cell.WallLeft)
                {
                    tmp = Instantiate(Wall, new Vector3(x - CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 270, 0)) as GameObject;
                    tmp.transform.parent = transform;
                }
                if (cell.WallBack)
                {
                    tmp = Instantiate(Wall, new Vector3(x, 0, z - CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
                    tmp.transform.parent = transform;
                }
                if (cell.IsGoal && GoalPrefab != null)
                {
                    tmp = Instantiate(GoalPrefab, new Vector3(x, 1, z), Quaternion.Euler(0, 0, 0)) as GameObject;
                    tmp.transform.parent = transform;
                }
            }
        }

        // Generați zona de finish aleator
        if (FinishPrefab != null)
        {
            int finishRow = Random.Range(0, Rows);
            int finishColumn = Random.Range(0, Columns);

            MazeCell finishCell = mMazeGenerator.GetMazeCell(finishRow, finishColumn);
            finishCell.IsGoal = true;

            float xFinish = finishColumn * (CellWidth + (AddGaps ? 0.2f : 0));
            float zFinish = finishRow * (CellHeight + (AddGaps ? 0.2f : 0));
            Instantiate(FinishPrefab, new Vector3(xFinish, 0.001f, zFinish), Quaternion.Euler(0, 0, 0));
        }

        if (Pillar != null)
        {
            for (int row = 0; row < Rows + 1; row++)
            {
                for (int column = 0; column < Columns + 1; column++)
                {
                    float x = column * (CellWidth + (AddGaps ? 0.2f : 0));
                    float z = row * (CellHeight + (AddGaps ? 0.2f : 0));
                    GameObject tmp = Instantiate(Pillar, new Vector3(x - CellWidth / 2, 0, z - CellHeight / 2), Quaternion.identity) as GameObject;
                    tmp.transform.parent = transform;
                }
            }
        }
    }
}
