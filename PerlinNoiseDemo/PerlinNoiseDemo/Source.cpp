#include "olcConsoleGameEngine.h"
#include <iostream>
#include <string>
#include <algorithm>

using namespace std;

class PerlinNoiseDemo : public olcConsoleGameEngine {
public:
	PerlinNoiseDemo() {
		appName = L"Perlin Noise";
	}

	~PerlinNoiseDemo() {}

private:
	int outputWidth = 256;
	int outputHeight = 256;
	float* noiseSeed2D = nullptr;
	float* perlinNoise2D = nullptr;

	float* noiseSeed1D = nullptr;
	float* perlinNoise1D = nullptr;
	int outputSize = 256;

	int octaveCount = 1;
	float scalingBias = 2.0f;

	int mode = 1;

	virtual bool OnUserCreate() {
		outputSize = ScreenWidth();
		noiseSeed1D = new float[outputSize];
		perlinNoise1D = new float[outputSize];

		for (int i = 0; i < outputSize; i++)
			noiseSeed1D[i] = (float)rand() / (float)RAND_MAX;

		outputWidth = ScreenWidth();
		outputHeight = ScreenHeight();

		noiseSeed2D = new float[outputWidth * outputHeight];
		perlinNoise2D = new float[outputWidth * outputHeight];

		for (int i = 0; i < outputWidth * outputHeight; i++)
			noiseSeed2D[i] = (float)rand() / (float)RAND_MAX;

		return true;
	}

	virtual bool OnUserUpdate(float elapsedTime) {
		Fill(0, 0, ScreenWidth(), ScreenHeight(), L' ');

		if (keys[VK_SPACE].released)
			octaveCount++;

		if (octaveCount == 9)
			octaveCount = 1;

		if (keys[L'Q'].released)
			scalingBias += 0.2f;

		if (keys[L'A'].released)
			scalingBias -= 0.2f;

		if (scalingBias < 0.2f)
			scalingBias = 0.2f;

		if (keys[L'1'].released)
			mode = 1;
		
		if (keys[L'2'].released)
			mode = 2;

		if (mode == 1) {
			if (keys[L'Z'].released)
				for (int i = 0; i < outputSize; i++)
					noiseSeed1D[i] = (float)rand() / (float)RAND_MAX;

			PerlinNoise1D(outputSize, noiseSeed1D, octaveCount, scalingBias, perlinNoise1D);

			for (int x = 0; x < outputSize; x++) {
				int y = -(perlinNoise1D[x] * (float)ScreenHeight() / 2.0f) + (float)ScreenHeight() / 2.0f;
				for (int f = y; f < ScreenHeight() / 2; f++)
					Draw(x, f, PIXEL_SOLID, FG_GREEN);

			}
		} else if (mode == 2) {
			if (keys[L'Z'].released)
				for (int i = 0; i < outputWidth * outputHeight; i++)
					noiseSeed2D[i] = (float)rand() / (float)RAND_MAX;

			PerlinNoise2D(outputWidth, outputHeight, noiseSeed2D, octaveCount, scalingBias, perlinNoise2D);

			for (int x = 0; x < outputWidth; x++) {
				for (int y = 0; y < outputHeight; y++) {
					short bgCol, fgCol;
					wchar_t sym;
					int pixelBw = (int)(perlinNoise2D[y * outputWidth + x] * 12.0f);
					switch (pixelBw) {
						case 0: bgCol = BG_BLACK; fgCol = FG_BLACK; sym = PIXEL_SOLID; break;

						case 1: bgCol = BG_BLACK; fgCol = FG_DARK_GREY; sym = PIXEL_QUARTER; break;
						case 2: bgCol = BG_BLACK; fgCol = FG_DARK_GREY; sym = PIXEL_HALF; break;
						case 3: bgCol = BG_BLACK; fgCol = FG_DARK_GREY; sym = PIXEL_THREEQUARTERS; break;
						case 4: bgCol = BG_BLACK; fgCol = FG_DARK_GREY; sym = PIXEL_SOLID; break;

						case 5: bgCol = BG_BLACK; fgCol = FG_GREY; sym = PIXEL_QUARTER; break;
						case 6: bgCol = BG_BLACK; fgCol = FG_GREY; sym = PIXEL_HALF; break;
						case 7: bgCol = BG_BLACK; fgCol = FG_GREY; sym = PIXEL_THREEQUARTERS; break;
						case 8: bgCol = BG_BLACK; fgCol = FG_GREY; sym = PIXEL_SOLID; break;

						case 9: bgCol = BG_BLACK; fgCol = FG_WHITE; sym = PIXEL_QUARTER; break;
						case 10: bgCol = BG_BLACK; fgCol = FG_WHITE; sym = PIXEL_HALF; break;
						case 11: bgCol = BG_BLACK; fgCol = FG_WHITE; sym = PIXEL_THREEQUARTERS; break;
						case 12: bgCol = BG_BLACK; fgCol = FG_WHITE; sym = PIXEL_SOLID; break;
					}

					Draw(x, y, sym, fgCol | bgCol);
				}
			}
		}

		return true;
	}

