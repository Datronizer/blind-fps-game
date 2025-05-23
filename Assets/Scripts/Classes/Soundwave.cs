public class Soundwave
{
    const float BASE_SPEED_OF_SOUND = 331.0f;  // Measured in m/s, in dry air, at 0 Celsius
    

    void Bounce()
    {
        // If the soundwave hits a surface, it creates a new sound wave at that surface
        // But with only the remaining energy - energy absorbed by surface
        //
        // All Bounced SoundWaves are shaped by the shape of obstruction
        // they hit (e.g. Fan for flat surfaces.
    }

    void Absorb()
    {
        // The sound wave's energy is absorbed based on the surface hit
    }
}