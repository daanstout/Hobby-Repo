/*
	This engine was written by:
	OneLoneCoder - Javidx9

	This engine is originally copyrighted by him

	License
	~~~~~~~
	One Lone Coder Console Game Engine  Copyright (C) 2018  Javidx9
	This program comes with ABSOLUTELY NO WARRANTY.
	This is free software, and you are welcome to redistribute it
	under certain conditions; See license for details.
	Original works located at:
		https://www.github.com/onelonecoder
		https://www.onelonecoder.com
		https://www.youtube.com/javidx9
	GNU GPLv3
		https://github.com/OneLoneCoder/videos/blob/master/LICENSE
	From Javidx9 :)
	~~~~~~~~~~~~~~~
	Hello! Ultimately I don't care what you use this for. It's intended to be
	educational, and perhaps to the oddly minded - a little bit of fun.
	Please hack this, change it and use it in any way you see fit. You acknowledge
	that I am not responsible for anything bad that happens as a result of
	your actions. However this code is protected by GNU GPLv3, see the license in the
	github repo. This means you must attribute me if you use it. You can view this
	license here: https://github.com/OneLoneCoder/videos/blob/master/LICENSE
	Cheers!
	Background
	~~~~~~~~~~
	If you've seen any of my videos - I like to do things using the windows console. It's quick
	and easy, and allows you to focus on just the code that matters - ideal when you're 
	experimenting. Thing is, I have to keep doing the same initialisation and display code
	each time, so this class wraps that up.
	Author
	~~~~~~
	Twitter: @javidx9	http://twitter.com/javidx9
	Blog:				http://www.onelonecoder.com
	YouTube:			http://www.youtube.com/javidx9
	Videos:
	~~~~~~
	Original:				https://youtu.be/cWc0hgYwZyc
	Added mouse support:	https://youtu.be/tdqc9hZhHxM
	Beginners Guide:		https://youtu.be/u5BhrA8ED0o
	Shout Outs!
	~~~~~~~~~~~
	Thanks to cool people who helped with testing, bug-finding and fixing!
	wowLinh, JavaJack59, idkwid, kingtatgi, Return Null, CPP Guy, MaGetzUb
	Last Updated: 02/07/2018


	I do not own anything written here

*/


#pragma once
#pragma comment(lib, "winmm.lib")

#ifndef UNICODE
#error Please enable UNICODE for your compiler! VS: Project Properties -> General -> Advanced -> Character Set -> Use Unicode. Thanks!
#endif // !UNICODE

#include <Windows.h>

#include <iostream>
#include <chrono>
#include <vector>
#include <list>
#include <thread>
#include <atomic>
#include <condition_variable>

enum COLOUR {
	// Foregrounds
	FG_BLACK = 0x0000,
	FG_DARK_BLUE = 0x0001,
	FG_DARK_GREEN = 0x0002,
	FG_DARK_CYAN = 0x0003,
	FG_DARK_RED = 0x0004,
	FG_DARK_MAGENTA = 0x0005,
	FG_DARK_YELLOW = 0x0006,
	FG_GREY = 0x0007,
	FG_DARK_GREY = 0x0008,
	FG_BLUE = 0x0009,
	FG_GREEN = 0x000A,
	FG_CYAN = 0x000B,
	FG_RED = 0x000C,
	FG_MAGENTA = 0x000D,
	FG_YELLOW = 0x000E,
	FG_WHITE = 0x000F,

	// Backgrounds
	BG_BLACK = 0x0000,
	BG_DARK_BLUE = 0x0010,
	BG_DARK_GREEN = 0x0020,
	BG_DARK_CYAN = 0x0030,
	BG_DARK_RED = 0x0040,
	BG_DARK_MAGENTA = 0x0050,
	BG_DARK_YELLOW = 0x0060,
	BG_GREY = 0x0070,
	BG_DARK_GREY = 0x0080,
	BG_BLUE = 0x0090,
	BG_GREEN = 0x00A0,
	BG_CYAN = 0x00B0,
	BG_RED = 0x00C0,
	BG_MAGENTA = 0x00D0,
	BG_YELLOW = 0x00E0,
	BG_WHITE = 0x00F0,
};

enum PIXEL_TYPE {
	PIXEL_SOLID = 0x2588,
	PIXEL_THREEQUARTERS = 0x2593,
	PIXEL_HALF = 0x2592,
	PIXEL_QUARTER = 0x2591,
};

class olcSprite {
public:
	// =====CONSTRUCTORS=====
	olcSprite() {}

	olcSprite(int w, int h) { Create(w, h); }

	olcSprite(std::wstring file) {
		if (!Load(file))
			Create(8, 8);
	}

	// =====VARIABLES========
	int width = 0;
	int height = 0;

	// =====FUNCTIONS========
	void SetGlyph(int x, int y, short c) {
		if (x < 0 || x >= width || y < 0 || y >= height)
			return;
		else
			glyphs[y * width + x] = c;
	}

