#include <cv.h>
#include <cxcore.h>
#include <highgui.h>
#include <stdio.h>

#define SOURCE_WINDOW_ID		"Source Image"
#define DESTINATION_WINDOW_ID	"Destination Image"

int main (int argc, char* argv[])
{
	if (argc < 2)
	{
		// No input file name
		printf("Usage: main source_image [destination_image]\n");
		return 0;
	}

	char* srcFilename = argv[1];
	char* dstFilename;

	// Load the image with number of channels in the file
	IplImage* srcImage = cvLoadImage(srcFilename, -1);
	IplImage* dstImage;

	if (argc < 3)
	{
		// No output filename
		if (srcImage->nChannels == 1)
		{
			// 8-bit --> 24-bit : OUTPUT PPM FORMAT
			dstFilename = "output.ppm";
		}
		else
		{
			// 24-bit --> 8-bit : OUTPUT PGM FORMAT
			dstFilename = "output.pgm";
		}
	}
	else
	{
		dstFilename = argv[2];
	}

	// Show the source image
	cvNamedWindow(SOURCE_WINDOW_ID, CV_WINDOW_AUTOSIZE);
	cvMoveWindow(SOURCE_WINDOW_ID, 100, 100);
	cvShowImage(SOURCE_WINDOW_ID, srcImage);

	// Show the source image information
	printf("Source Image: %s\n", srcFilename);
	printf("Channels: %d\n", srcImage->nChannels);
	printf("Width: %d\n", srcImage->width);
	printf("Height: %d\n", srcImage->height);
	printf("Width Step: %d\n", srcImage->widthStep);

	// Convert the image
	printf("\nConverting ...\n\n");
	if (srcImage->nChannels == 1)
	{
		// 8-bit --> 24-bit
		dstImage = cvCreateImage(cvGetSize(srcImage), IPL_DEPTH_8U, 3);

		// Get the pointers
		unsigned char* srcPointer = (unsigned char*)srcImage->imageData;
		unsigned char* dstPointer = (unsigned char*)dstImage->imageData;

		for (int i=0; i<srcImage->imageSize; i++)
		{
			// B = G = R = Gray Intensity
			dstPointer[0] = dstPointer[1] = dstPointer[2] = srcPointer[0];
			dstPointer += 3;
			srcPointer += 1;
		}
	}
	else
	{
		// 24-bit --> 8-bit
		dstImage = cvCreateImage(cvGetSize(srcImage), IPL_DEPTH_8U, 1);

		// Get the pointers
		unsigned char* srcPointer = (unsigned char*)srcImage->imageData;
		unsigned char* dstPointer = (unsigned char*)dstImage->imageData;

		for (int i=0; i<dstImage->imageSize; i++)
		{
			// Gray Intensity = B * 0.114 + G * 0.587 + R * 0.299
			dstPointer[0] = srcPointer[0] * 0.114 + srcPointer[1] * 0.587 + srcPointer[2] * 0.299;
			dstPointer += 1;
			srcPointer += 3;
		}
	}

	// Save the result image
	cvSaveImage(dstFilename, dstImage);

	// Show the result image
	cvNamedWindow(DESTINATION_WINDOW_ID, CV_WINDOW_AUTOSIZE);
	cvMoveWindow(DESTINATION_WINDOW_ID, 200, 200);
	cvShowImage(DESTINATION_WINDOW_ID, dstImage);

	// Show the destination image information
	printf("Destination Image: %s\n", dstFilename);
	printf("Channels: %d\n", dstImage->nChannels);
	printf("Width: %d\n", dstImage->width);
	printf("Height: %d\n", dstImage->height);
	printf("Width Step: %d\n", dstImage->widthStep);

	// Wait for a key
	cvWaitKey(0);

	// Release all images
	cvReleaseImage(&srcImage);
	cvReleaseImage(&dstImage);

	return 0;
}