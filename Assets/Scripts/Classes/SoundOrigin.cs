using UnityEngine.Windows;


public enum PropagationShape { Bar, Cone, Circle };

public class SoundOrigin
{
	float strength;

	void Propagate()
	{
		// While the soundFile is playing, every 0.1 seconds, generate a new
		// SoundWave based on Propagation Shape.
		//
		// The sound origin automatically creates new waves around it,
		// based on the propagation shape (outwards cone for speaking,
		// circle for gunfire, dropped weapons, etc.
	}

	//public File soundFile;
}