	void SetColour(int x, int y, short c) {
		if (x < 0 || x >= width || y < 0 || y >= height)
			return;
		else
			colours[y * width + x] = c;
	}

	short GetGlyph(int x, int y) {
		if (x < 0 || x >= width || y < 0 || y >= height)
			return L' ';
		else
			return glyphs[y * width + x];
	}

	short GetColour(int x, int y) {
		if (x < 0 || x >= width || y < 0 || y >= height)
			return FG_BLACK;
		else
			return colours[y * width + x];
	}

	short SampleGlyph(float x, float y) {
		int sx = (int)(x * (float)width);
		int sy = (int)(y * (float)height - 1.0f);
		if (sx < 0 || sx >= width || sy < 0 || sy > height)
			return L' ';
		else
			return glyphs[sy * width + sx];
	}

	short SampleColour(float x, float y) {
		int sx = (int)(x * (float)width);
		int sy = (int)(y * (float)height - 1.0f);
		if (sx < 0 || sx >= width || sy < 0 || sy > height)
			return FG_BLACK;
		else
			return colours[sy * width + sx];
	}

	bool Save(std::wstring file) {
		FILE* f = nullptr;
		_wfopen_s(&f, file.c_str(), L"wb");

		if (f == nullptr)
			return false;

		fwrite(&width, sizeof(int), 1, f);
		fwrite(&height, sizeof(int), 1, f);
		fwrite(colours, sizeof(short), width * height, f);
		fwrite(glyphs, sizeof(short), width * height, f);

		fclose(f);

		return true;
	}

	bool Load(std::wstring file) {
		delete[] glyphs;
		delete[] colours;
		width = 0;
		height = 0;

		FILE* f = nullptr;
		_wfopen_s(&f, file.c_str(), L"rb");

		if (f == nullptr)
			return false;

		std::fread(&width, sizeof(int), 1, f);
		std::fread(&height, sizeof(int), 1, f);

		Create(width, height);

		std::fread(colours, sizeof(short), width * height, f);
		std::fread(glyphs, sizeof(short), width * height, f);

		std::fclose(f);

		return true;
	}

private:
	// =====VARIABLES========
	short* glyphs = nullptr;
	short* colours = nullptr;

	// =====FUNCTIONS========
	void Create(int w, int h) {
		width = w;
		height = h;
		glyphs = new short[w * h];
		colours = new short[w * h];

		for (int i = 0; i < w * h; i++) {
			glyphs[i] = L' ';
			colours[i] = FG_BLACK;
		}
	}
};

class olcConsoleGameEngine {
public:
	// =====CONSTRUCTORS=====
	olcConsoleGameEngine() {
		screenWidth = 80;
		screenHeight = 30;

		console = GetStdHandle(STD_OUTPUT_HANDLE);
		consoleIn = GetStdHandle(STD_INPUT_HANDLE);

		std::memset(keyNewState, 0, 256 * sizeof(short));
		std::memset(keyOldState, 0, 256 * sizeof(short));
		std::memset(keys, 0, 256 * sizeof(short));

		mousePosX = 0;
		mousePosY = 0;

		enableSound = false;

		appName = L"Default";
	}

	// =====FUNCTIONS========
	void EnableSound() {
		enableSound = true;
	}

	int ConstructConsole(int width, int height, int fontWidth, int fontHeight) {
		if (console == INVALID_HANDLE_VALUE)
			return Error(L"Bad Handle");

		screenWidth = width;
		screenHeight = height;

		// Change console visual size to a minimum so ScreenBuffer can shrink below the actual visual size
		rectWindow = {0, 0, 1, 1};
		SetConsoleWindowInfo(console, TRUE, &rectWindow);

		// Set the size of the screen buffer
		COORD coord = {(short)screenWidth, (short)screenHeight};
		if (!SetConsoleScreenBufferSize(console, coord))
			Error(L"SetConsoleScreenBufferSize");

		// Assign screen buffer to the console
		if (!SetConsoleActiveScreenBuffer(console))
			return Error(L"SetConsoleActiveScreenBuffer");

		// Set the font size now that the screen buffer has been assigned to the console
		CONSOLE_FONT_INFOEX cfi;
		cfi.cbSize = sizeof(cfi);
		cfi.nFont = 0;
		cfi.dwFontSize.X = fontWidth;
		cfi.dwFontSize.Y = fontHeight;
		cfi.FontFamily = FF_DONTCARE;
		cfi.FontWeight = FW_NORMAL;

		wcscpy_s(cfi.FaceName, L"Consolas");
		if (!SetCurrentConsoleFontEx(console, false, &cfi))
			return Error(L"SetCurrentConsoleFontEx");

		// Get screen buffer info and check the maximum allowed window size
		// Return error if exceeded, so user knows their dimensions/fontsize are too large
		CONSOLE_SCREEN_BUFFER_INFO csbi;
		if (!GetConsoleScreenBufferInfo(console, &csbi))
			return Error(L"GetConsoleScreenBufferInfo");
		if (screenHeight > csbi.dwMaximumWindowSize.Y)
			return Error(L"Screen Height / Font Height Too Big");
		if (screenWidth > csbi.dwMaximumWindowSize.X)
			return Error(L"Screen Width / Font Width Too Big");

		// Set Physical Console Window Size
		rectWindow = {0, 0, (short)screenWidth - 1, (short)screenHeight - 1};
		if (!SetConsoleWindowInfo(console, TRUE, &rectWindow))
			return Error(L"SetConsoleWindowInfo");

		// Set flags to allow mouse input
		if (!SetConsoleMode(consoleIn, ENABLE_EXTENDED_FLAGS | ENABLE_WINDOW_INPUT | ENABLE_MOUSE_INPUT))
			return Error(L"SetConsoleWindowInfo");

		// Allocate memory for screen buffer
		bufferScreen = new CHAR_INFO[screenWidth * screenHeight];
		memset(bufferScreen, 0, sizeof(CHAR_INFO) * screenWidth * screenHeight);

		SetConsoleCtrlHandler((PHANDLER_ROUTINE)CloseHandler, TRUE);
		return 1;
	}

