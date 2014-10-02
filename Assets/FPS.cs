using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class FPS : MonoBehaviour 
{
	public GUIText fpsCounter;
	
	public int sampleFrames = 30;
	
	public int greenFrames = 60;
	public int yellowFrames = 40;
	
	List<float> frameTimes = new List<float>();
	
	private float fps;
	
	void Update () 
	{
		frameTimes.Add(Time.deltaTime);
		
		if (frameTimes.Count() == (sampleFrames -1))
		{
			DisplayAverageFPS();
			
			ChangeFrameColours();
			
			frameTimes.Clear();
		}
	}
	
	void DisplayAverageFPS()
	{
		fps = 1 / frameTimes.Average();
		
		fpsCounter.text = fps.ToString("F2");
	}
	
	void ChangeFrameColours()
	{
		if (fps >= greenFrames)
			fpsCounter.color = Color.green;
		else if (fps >= yellowFrames)
			fpsCounter.color = Color.yellow;
		else
			fpsCounter.color = Color.red;
	}
}