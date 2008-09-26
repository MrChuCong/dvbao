/*

  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF

  ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO

  THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A

  PARTICULAR PURPOSE.

  

    This is "Sample Code" and is distributable subject to the terms of the end user license agreement.

*/

// ****************************************************************************
// FILE: dvoraksip.cpp
// ABTRACT: Contains DllMain and DllRegisterServer implementations
// ****************************************************************************

#include "stdafx.h"
#include "resource.h"
#include "initguid.h"
#include <commctrl.h>
#include <aygshell.h>
#include <sipapi.h>
#include "dllmain.h"
#include "dvoraksip.h"
#include "dvorak_classfactory.h"

#include "dvoraksip_i.c"

// constant strings that we use for registering the server
#define PENINPUT		TEXT("Dvorak")
#define STRING_ONE		TEXT("1")
#define ICON_NAME		TEXT("\\windows\\dvoraksip.dll,0")
#define EXEPATH			TEXT("\\windows\\dvoraksip.dll")



DWORD		g_dwObjectCount;
HINSTANCE	g_hInstDll;

CComModule	_Module;

BEGIN_OBJECT_MAP(ObjectMap)
END_OBJECT_MAP()

/////////////////////////////////////////////////////////////////////////////
// DLL Entry Point

extern "C" BOOL WINAPI DllMain(HANDLE hInstance, DWORD dwReason, LPVOID)
{
	if (dwReason == DLL_PROCESS_ATTACH)
	{
		g_hInstDll = (HINSTANCE)hInstance;
		_Module.Init(ObjectMap, (HINSTANCE)hInstance);
	}
	else if (dwReason == DLL_PROCESS_DETACH)
	{
		_Module.Term();
	}
	return TRUE;    
}

/////////////////////////////////////////////////////////////////////////////
// Used to determine whether the DLL can be unloaded by OLE

STDAPI DllCanUnloadNow(void)
{
	if( !g_dwObjectCount )
	{
        return NOERROR;
    }

    return S_FALSE;
}

/////////////////////////////////////////////////////////////////////////////
// Returns a class factory to create an object of the requested type

STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, LPVOID* ppv)
{
	HRESULT hr;
    
    CClassFactory *pClassFactory = new CClassFactory( rclsid );
    
    if( pClassFactory ) 
	{
        hr = pClassFactory->QueryInterface( riid, ppv );
        RELEASE( pClassFactory );

        return hr;
    }

    return E_OUTOFMEMORY;
}

// add all the registry entries needed to make this CLSID into a SIP
HRESULT RegisterAClsid(LPTSTR pszClsid)
{
	LONG		lRC;
	HKEY		hClsidKey;
	HKEY		hGuidKey;
	HKEY		hRegKey;
	DWORD		dwDisposition;

 	lRC = RegOpenKey(HKEY_CLASSES_ROOT, TEXT("CLSID"), &hClsidKey);
	if (ERROR_SUCCESS != lRC)
	{
		OutputDebugString(TEXT("Failed to create the CLSID key"));
		return E_FAIL;
	}

	// create the base key for the OLE object under clsid
	lRC = RegCreateKeyEx(hClsidKey, pszClsid,
		                 0, TEXT("REG_SZ"), 0, KEY_WRITE, NULL, &hGuidKey, &dwDisposition);
	if (ERROR_SUCCESS != lRC)
	{
		RegCloseKey(hClsidKey);
		return E_FAIL;
	}

	// now set the named value under this key
	lRC = RegSetValueEx(hGuidKey, NULL, 0, REG_SZ, (BYTE*) PENINPUT, 
		                sizeof(TCHAR)*(1+_tcslen(PENINPUT)));
	if (ERROR_SUCCESS != lRC)
	{
		RegCloseKey(hGuidKey);
		RegCloseKey(hClsidKey);
		return E_FAIL;
	}

	// now, create the standard OLE server key
	lRC = RegCreateKeyEx(hGuidKey, TEXT("InprocServer32"),
		                 0, TEXT("REG_SZ"), 0, KEY_WRITE, NULL, &hRegKey, &dwDisposition);
	if (ERROR_SUCCESS != lRC)
	{
		RegCloseKey(hGuidKey);
		RegCloseKey(hClsidKey);
		return E_FAIL;
	}

	// now set the named value under this key
	lRC = RegSetValueEx(hRegKey, NULL, 0, REG_SZ,  (BYTE*) EXEPATH, 
		                sizeof(TCHAR)*(1+_tcslen(EXEPATH)));
	if (ERROR_SUCCESS != lRC)
	{
		RegCloseKey(hRegKey);
		RegCloseKey(hGuidKey);
		RegCloseKey(hClsidKey);
		return E_FAIL;
	}
	RegCloseKey(hRegKey);

	// this is the *only* thing which marks this as a sip
	lRC = RegCreateKeyEx(hGuidKey, TEXT("IsSIPInputMethod"),
		                 0, TEXT("REG_SZ"), 0, KEY_WRITE, NULL, &hRegKey, &dwDisposition);
	if (ERROR_SUCCESS != lRC)
	{
		RegCloseKey(hGuidKey);
		RegCloseKey(hClsidKey);
		return E_FAIL;
	}

	// now set the named value under this key
	lRC = RegSetValueEx(hRegKey, NULL, 0, REG_SZ,  (BYTE*) STRING_ONE, 
		                sizeof(TCHAR)*(1+_tcslen(STRING_ONE)));
	if (ERROR_SUCCESS != lRC)
	{
		RegCloseKey(hRegKey);
		RegCloseKey(hGuidKey);
		RegCloseKey(hClsidKey);
		return E_FAIL;
	}
	RegCloseKey(hRegKey);

	// this controls the icon we see in the sip menu
	lRC = RegCreateKeyEx(hGuidKey, TEXT("DefaultIcon"),
		                 0, TEXT("REG_SZ"), 0, KEY_WRITE, NULL, &hRegKey, &dwDisposition);
	if (ERROR_SUCCESS != lRC)
	{
		RegCloseKey(hGuidKey);
		RegCloseKey(hClsidKey);
		return E_FAIL;
	}

	// now set the named value under this key
	lRC = RegSetValueEx(hRegKey, NULL, 0, REG_SZ,  (BYTE*) ICON_NAME, 
		                sizeof(TCHAR)*(1+_tcslen(ICON_NAME)));
	if (ERROR_SUCCESS != lRC)
	{
		RegCloseKey(hRegKey);
		RegCloseKey(hGuidKey);
		RegCloseKey(hClsidKey);
		return E_FAIL;
	}
	RegCloseKey(hRegKey);

	RegCloseKey(hGuidKey);

	RegCloseKey(hClsidKey);

	return S_OK;
}

/////////////////////////////////////////////////////////////////////////////
// DllRegisterServer - Adds entries to the system registry

STDAPI DllRegisterServer(void)
{
	HRESULT	hr = S_OK;
	
	hr = RegisterAClsid(TEXT("{42429695-AE04-11D0-A4F8-00AA00A749B9}"));
	return hr;

}

/////////////////////////////////////////////////////////////////////////////
// DllUnregisterServer - Removes entries from the system registry

STDAPI DllUnregisterServer(void)
{
	_Module.UnregisterServer();
	return S_OK;
}


