#include <cv.h>
#include <cxcore.h>
#include <highgui.h>
#include <stdio.h>
#include <iostream>
#include <string>

using namespace std;

#define CAPTURE_ID		"Capture Window"
#define INPUT_FILE		"input.avi"
#define OUTPUT_FILE		"output.avi"

void FilteringFrame(IplImage* image)
{
	// Filtering with a sample method (convert to grayscale)
	unsigned char* pointer = (unsigned char*)image->imageData;
	int size = image->width * image->height;
	for (int i=0; i<size; i++)
	{
		unsigned char intensity = (pointer[0] + pointer[1] + pointer[2]) / 3;
		pointer[0] = pointer[1] = pointer[2] = intensity;
		pointer += 3;
	}
}

int main (int argc, char* argv[])
{
	bool using_camera;
	while (true)
	{
		// Ask for video capturing source
		printf("Select the source of video capturing? [ (C)amera / (V)ideo File ]\t");
		string ans;
		getline(cin, ans);
		if (ans[0] == 'c' || ans[0] == 'C')
		{
			// Using camera
			using_camera = true;
			break;
		}
		if (ans[0] == 'v' || ans[0] == 'V')
		{
			// Using video file
			using_camera = false;
			break;
		}
	}
	CvCapture* capture;
	double fps;
	int delay;
	if (using_camera)
	{
		// Using camera, create a camera capture
		printf("\nCamera Capture\n");
		capture = cvCreateCameraCapture(-1);
		// Set the fps and delay time, because we can not get those information from a camera capture
		fps = 6;
		delay = 100;
	}
	else
	{
		// Using video file, create a file capture
		printf("\nVideo File Capture\n");
		capture = cvCreateFileCapture(INPUT_FILE);
		// Get the fps from the capture, and calculate the delay time
		fps = cvGetCaptureProperty(capture, CV_CAP_PROP_FPS);
		delay = 1000 / fps;
	}
	CvVideoWriter* writer;
	bool initialized = false;
	bool stop = false;
	bool recording = false;
	bool filtering = false;
	// Write instructions
	printf("Press ESC or Q to exit program.\n");
	printf("Press R to start or stop recording.\n");
	printf("Press F to start or stop filtering.\n");
	cvNamedWindow(CAPTURE_ID);
	cvMoveWindow(CAPTURE_ID, 500, 100);
	printf("\n\nCapturing ...\n");
	while (!stop)
	{
		// Get a frame
		IplImage* frame = cvQueryFrame(capture);
		// We should not modify the frame, so create a clone frame image
		IplImage* image = cvCloneImage(frame);
		if (filtering)
		{
			FilteringFrame(image);
		}
		// Show the frame image
		cvShowImage(CAPTURE_ID, image);
		if (recording)
		{
			// If recording, write the frame image into the file
			cvWriteFrame(writer, image);
		}
		// Wait a key, or delay for the next frame
		int key = cvWaitKey(delay);
		switch (key)
		{
		case 27:	// ESC	Exit the program
		case 'q':	// Q	Exit the program
			stop = true;
			break;
		case 'r':	// R	Start/stop recording
			if (recording)
			{
				printf("Stop Recording.\n");
				stop = true;
			}
			else
			{
				if (!initialized)
				{
					// Initialize the writer
					writer = cvCreateVideoWriter(OUTPUT_FILE, -1, fps, cvGetSize(image));
					initialized = true;
				}
				printf("Recording ...\n");
			}
			// Change the recording status
			recording = !recording;
			break;
		case 'f':	// F	Start/stop filtering
			if (filtering)
			{
				printf("Stop Filtering.\n");
			}
			else
			{
				printf("Start Filtering.\n");
			}
			// Change the filtering status
			filtering = !filtering;
			break;
		}
		// Release the clone frame
		cvReleaseImage(&image);
	}
	if (initialized)
	{
		// Release the video writer
		cvReleaseVideoWriter(&writer);
	}
	// Release the capture
	cvReleaseCapture(&capture);
	printf("\n");
	return 0;
}