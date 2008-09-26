#include <cv.h>
#include <cxcore.h>
#include <highgui.h>
#include "include.h"

#define SRC_FOLDER	"src"
#define DST_FOLDER	"dst"

void ProcessImage (IplImage* image)
{
	// For example, I used threshold filter to process each image
	unsigned char* p = (unsigned char*)image->imageData;
	for (int i=0; i<image->imageSize; i++)
	{
		p[i] = (p[i] < 150) ? 0 : 255;
	}
}

void ProcessFolder (const char* src_path, const char* dst_path)
{
	WIN32_FIND_DATA FindFileData;
	HANDLE hFind;
	char FileName[1024];
	// Create a string to search for all sub files and folders
	sprintf(FileName, "%s\\*", src_path);
	// Start searching
	hFind = FindFirstFile(FileName, &FindFileData);
	// If receiving an invalid handle, return
	if (hFind == INVALID_HANDLE_VALUE) return;
	bool stop = false;
	while (!stop)
	{
		// Search for all sub files and folders
		if (FindNextFile(hFind, &FindFileData))
		{
			string filename = FindFileData.cFileName;
			// Skip the current directory and parent directory markers
			if (filename == "." || filename == "..") continue;
			filename = "\\" + filename;
			filename = src_path + filename;
			if (FindFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
			{
				// Found a directory, process it
				ProcessFolder(filename.c_str(), dst_path);
			}
			else
			{
				// Found a file, try to load it
				printf("File %s: ", filename.c_str());
				IplImage* image = cvLoadImage(filename.c_str(), -1);
				if (!image)
				{
					// Not a supported image file
					printf("Not a supported format.\n");
				}
				else
				{
					// Found a supported image file, process it
					ProcessImage(image);

					// Save the result
					filename = dst_path;
					filename += "\\";
					filename += FindFileData.cFileName;
					cvSaveImage(filename.c_str(), image);

					printf("Done.\n");
				}
			}
		}
		else
		{
			// If no more files or some errors occurred, stop searching
			stop = true;
		}
	}
	// Close the handle
	FindClose(hFind);
}

bool DeleteDirectory (const char* path)
{
	if (!PathIsDirectory(path))
	{
		printf("The directory %s do not exist.", path);
		return true;
	}
	printf("Deleting the directory %s...\n", path);
	WIN32_FIND_DATA FindFileData;
	HANDLE hFind;
	char FileName[1024];
	// Create a string to search for all sub files and folders
	sprintf(FileName, "%s\\*", path);
	// Start searching
	hFind = FindFirstFile(FileName, &FindFileData);
	// If receiving an invalid handle, return FALSE
	if (hFind == INVALID_HANDLE_VALUE) return false;
	bool stop = false;
	while (!stop)
	{
		// Search for all sub files and folders
		if (FindNextFile(hFind, &FindFileData))
		{
			string filename = FindFileData.cFileName;
			// Skip the current directory and parent directory markers
			if (filename == "." || filename == "..") continue;
			filename = "\\" + filename;
			filename = path + filename;
			if (FindFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
			{
				// Found a directory, try to delete it
				if (!DeleteDirectory(filename.c_str()))
				{
					// Some error occurred, close the handle and return FALSE
					FindClose(hFind);
					return false;
				}
			}
			else
			{
				// Found a file
				printf("Deleting the file %s...\n", filename.c_str());

				if (FindFileData.dwFileAttributes & FILE_ATTRIBUTE_READONLY)
				{
					printf("File: %s\n", filename.c_str());
					// Change READ ONLY file mode
					_chmod(filename.c_str(), _S_IWRITE);
				}

				// Delete the file
				if (!DeleteFile(filename.c_str()))
				{
					// Some errors occurred, close the handle and return FALSE
					FindClose(hFind);
					return false;
				}
			}
		}
		else
		{
			if (GetLastError() == ERROR_NO_MORE_FILES)
			{
				// If no more files, stop searching
				stop = true;
			}
			else
			{
				// Some errors occurred, close the handle and return FALSE
				FindClose(hFind);
				return false;
			}
		}
	}
	// Close the handle
	FindClose(hFind);
	// Return the result when deleting the empty folder
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
			if (!DeleteDirectory(DST_FOLDER))
			{
				printf("Can not delete the destination folder.\n");
				return 0;
			}
		}
	}

	// Create the destination folder to store all result images	
	CreateDirectory(DST_FOLDER, NULL);

	// Pause
	printf("\n");
	system("pause");
	printf("\n");

	// Process the source folder and save the result to the destination folder
	ProcessFolder(SRC_FOLDER, DST_FOLDER);

	printf("\n");
	return 0;
}