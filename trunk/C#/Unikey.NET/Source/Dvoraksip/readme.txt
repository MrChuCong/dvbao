Code Sample Name: DvorakSIP

Feature Area: Shell

Description: 
    The soft input panel (SIP) was designed to support user-defined input 
    mechanisms. By default, it includes a standard keyboard, a block recognizer,
    and letter recognizer. This sample will demonstrate how a third party can 
    create a custom input panel as a COM object.  This example is intended to 
    help users and service providers in foreign countries support different 
    languages using SIP.  

    The Dvorak keyboard sample should be a COM component that implements the 
    IInputMethod interface.  A description of the interface can be found in the 
    Pocket PC documentation.  

    The following events occur when the user selects this input panel and 
    begins tapping keys.

    1. The system calls the dll containing the code for the custom SIP mechanism,
       which implements the IInputMethod interface.
    2. The Select method is called to create the input window using the Dvorak 
       keyboard bitmap.
    3. The system calls GetInfo to get information in an IMINFO structure about 
       the size and other aspects of the input context.
    4. The system calls ReceiveSipInfo to inform the input method of size, 
       placement information.  It should react to this call by resizing itself 
       appropriately.
    5. Finally, RegisterCallback is called to give the input method a pointer to 
       a IMCallBack interface.  This interface is used to return keystrokes to 
       applications.
    6. When the user taps a key on the keyboard, the input method recognizes the 
       mouse event location on its keyboard bitmap.  It scans the bitmap 
       horizontally and vertically to place the tap inside a particular key.  
    7. A large array on constants is maintained defining the value of each key 
       on the keyboard and its pixel location so this scanning mechanism can be 
       accomplished.  
    8. The keystroke is processed and various flags are checked such as CAPS 
       lock, shift, etc.  Once the proper keystroke has been determined, it is 
       returned to the application using the IICallBack:SendCharEvents method.  
       IICallBack: SendVirtualKey is used if the virtual key code is desired 
       (an example could be when the windows key was pressed if such a key 
       exists on the keyboard).  Virtual key codes are defined in Windows CE help.  
    9. The state of the keyboard is updated as the key is no longer pressed.  
       Code must be careful to check for sticky keys such as CAPS in this 
       situation.

    The interface that must be implemented is:  Note that GetImdata, SetImData, 
    UserOpionsDlg can simply return an HRESULT without any computation.  

    UserOptionsDlg can display the simple message "There are no options for this 
    input method."  This is just to show the function of method so a user can 
    extend it further.    

    This interface is implemented by the input method (IM) component. The input 
    panel calls the methods of this interface to notify the IM of state changes 
    and to request action and information from the IM. 

    Refer to the SDK documentation for the IInputMethod interface for more 
    information on the methods that must be implemented to create a custom SIP.

Relevant APIs: 
    SIP APIs
    
Usage:
    1. In Visual Studio, build the DLL. When the build is complete, it will 
       automatically be downloaded and registered on the device or emulator.
    2. Make sure the dvoraksip.DLL ends up in the \Windows directory.
    3. Select the Dvorak SIP using the SIP button in the lower middle of the 
       screen from within any application that support the SIP. 
       (Word Mobile, Notes, etc.)

This sample works on either the Pocket PC Emulator or real device.

Assumptions: 
    None.

Requirements: 
    Visual Studio 2005, 
    Windows Mobile 5.0 Pocket PC SDK
    ActiveSync 4.0.

** For more information about this code sample, 
please see the Windows Mobile SDK help system. **