	//		=====DRAWING==========

	virtual void Draw(int x, int y, short c = 0x2588, short col = 0x000F) {
		if (x >= 0 && x < screenWidth && y >= 0 && y < screenHeight) {
			bufferScreen[y * screenWidth + x].Char.UnicodeChar = c;
			bufferScreen[y * screenWidth + x].Attributes = col;
		}
	}

	void Fill(int x1, int y1, int x2, int y2, short c = 0x2588, short col = 0x000F) {
		Clip(x1, y1);
		Clip(x2, y2);
		for (int x = x1; x < x2; x++)
			for (int y = y1; y < y2; y++)
				Draw(x, y, c, col);
	}

	void DrawStringAlpha(int x, int y, std::wstring c, short col = 0x000F) {
		for (size_t i = 0; i < c.size(); i++) {
			if (c[i] != L' ') {
				bufferScreen[y * screenWidth + x + i].Char.UnicodeChar = c[i];
				bufferScreen[y * screenWidth + x + i].Attributes = col;
			}
		}
	}

	void Clip(int& x, int& y) {
		if (x < 0) x = 0;
		if (x >= screenWidth) x = screenWidth;
		if (y < 0) y = 0;
		if (y > screenHeight) y = screenHeight;
	}

	void DrawLine(int x1, int y1, int x2, int y2, short c = 0x2588, short col = 0x000F) {
		int x, y, dx, dy, dx1, dy1, px, py, xe, ye, i;
		dx = x2 - x1; dy = y2 - y1;
		dx1 = abs(dx); dy1 = abs(dy);
		px = 2 * dy1 - dx1; py = 2 * dx1 - dy1;

		if (dy1 < dx1) {
			if (dx >= 0) {
				x = x1, y = y1, xe = x2;
			} else {
				x = x2; y = y2; xe = x1;
			}

			Draw(x, y, c, col);

			for (i = 0; x < xe; i++) {
				x++;
				if (px < 0)
					px = px + 2 * dy1;
				else {
					if ((dx < 0 && dy < 0) || (dx > 0 && dy > 0)) y++; else y--;
					px = px + 2 * (dy1 - dx1);
				}
			}
		} else {
			if (dy >= 0) {
				x = x1; y = y1; ye = y2;
			} else {
				x = x2; y = y2; ye = y1;
			}

			Draw(x, y, c, col);

			for (i = 0; y < ye; i++) {
				y = y + 1;
				if (py <= 0)
					py = py + 2 * dx1;
				else {
					if ((dx < 0 && dy < 0) || (dx > 0 && dy > 0)) x = x + 1; else x = x - 1;
					py = py + 2 * (dx1 - dy1);
				}
				Draw(x, y, c, col);
			}
		}
	}

	void DrawTriangle(int x1, int y1, int x2, int y2, int x3, int y3, short c = 0x2588, short col = 0x000F) {
		DrawLine(x1, y1, x2, y2, c, col);
		DrawLine(x2, y2, x3, y3, c, col);
		DrawLine(x3, y3, x1, y1, c, col);
	}

