/*

  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF

  ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO

  THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A

  PARTICULAR PURPOSE.

  

    This is "Sample Code" and is distributable subject to the terms of the end user license agreement.

*/

// ****************************************************************************
// FILE: dllmain.h
// ****************************************************************************  

#ifndef __DLLMAIN_H__
#define __DLLMAIN_H__

///#ifdef __cplusplus
//extern "C" {
//#endif

#pragma warning(disable:4355)

/////////////////////////////////////////////////////////////////////////////

    
#include <windows.h>
#include <windowsx.h>
#include <commctrl.h>
#include <tchar.h>
#include <olectl.h>
    
#include "macros.h"


extern HINSTANCE g_hInstDll;
extern DWORD g_dwObjectCount;   

// Initialize the DLL, register the classes etc
 

STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, LPVOID FAR* ppv);
STDAPI DllCanUnloadNow(void);


/////////////////////////////////////////////////////////////////////////////

#endif /* __DLLMAIN_H__ */