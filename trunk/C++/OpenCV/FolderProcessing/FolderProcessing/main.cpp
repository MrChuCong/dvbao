#include <cv.h>
#include <cxcore.h>
#include <highgui.h>
#include <shlwapi.h>
#include <stdio.h>
#include <windows.h>

#define SRC_FOLDER	"src"
#define DST_FOLDER	"dst"

bool DeleteDirectory(const char* path)
{
	WIN32_FIND_DATA FindFileData;
	HANDLE hFind;
	char FileName[1024];
	sprintf(FileName, "%s\\*", path);
	hFind = FindFirstFile(FileName, &FindFileData);
	if (hFind == INVALID_HANDLE_VALUE) return false;
	
	return RemoveDirectory(path);
}

int main (int argc, char* argv[])
{
	// Check if the source folder exists
	if (!PathIsDirectory(SRC_FOLDER))
	{
		printf("The source folder do not exist.\n");
		printf("\n");
		return 0;
	}

	// Check if the destination folder exists
	if (PathIsDirectory(DST_FOLDER))
	{
		char ans;
		printf("The destination folder exists. Do you want to delete it (Y/N)? ");
		scanf("%c", &ans);
		if (ans != 'y' && ans != 'Y')
		{
			printf("\n");
			return 0;
		}
		else
		{
			// Delete the destination folder when it exists
			DeleteDirectory(DST_FOLDER);
			printf("Deleted the destination folder.\n");
		}
	}

	printf("\n");
	return 0;
}