	// https://www.avrfreaks.net/sites/default/files/triangles.c
	void FillTriangle(int x1, int y1, int x2, int y2, int x3, int y3, short c = 0x2588, short col = 0x000F) {
		auto SWAP = [](int& x, int& y) { int t = x; x = y; y = t; };
		auto drawline = [&](int sx, int ex, int ny) { for (int i = sx; i <= ex; i++) Draw(i, ny, c, col); };

		int t1x, t2x, y, minx, maxx, t1xp, t2xp;
		bool changed1 = false;
		bool changed2 = false;
		int signx1, signx2, dx1, dy1, dx2, dy2;
		int e1, e2;
		// Sort vertices
		if (y1 > y2) { SWAP(y1, y2); SWAP(x1, x2); }
		if (y1 > y3) { SWAP(y1, y3); SWAP(x1, x3); }
		if (y2 > y3) { SWAP(y2, y3); SWAP(x2, x3); }

		t1x = t2x = x1; y = y1;   // Starting points
		dx1 = (int)(x2 - x1); if (dx1 < 0) { dx1 = -dx1; signx1 = -1; } else signx1 = 1;
		dy1 = (int)(y2 - y1);

		dx2 = (int)(x3 - x1); if (dx2 < 0) { dx2 = -dx2; signx2 = -1; } else signx2 = 1;
		dy2 = (int)(y3 - y1);

		if (dy1 > dx1) {   // swap values
			SWAP(dx1, dy1);
			changed1 = true;
		}
		if (dy2 > dx2) {   // swap values
			SWAP(dy2, dx2);
			changed2 = true;
		}

		e2 = (int)(dx2 >> 1);
		// Flat top, just process the second half
		if (y1 == y2) goto next;
		e1 = (int)(dx1 >> 1);

		for (int i = 0; i < dx1;) {
			t1xp = 0; t2xp = 0;
			if (t1x < t2x) { minx = t1x; maxx = t2x; } else { minx = t2x; maxx = t1x; }
			// process first line until y value is about to change
			while (i < dx1) {
				i++;
				e1 += dy1;
				while (e1 >= dx1) {
					e1 -= dx1;
					if (changed1) t1xp = signx1;//t1x += signx1;
					else          goto next1;
				}
				if (changed1) break;
				else t1x += signx1;
			}
			// Move line
next1:
			// process second line until y value is about to change
			while (1) {
				e2 += dy2;
				while (e2 >= dx2) {
					e2 -= dx2;
					if (changed2) t2xp = signx2;//t2x += signx2;
					else          goto next2;
				}
				if (changed2)     break;
				else              t2x += signx2;
			}
next2:
			if (minx > t1x) minx = t1x; if (minx > t2x) minx = t2x;
			if (maxx < t1x) maxx = t1x; if (maxx < t2x) maxx = t2x;
			drawline(minx, maxx, y);    // Draw line from min to max points found on the y
										 // Now increase y
			if (!changed1) t1x += signx1;
			t1x += t1xp;
			if (!changed2) t2x += signx2;
			t2x += t2xp;
			y += 1;
			if (y == y2) break;

		}
next:
		// Second half
		dx1 = (int)(x3 - x2); if (dx1 < 0) { dx1 = -dx1; signx1 = -1; } else signx1 = 1;
		dy1 = (int)(y3 - y2);
		t1x = x2;

		if (dy1 > dx1) {   // swap values
			SWAP(dy1, dx1);
			changed1 = true;
		} else changed1 = false;

		e1 = (int)(dx1 >> 1);

		for (int i = 0; i <= dx1; i++) {
			t1xp = 0; t2xp = 0;
			if (t1x < t2x) { minx = t1x; maxx = t2x; } else { minx = t2x; maxx = t1x; }
			// process first line until y value is about to change
			while (i < dx1) {
				e1 += dy1;
				while (e1 >= dx1) {
					e1 -= dx1;
					if (changed1) { t1xp = signx1; break; }//t1x += signx1;
					else          goto next3;
				}
				if (changed1) break;
				else   	   	  t1x += signx1;
				if (i < dx1) i++;
			}
next3:
			// process second line until y value is about to change
			while (t2x != x3) {
				e2 += dy2;
				while (e2 >= dx2) {
					e2 -= dx2;
					if (changed2) t2xp = signx2;
					else          goto next4;
				}
				if (changed2)     break;
				else              t2x += signx2;
			}
next4:

			if (minx > t1x) minx = t1x; if (minx > t2x) minx = t2x;
			if (maxx < t1x) maxx = t1x; if (maxx < t2x) maxx = t2x;
			drawline(minx, maxx, y);
			if (!changed1) t1x += signx1;
			t1x += t1xp;
			if (!changed2) t2x += signx2;
			t2x += t2xp;
			y += 1;
			if (y > y3) return;
		}
	}

	void DrawCircle(int xc, int yc, int r, short c = 0x2588, short col = 0x000F) {
		int x = 0;
		int y = r;
		int p = 3 - 2 * r;
		if (!r) return;

		while (y >= x) // only formulate 1/8 of circle
		{
			Draw(xc - x, yc - y, c, col);//upper left left
			Draw(xc - y, yc - x, c, col);//upper upper left
			Draw(xc + y, yc - x, c, col);//upper upper right
			Draw(xc + x, yc - y, c, col);//upper right right
			Draw(xc - x, yc + y, c, col);//lower left left
			Draw(xc - y, yc + x, c, col);//lower lower left
			Draw(xc + y, yc + x, c, col);//lower lower right
			Draw(xc + x, yc + y, c, col);//lower right right
			if (p < 0) p += 4 * x++ + 6;
			else p += 4 * (x++ - y--) + 10;
		}
	}

