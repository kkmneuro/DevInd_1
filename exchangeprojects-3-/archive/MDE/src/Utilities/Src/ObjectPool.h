#pragma once

#include <stdlib.h>
#include <list>

#include <Windows.h>

using namespace std;
typedef void * TPtrAny;

template<typename COPDataType> class IObjectPool
{
protected:
    virtual void FreeAll(void) = 0;

public:
	virtual void FreeInstance(COPDataType* instance) = 0;
    virtual COPDataType* NewInstance(void) = 0;
    virtual ~IObjectPool( void ) = 0;
};

template<typename COPDataType> class CObjectPool
{
protected:
	std::list<COPDataType*> _ObjectUsed;
	std::list<COPDataType*> _ObjectFree;
	unsigned int _ObjectCount;
	CRITICAL_SECTION __m_cs;

protected:
    void FreeAll(void)
	{
		EnterCriticalSection( &( __m_cs ) );

		// move the used objects to the end of free objects list
		_ObjectFree.splice ( _ObjectFree.end(), _ObjectUsed );

		LeaveCriticalSection( &( __m_cs ) );
	}

public:
	void FreeInstance(COPDataType* instance)
	{
		EnterCriticalSection( &( __m_cs ) );

		if( ( instance ) /*&& ( _ObjectFree.size() < _ObjectCount )*/)
		{
			//find the object in the used list
			list<COPDataType*>::iterator usedIterator ;
			for ( usedIterator = _ObjectUsed.begin(); usedIterator != _ObjectUsed.end(); usedIterator++ )
			{
				
				if( *usedIterator == instance )
				{
					// move the object from used list to the end of free list
					_ObjectFree.splice ( _ObjectFree.end(), _ObjectUsed, usedIterator );
					break;
				}
			}
		}

		LeaveCriticalSection( &( __m_cs ) );

		return;
	}

	COPDataType* NewInstance(void)
	{
		 COPDataType* result = NULL;

		 EnterCriticalSection( &( __m_cs ) );

		 if( !_ObjectFree.empty() )
		 {
			 result = ( _ObjectFree.front() );
			 _ObjectFree.pop_front();
			 _ObjectUsed.push_back( result );
			 //_ObjectFree.resize( (_ObjectFree.size() - 1 ));
		 }

		 LeaveCriticalSection( &( __m_cs ) );

		 return result;
	}

    CObjectPool( int count )
	{
		 InitializeCriticalSection( &( __m_cs ) );
		_ObjectCount = count;

		// allocate the objects
		for( unsigned int index=0; index < _ObjectCount ; index++ )
		{
			_ObjectFree.push_back( new COPDataType() );
		}

	}
    
	
	~CObjectPool( void )
	{
		 FreeAll();
		//_ObjectUsed.clear();

		 while( !_ObjectFree.empty())
		{
			COPDataType* current = _ObjectFree.back();
			_ObjectFree.pop_back();
			delete ( current );
		}

		_ObjectFree.clear();

		 DeleteCriticalSection( &( __m_cs ) );

	}
 };
