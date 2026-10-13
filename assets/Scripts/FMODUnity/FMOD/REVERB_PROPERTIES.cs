namespace FMOD;

public struct REVERB_PROPERTIES(float decayTime, float earlyDelay, float lateDelay, float hfReference, float hfDecayRatio, float diffusion, float density, float lowShelfFrequency, float lowShelfGain, float highCut, float earlyLateMix, float wetLevel)
{
	public float DecayTime = decayTime;

	public float EarlyDelay = earlyDelay;

	public float LateDelay = lateDelay;

	public float HFReference = hfReference;

	public float HFDecayRatio = hfDecayRatio;

	public float Diffusion = diffusion;

	public float Density = density;

	public float LowShelfFrequency = lowShelfFrequency;

	public float LowShelfGain = lowShelfGain;

	public float HighCut = highCut;

	public float EarlyLateMix = earlyLateMix;

	public float WetLevel = wetLevel;
}