	void FillCircle(int xc, int yc, int r, short c = 0x2588, short col = 0x000F) {
		// Taken from wikipedia
		int x = 0;
		int y = r;
		int p = 3 - 2 * r;
		if (!r) return;

		auto drawline = [&](int sx, int ex, int ny) {
			for (int i = sx; i <= ex; i++)
				Draw(i, ny, c, col);
		};

		while (y >= x) {
			// Modified to draw scan-lines instead of edges
			drawline(xc - x, xc + x, yc - y);
			drawline(xc - y, xc + y, yc - x);
			drawline(xc - x, xc + x, yc + y);
			drawline(xc - y, xc + y, yc + x);
			if (p < 0) p += 4 * x++ + 6;
			else p += 4 * (x++ - y--) + 10;
		}
	}

	void DrawSprite(int x, int y, olcSprite* sprite) {
		if (sprite == nullptr)
			return;

		for (int i = 0; i < sprite->width; i++) {
			for (int j = 0; j < sprite->height; j++) {
				if (sprite->GetGlyph(i, j) != L' ')
					Draw(x + i, y + j, sprite->GetGlyph(i, j), sprite->GetColour(i, j));
			}
		}
	}

	void DrawPartialSprite(int x, int y, olcSprite* sprite, int ox, int oy, int w, int h) {
		if (sprite == nullptr)
			return;

		for (int i = 0; i < w; i++) {
			for (int j = 0; j < h; j++) {
				if (sprite->GetGlyph(i + ox, j + oy) != L' ')
					Draw(x + i, y + j, sprite->GetGlyph(i + ox, j + oy), sprite->GetColour(i + ox, j + oy));
			}
		}
	}

	void DrawWireFrameModel(const std::vector<std::pair<float, float>>& vecModelCoordinates, float x, float y, float r = 0.0f, float s = 1.0f, short col = FG_WHITE, short c = PIXEL_SOLID) {
		// pair.first = x coordinate
		// pair.second = y coordinate

		// Create translated model vector of coordinate pairs
		std::vector<std::pair<float, float>> vecTransformedCoordinates;
		int verts = vecModelCoordinates.size();
		vecTransformedCoordinates.resize(verts);

		// Rotate
		for (int i = 0; i < verts; i++) {
			vecTransformedCoordinates[i].first = vecModelCoordinates[i].first * cosf(r) - vecModelCoordinates[i].second * sinf(r);
			vecTransformedCoordinates[i].second = vecModelCoordinates[i].first * sinf(r) + vecModelCoordinates[i].second * cosf(r);
		}

		// Scale
		for (int i = 0; i < verts; i++) {
			vecTransformedCoordinates[i].first = vecTransformedCoordinates[i].first * s;
			vecTransformedCoordinates[i].second = vecTransformedCoordinates[i].second * s;
		}

		// Translate
		for (int i = 0; i < verts; i++) {
			vecTransformedCoordinates[i].first = vecTransformedCoordinates[i].first + x;
			vecTransformedCoordinates[i].second = vecTransformedCoordinates[i].second + y;
		}

		// Draw Closed Polygon
		for (int i = 0; i < verts + 1; i++) {
			int j = (i + 1);
			DrawLine((int)vecTransformedCoordinates[i % verts].first, (int)vecTransformedCoordinates[i % verts].second,
				(int)vecTransformedCoordinates[j % verts].first, (int)vecTransformedCoordinates[j % verts].second, c, col);
		}
	}

	~olcConsoleGameEngine() {
		SetConsoleActiveScreenBuffer(originalConsole);
		delete[] bufferScreen;
	}

	//		=====VIRTUAL=====
	virtual bool OnUserCreate() = 0;
	virtual bool OnUserUpdate(float elapsedTime) = 0;
	virtual bool OnUserDestroy() { return true; }

	//		=====GAME========
	void Start() {
		atomActive = true;
		std::thread t = std::thread(&olcConsoleGameEngine::GameThread, this);

		// Wait for thread to be exited
		t.join();
	}

	int ScreenWidth() { return screenWidth; }

