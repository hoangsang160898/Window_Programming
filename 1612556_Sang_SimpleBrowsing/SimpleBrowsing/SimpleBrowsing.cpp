#include "pch.h"
#include <iostream>
#include <Windows.h>
#include <string.h>

int main()
{
	const int BUFFER_SIZE = 255;
	const int DRIVER_SIZE = 4;
	WCHAR buffer[BUFFER_SIZE];
	
	GetLogicalDriveStrings(BUFFER_SIZE, buffer);
	
	for (auto i = 0; buffer[i] != '\0' || buffer[i + 1] != '\0'; i++) {
		if (buffer[i] > 64 && buffer[i] < 91)
		{
			WCHAR driver[DRIVER_SIZE];
			WCHAR name[DRIVER_SIZE];
			name[0] = buffer[i];
			name[1] = ':';
			name[2] = '\0';
			// Định dạng kết thúc driver để duyệt
			printf("%s\n", name);
			wsprintf(driver, L"%s\\*.*", name);
			WIN32_FIND_DATA data;
			HANDLE hFile = FindFirstFile(driver, &data);

			// Tìm tập tin đầu tiên
			do {
				if (data.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) {
					wprintf(L"Folder: %s\n", data.cFileName);
				}
				if (!(data.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)) {
					wprintf(L"File: %s\n", data.cFileName);
				}
			} while (FindNextFile(hFile, &data)); // Cho đến khi không còn tập tin kế
			FindClose(hFile);
		}
		
	}
	return 0;
}
