using UnityEngine;

public class PieChartMeshController : MonoBehaviour
{
    PieChartMesh mPieChart;
    public float[] mData = new float[3];

	void OnGUI() {
		if (GUI.Button (new Rect (10, 1, 100, 90), "Increase Green")) {
			//mData[0]+=5;
			if (mData[0] < 99) {
				mData[0]+=1;
				mData[1]-=1;
				mData[2]-=1;
			}
			Draw();
		}
		if (GUI.Button (new Rect (10, 91, 100, 90), "Increase Blue")) {
			//mData[1]+=5;

			if (mData[1] < 99) {
				mData[0]-=1;
				mData[1]+=1;
				mData[2]-=1;
			}
			Draw();
		}
		if (GUI.Button (new Rect (10, 181, 100, 90), "Increase White")) {
			//mData[2]+=5;

			if (mData[2] < 99) {
				mData[0]-=1;
				mData[1]-=1;
				mData[2]+=1;
			}
			Draw();
		}
	}

    void Start()
    {
        mPieChart = gameObject.AddComponent("PieChartMesh") as PieChartMesh;
        if (mPieChart != null)
        {
            mPieChart.Init(mData, 100, 0, 100, null);
            mPieChart.Draw(mData);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            mData = GenerateRandomValues(3);
            mPieChart.Draw(mData);
        }
    }

	public void Draw()
	{
		mPieChart.Draw (mData);
	}

    float[] GenerateRandomValues(int length)
    {
        float[] targets = new float[length];

        for (int i = 0; i < length; i++)
        {
            targets[i] = Random.Range(0f, 100f);
        }
        return targets;
    }
}