	int ScreenHeight() { return screenHeight; }
protected:
	struct keyState {
		bool pressed;
		bool released;
		bool held;
	} keys[256], mouse[5];

public:
	keyState GetKey(int keyID) { return keys[keyID]; }
	int GetMouseX() { return mousePosX; }
	int GetMouseY() { return mousePosY; }
	keyState GetMouse(int mouseButtonID) { return mouse[mouseButtonID]; }
	bool IsFocused() { return consoleInFocus; }

protected:
	int Error(const wchar_t* msg) {
		wchar_t buf[256];
		FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, NULL, GetLastError(), MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), buf, 256, NULL);
		SetConsoleActiveScreenBuffer(originalConsole);
		wprintf(L"ERROR: %s\n\t%s\n", msg, buf);
		return 0;
	}

	static BOOL CloseHandler(DWORD evt) {
		if (evt == CTRL_CLOSE_EVENT) {
			atomActive = false;

			std::unique_lock<std::mutex> ul(muxGame);
			gameFinished.wait(ul);
		}
		return true;
	}

	// =====VARIABLES========
	int mousePosX;
	int mousePosY;

	int screenWidth;
	int screenHeight;
	CHAR_INFO* bufferScreen;
	std::wstring appName;
	HANDLE originalConsole;
	CONSOLE_SCREEN_BUFFER_INFO originalConsoleInfo;
	HANDLE console;
	HANDLE consoleIn;
	SMALL_RECT rectWindow;
	short keyOldState[256] = {0};
	short keyNewState[256] = {0};
	bool mouseOldState[5] = {0};
	bool mouseNewState[5] = {0};
	bool consoleInFocus = true;
	bool enableSound = false;

	// =====AUDIO==========
	class olcAudioSample {
	public:
		olcAudioSample() {}
		olcAudioSample(std::wstring wavFile) {
			FILE* f = nullptr;
			_wfopen_s(&f, wavFile.c_str(), L"rb");

			if (f == nullptr)
				return;

			char dump[4];
			std::fread(&dump, sizeof(char), 4, f); // Read "RIFF"
			if (strncmp(dump, "RIFF", 4) != 0) return;
			std::fread(&dump, sizeof(char), 4, f); // Not interested
			std::fread(&dump, sizeof(char), 4, f); // Read "WAVE"
			if (strncmp(dump, "WAVE", 4) != 0) return;

			std::fread(&dump, sizeof(char), 4, f); // Read "fmt 
			std::fread(&dump, sizeof(char), 4, f); // Not interested
			std::fread(&wavHeader, sizeof(WAVEFORMATEX) - 2, 1, f); // Read Wave Format Structure chunk

			// Just check if wave format is compatible with olcCGE
			if (wavHeader.wBitsPerSample != 16 || wavHeader.nSamplesPerSec != 44100) {
				std::fclose(f);
				return;
			}

			long chunkSize = 0;
			std::fread(&dump, sizeof(char), 4, f); // Read chunk header
			std::fread(&chunkSize, sizeof(long), 1, f); //Read chunk size

			while (strncmp(dump, "data", 4) != 0) {
				// Not audio data, so just skip it
				std::fseek(f, chunkSize, SEEK_CUR);
				std::fread(&dump, sizeof(char), 4, f);
				std::fread(&chunkSize, sizeof(long), 1, f);
			}

			// Finally got to data, so read it all in and convert to float samples
			samples = chunkSize / (wavHeader.nChannels * (wavHeader.wBitsPerSample >> 3));
			channels = wavHeader.nChannels;

			// Create floating point buffer to hold audio sample
			sample = new float[samples * channels];
			float* pSample = sample;

			// Read in audio data and normalize
			for (long i = 0; i < samples; i++) {
				for (int c = 0; c < channels; c++) {
					short s = 0;
					std::fread(&s, sizeof(short), 1, f);
					*pSample = (float)s / (float)(MAXSHORT);
					pSample++;
				}
			}

			// All done, flag sound as valid
			std::fclose(f);
			sampleValid = true;
		}

		WAVEFORMATEX wavHeader;
		float* sample = nullptr;
		long samples = 0;
		int channels = 0;
		bool sampleValid = false;
	};

	// This vector holds all loaded samples in memory
	std::vector<olcAudioSample> vecAudioSamples;

	struct currentlyPlayingSample {
		int audioSampleID = 0;
		long samplePosition = 0;
		bool finished = false;
		bool loop = false;
	};

	std::list<currentlyPlayingSample> listActiveSamples;

	unsigned int LoadAudioSample(std::wstring wavFile) {
		if (!enableSound)
			return -1;

		olcAudioSample a(wavFile);
		if (a.sampleValid) {
			vecAudioSamples.push_back(a);
			return vecAudioSamples.size();
		} else
			return -1;
	}

	void PlaySample(int id, bool loop = false) {
		currentlyPlayingSample a;
		a.audioSampleID = id;
		a.samplePosition = 0;
		a.finished = false;
		a.loop = loop;
		listActiveSamples.push_back(a);
	}

	void StopSample(int id) {

	}

	bool CreateAudio(unsigned int sampleRate = 44100, unsigned int channels = 1, unsigned int blocks = 8, unsigned int blockSamples = 512) {
		audioThreadActive = false;
		this->sampleRate = sampleRate;
		this->channels = channels;
		blockCount = blocks;
		this->blockSamples = blockSamples;
		blockFree = blockCount;
		blockCurrent = 0;
		blockMemory = nullptr;
		waveHeaders = nullptr;

		// Device is available
		WAVEFORMATEX waveFormat;
		waveFormat.wFormatTag = WAVE_FORMAT_PCM;
		waveFormat.nSamplesPerSec = this->sampleRate;
		waveFormat.wBitsPerSample = sizeof(short) * 8;
		waveFormat.nChannels = this->channels;
		waveFormat.nBlockAlign = (waveFormat.wBitsPerSample / 8) * waveFormat.nChannels;
		waveFormat.nAvgBytesPerSec = waveFormat.nSamplesPerSec * waveFormat.nBlockAlign;
		waveFormat.cbSize = 0;

		// Open Device if valid
		if (waveOutOpen(&device, WAVE_MAPPER, &waveFormat, (DWORD_PTR)WaveOutProcWrap, (DWORD_PTR)this, CALLBACK_FUNCTION) != S_OK)
			return DestroyAudio();

		// Allocate Wave|Block Memory
		blockMemory = new short[blockCount * blockSamples];
		if (blockMemory == nullptr)
			return DestroyAudio();
		ZeroMemory(blockMemory, sizeof(short) * blockCount * blockSamples);

		waveHeaders = new WAVEHDR[blockCount];
		if (waveHeaders == nullptr)
			return DestroyAudio();
		ZeroMemory(waveHeaders, sizeof(WAVEHDR) * blockCount);

		// Link headers to block memory
		for (unsigned int n = 0; n < blockCount; n++) {
			waveHeaders[n].dwBufferLength = blockSamples * sizeof(short);
			waveHeaders[n].lpData = (LPSTR)(blockMemory + (n * blockSamples));
		}

		audioThreadActive = true;
		audioThread = std::thread(&olcConsoleGameEngine::AudioThread, this);

		// Start the ball rolling with the sound delivery thread
		std::unique_lock<std::mutex> lm(muxBlockNotZero);
		blockNotZero.notify_one();
		return true;
	}

	bool DestroyAudio() {
		audioThreadActive = false;
		return false;
	}

	void WaveOutProc(HWAVEOUT waveOut, UINT msg, DWORD param1, DWORD param2) {
		if (msg != WOM_DONE) return;
		blockFree++;
		std::unique_lock<std::mutex> lm(muxBlockNotZero);
		blockNotZero.notify_one();
	}

	static void CALLBACK WaveOutProcWrap(HWAVEOUT waveOut, UINT msg, DWORD instance, DWORD param1, DWORD param2) {
		((olcConsoleGameEngine*)instance)->WaveOutProc(waveOut, msg, param1, param2);
	}

	void AudioThread() {
		globalTime = 0.0f;
		float timeStep = 1.0f / (float)sampleRate;

		// Goofy hack to get maximum integer for a type at run-time
		short maxSample = (short)pow(2, (sizeof(short) * 8) - 1) - 1;
		float fMaxSample = (float)maxSample;
		short previousSample = 0;

		while (audioThreadActive) {
			// Wait for block to become available
			if (blockFree == 0) {
				std::unique_lock<std::mutex> lm(muxBlockNotZero);
				while (blockFree == 0) // sometimes, Windows signals incorrectly
					blockNotZero.wait(lm);
			}

			// Block is here, so use it
			blockFree--;

			// Prepare block for processing
			if (waveHeaders[blockCurrent].dwFlags & WHDR_PREPARED)
				waveOutUnprepareHeader(device, &waveHeaders[blockCurrent], sizeof(WAVEHDR));

			short newSample = 0;
			int currentBlock = blockCurrent * blockSamples;

			auto clip = [](float fSample, float fMax) {
				if (fSample >= 0.0)
					return fmin(fSample, fMax);
				else
					return fmax(fSample, -fMax);
			};

			for (unsigned int n = 0; n < blockSamples; n += channels) {
				// User Process
				for (unsigned int c = 0; c < channels; c++) {
					newSample = (short)(clip(GetMixerOutput(c, globalTime, timeStep), 1.0) * fMaxSample);
					blockMemory[currentBlock + n + c] = newSample;
					previousSample = newSample;
				}

				globalTime = globalTime + timeStep;
			}

			// Send block to sound device
			waveOutPrepareHeader(device, &waveHeaders[blockCurrent], sizeof(WAVEHDR));
			waveOutWrite(device, &waveHeaders[blockCurrent], sizeof(WAVEHDR));
			blockCurrent++;
			blockCurrent %= blockCount;
		}
	}

	virtual float onUserSoundSample(int channel, float globalTime, float timeStep) { return 0.0f; }
	virtual float onUserSoundFilter(int channel, float globalTime, float sample) { return sample; }

	float GetMixerOutput(int channel, float globalTime, float timeStep) {
		float mixerSample = 0.0f;
		for (auto& s : listActiveSamples) {
			s.samplePosition += (long)((float)vecAudioSamples[s.audioSampleID - 1].wavHeader.nSamplesPerSec * timeStep);

			if (s.samplePosition < vecAudioSamples[s.audioSampleID - 1].samples)
				mixerSample += vecAudioSamples[s.audioSampleID - 1].sample[(s.samplePosition * vecAudioSamples[s.audioSampleID - 1].channels) + channel];
			else
				s.finished = true;
		}

		listActiveSamples.remove_if([](const currentlyPlayingSample& s) {return s.finished; });

		mixerSample += onUserSoundSample(channel, globalTime, timeStep);

		return onUserSoundFilter(channel, globalTime, mixerSample);
	}

	unsigned int sampleRate;
	unsigned int channels;
	unsigned int blockCount;
	unsigned int blockSamples;
	unsigned int blockCurrent;

	short* blockMemory = nullptr;
	WAVEHDR* waveHeaders = nullptr;
	HWAVEOUT device = nullptr;

	std::thread audioThread;
	std::atomic<bool> audioThreadActive = false;
	std::atomic<unsigned int> blockFree = 0;
	std::condition_variable blockNotZero;
	std::mutex muxBlockNotZero;
	std::atomic<float> globalTime = 0.0f;

	// These need to be static because of the OnDestroy call the OS may make
	// The OS spawns a special thread just for that
	static std::atomic<bool> atomActive;
	static std::condition_variable gameFinished;
	static std::mutex muxGame;

