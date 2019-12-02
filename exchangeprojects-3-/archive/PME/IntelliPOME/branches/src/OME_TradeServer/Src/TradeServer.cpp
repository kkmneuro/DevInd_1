#ifndef _WIN32_WINNT            // Specifies that the minimum required platform is Windows Vista.
#define _WIN32_WINNT 0x0600     // Change this to the appropriate value to target other versions of Windows.
#endif

//#include "windows.h"
#include "tchar.h"
#include "ServerController.h"
#include <iostream>
#include <windows.h> 
#include <strsafe.h> 
#include <stdio.h>
#include <conio.h>

DWORD WINAPI Thread_no_1( LPVOID lpParam ) 
{

    int     Data = 0;
    int     count = 0;
    HANDLE  hStdout = NULL;
    std::cout<<"Started"<<std::endl;
    // Get Handle To screen.
    // Else how will we print?
    if( (hStdout = 
         GetStdHandle(STD_OUTPUT_HANDLE)) 
         == INVALID_HANDLE_VALUE )  
    return 1;

    // Cast the parameter to the correct
    // data type passed by callee i.e main() in our case.
    getch();
	
	((ServerController* )lpParam)->StopTS();
	::Sleep(500);
    return 0; 
} 

int _tmain(int argc, _TCHAR* argv[])
{
	SetConsoleTitle("Server Port  9005");
	
	
	HANDLE Handle_Of_Thread_1 = 0;
	ServerController *controller = new ServerController();
	
	// Create thread 1.
    Handle_Of_Thread_1 = CreateThread( NULL, 0, 
           Thread_no_1, controller, 0, NULL);  
    if ( Handle_Of_Thread_1 == NULL)
        ExitProcess(1);
	controller->RunTS();
	// Close all thread handles upon completion.
    CloseHandle(Handle_Of_Thread_1);
	
	delete controller;
	return 0;
	
}