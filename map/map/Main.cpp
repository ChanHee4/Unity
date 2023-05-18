#include <iostream>
#include <map>

using namespace std;

typedef struct Score
{
	string name;
	int Kor;
	int Eng;
	int Math;

	Score(): Kor(0), Eng(0), Math(0) {}

	Score(int _kor, int _eng, int _math)
		: Kor(_kor), Eng(_eng), Math(_math){}
};


int main(void)
{
	map<string, Score> List;


	string name = "ȫ�浿";
	Score score = Score(10, 20, 30);

	List.insert(make_pair(name, score));

	score = Score(100, 200, 300);
	List[name] = score;

	cout << List[name].Kor << endl;
	cout << List[name].Eng << endl;
	cout << List[name].Math << endl;

	multimap<string, Score> multiList;

	multiList.insert(make_pair(name, score));
	multiList.insert(make_pair(name, score));

	for (multimap<string, Score>::iterator iter = multiList.begin(); iter != multiList.end(); ++iter)
	{
		cout << iter->first << " : " << iter->second.Kor << endl;
		cout << iter->first << " : " << iter->second.Eng << endl;
		cout << iter->first << " : " << iter->second.Math << endl;
	}

	return 0;
}