private:
	// =====FUNCTIONS==========
	void GameThread() {
		// Create user resources as part of this thread
		if (!OnUserCreate())
			atomActive = false;

		// Check if sound system should be enabled
		if (enableSound) {
			if (!CreateAudio()) {
				atomActive = false; // Failed to create audio system			
				enableSound = false;
			}
		}

		auto tp1 = std::chrono::system_clock::now();
		auto tp2 = std::chrono::system_clock::now();

		while (atomActive) {
			// Run as fast as possible
			while (atomActive) {
				// Handle Timing
				tp2 = std::chrono::system_clock::now();
				std::chrono::duration<float> chronoElapsedTime = tp2 - tp1;
				tp1 = tp2;
				float elapsedTime = chronoElapsedTime.count();

				// Handle Keyboard Input
				for (int i = 0; i < 256; i++) {
					keyNewState[i] = GetAsyncKeyState(i);

					keys[i].pressed = false;
					keys[i].released = false;

					if (keyNewState[i] != keyOldState[i]) {
						if (keyNewState[i] & 0x8000) {
							keys[i].pressed = !keys[i].held;
							keys[i].held = true;
						} else {
							keys[i].released = true;
							keys[i].held = false;
						}
					}

					keyOldState[i] = keyNewState[i];
				}

				// Handle Mouse Input - Check for window events
				INPUT_RECORD inBuf[32];
				DWORD events = 0;
				GetNumberOfConsoleInputEvents(consoleIn, &events);
				if (events > 0)
					ReadConsoleInput(consoleIn, inBuf, events, &events);

				// Handle events - we only care about mouse clicks and movement
				// for now
				for (DWORD i = 0; i < events; i++) {
					switch (inBuf[i].EventType) {
						case FOCUS_EVENT:
						{
							consoleInFocus = inBuf[i].Event.FocusEvent.bSetFocus;
						}
						break;

						case MOUSE_EVENT:
						{
							switch (inBuf[i].Event.MouseEvent.dwEventFlags) {
								case MOUSE_MOVED:
								{
									mousePosX = inBuf[i].Event.MouseEvent.dwMousePosition.X;
									mousePosY = inBuf[i].Event.MouseEvent.dwMousePosition.Y;
								}
								break;

								case 0:
								{
									for (int m = 0; m < 5; m++)
										mouseNewState[m] = (inBuf[i].Event.MouseEvent.dwButtonState & (1 << m)) > 0;

								}
								break;

								default:
									break;
							}
						}
						break;

						default:
							break;
							// We don't care just at the moment
					}
				}

				for (int m = 0; m < 5; m++) {
					mouse[m].pressed = false;
					mouse[m].released = false;

					if (mouseNewState[m] != mouseOldState[m]) {
						if (mouseNewState[m]) {
							mouse[m].pressed = true;
							mouse[m].held = true;
						} else {
							mouse[m].released = true;
							mouse[m].held = false;
						}
					}

					mouseOldState[m] = mouseNewState[m];
				}


				// Handle Frame Update
				if (!OnUserUpdate(elapsedTime))
					atomActive = false;

				// Update Title & Present Screen Buffer
				wchar_t s[256];
				swprintf_s(s, 256, L"OneLoneCoder.com - Console Game Engine - %s - FPS: %3.2f", appName.c_str(), 1.0f / elapsedTime);
				SetConsoleTitle(s);
				WriteConsoleOutput(console, bufferScreen, {(short)screenWidth, (short)screenHeight}, {0,0}, &rectWindow);
			}

			if (enableSound) {
				// Close and Clean up audio system
			}

			// Allow the user to free resources if they have overrided the destroy function
			if (OnUserDestroy()) {
				// User has permitted destroy, so exit and clean up
				delete[] bufferScreen;
				SetConsoleActiveScreenBuffer(originalConsole);
				gameFinished.notify_one();
			} else {
				// User denied destroy for some reason, so continue running
				atomActive = true;
			}
		}
	}
};

// Define our static variables
std::atomic<bool> olcConsoleGameEngine::atomActive(false);
std::condition_variable olcConsoleGameEngine::gameFinished;
std::mutex olcConsoleGameEngine::muxGame;