#pragma once
#include <string>
class JSONHandler
{
public:
	JSONHandler();

	static void* GetObjectFromJSON(char *buff, unsigned int size, int &MsgType);
	static bool GetJSONFromObject(void *object, int MsgType, std::string& JSONString, unsigned int &size);
	static bool JSONHandler::utf8_check_is_valid(const std::string& string);
	~JSONHandler();
};