	void PerlinNoise1D(int count, float* seed, int octaves, float bias, float* output) {
		for (int x = 0; x < count; x++) {
			float noise = 0.0f;
			float scale = 1.0f;
			float scaleAcc = 0.0f;

			for (int o = 0; o < octaves; o++) {
				int pitch = count >> o;
				int sample1 = (x / pitch) * pitch;
				int sample2 = (sample1 + pitch) % count;

				float blend = (float)(x - sample1) / (float)pitch;

				float sample = (1.0f - blend) * seed[sample1] + blend * seed[sample2];

				noise += sample * scale;

				scaleAcc += scale;
				scale = scale / bias;
			}

			output[x] = noise / scaleAcc;
		}
	}

	void PerlinNoise2D(int width, int height, float* seed, int octaves, float bias, float* output) {
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				float noise = 0.0f;
				float scaleAcc = 0.0f;
				float scale = 1.0f;

				for (int o = 0; o < octaves; o++) {
					int pitch = width >> o;
					int sampleX1 = (x / pitch) * pitch;
					int sampleY1 = (y / pitch) * pitch;

					int sampleX2 = (sampleX1 + pitch) % width;
					int sampleY2 = (sampleY1 + pitch) % width;

					float blendX = (float)(x - sampleX1) / (float)pitch;
					float blendY = (float)(y - sampleY1) / (float)pitch;

					float sampleT = (1.0f - blendX) * seed[sampleY1 * width + sampleX1] + blendX * seed[sampleY1 * width + sampleX2];
					float sampleB = (1.0f - blendX) * seed[sampleY2 * width + sampleX1] + blendX * seed[sampleY2 * width + sampleX2];

					noise += (blendY * (sampleB - sampleT) + sampleT) * scale;

					scaleAcc += scale;
					scale = scale / bias;
				}

				output[y * width + x] = noise / scaleAcc;
			}
		}
	}

	void PerlinNoise2DJ9(int nWidth, int nHeight, float* fSeed, int nOctaves, float fBias, float* fOutput) {
		// Used 1D Perlin Noise
		for (int x = 0; x < nWidth; x++)
			for (int y = 0; y < nHeight; y++) {
				float fNoise = 0.0f;
				float fScaleAcc = 0.0f;
				float fScale = 1.0f;

				for (int o = 0; o < nOctaves; o++) {
					int nPitch = nWidth >> o;
					int nSampleX1 = (x / nPitch) * nPitch;
					int nSampleY1 = (y / nPitch) * nPitch;

					int nSampleX2 = (nSampleX1 + nPitch) % nWidth;
					int nSampleY2 = (nSampleY1 + nPitch) % nWidth;

					float fBlendX = (float)(x - nSampleX1) / (float)nPitch;
					float fBlendY = (float)(y - nSampleY1) / (float)nPitch;

					float fSampleT = (1.0f - fBlendX) * fSeed[nSampleY1 * nWidth + nSampleX1] + fBlendX * fSeed[nSampleY1 * nWidth + nSampleX2];
					float fSampleB = (1.0f - fBlendX) * fSeed[nSampleY2 * nWidth + nSampleX1] + fBlendX * fSeed[nSampleY2 * nWidth + nSampleX2];

					fScaleAcc += fScale;
					fNoise += (fBlendY * (fSampleB - fSampleT) + fSampleT) * fScale;
					fScale = fScale / fBias;
				}

				// Scale to seed range
				fOutput[y * nWidth + x] = fNoise / fScaleAcc;
			}

	}
};


int main() {
	PerlinNoiseDemo game;
	game.ConstructConsole(256, 256, 3, 3);
	game.Start();


	return 0;
}