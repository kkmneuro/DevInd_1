#pragma once

#include "Stdafx.h"

class CXCritSec
{
public:

	  class CLocker
      {
         public:

            explicit CLocker(CXCritSec &crit);
            explicit CLocker(CXCritSec *pCrit);
            ~CLocker();
      

         private :

            CXCritSec& m_crit;
	  };

	CXCritSec(void);
	~CXCritSec(void);
	     
	void Enter();
    void Leave();


   private :

      CRITICAL_SECTION m_crit;
};
