#include <iostream>
#include <Windows.h>
#include

using namespace std;

#define function(x) (std::cout <<x<<std::endl)

#define Single(T)                   \
public:                             \
	static T& Instance()            \
	{                               \
		static T instance;          \
		return instance;            \
	}                               \
private:                            \
	T(const T&) = delete;           \
	T& operator=(const T&) = delete;

#define GetSingle(T) (T::GetInstance())

template<typename T>
class Singleton
{

public:
	Single(Singleton)
/*
private:
	static Singleton* Instance;
public:
	static Singleton* GetInstance()
	{
		if (Instance == nullptr)
			Instance = new Singleton;

		return Instance;
	}
*/
private:
	int Value;
public:
	int GetValue() { return Value; }
	void SetValue(int value) { Value = value; }
private:
	Singleton() :Value(0) {}
public:
	~Singleton() {}
};

//Singleton* Singleton: Instance = nullptr;

int* function()
{
	int value = 10;

	return &value;
}

int main(void)
{
	GetSingle(Singleton).SetValue(10);
	cout << GetSingle(Singleton).GetValue() << endl;
}