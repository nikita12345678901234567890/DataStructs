#include <iostream>
#include <string>

void DoSomething();



int main()
{
	using std::cout;
	using std::cin;

	//Contains function
	int myArray[10] = { 1,2,3,4,5,6,7,8,9,10 };
	myArray[0] = 4;
	/*cout << "test" << std::endl;
	int t;
	cin >> t;
	cout << t;
	std::string test;
	std::cin.ignore();
	std::getline(std::cin,test);
	cout << test;*/

	//Mad Libs

	/*Today I went to the zoo.I saw a(n)
		___________(adjective)
		_____________(Noun) jumping upand down in its tree.
		He _____________(verb, past tense) __________(adverb)
		through the large tunnel that led to its _______(adjective)
		__________(noun).I got some peanutsand passed
		them through the cage to a gigantic gray _______(noun)
		towering above my head.Feeding that animal made
		me hungry.I went to get a __________(adjective) scoop
		of ice cream.It filled my stomach.Afterwards I had to
		__________(verb) __________(adverb) to catch our bus.
		When I got home I __________(verb, past tense) my
		mom for a __________(adjective) day at the zoo*/
	DoSomething();

	std::string adj, noun, verb, adverb, adj2, noun2, noun3, adj3, verb2, adverb2, verb3, adj4;

	cout << "Give me a adj" << std::endl;
	std::getline(std::cin, adj);
	cout << "Give me a noun" << std::endl;
	std::getline(std::cin, noun);
	cout << "Give me a verb(past tense)" << std::endl;
	std::getline(std::cin, verb);
	cout << "Give me a adverb" << std::endl;
	std::getline(std::cin, adverb);
	cout << "Give me a adj" << std::endl;
	std::getline(std::cin, adj2);
	cout << "Give me a noun" << std::endl;
	std::getline(std::cin, noun2);
	cout << "Give me a noun" << std::endl;
	std::getline(std::cin, noun3);
	cout << "Give me a adj" << std::endl;
	std::getline(std::cin, adj3);
	cout << "Give me a verb" << std::endl;
	std::getline(std::cin, verb2);
	cout << "Give me a adverb" << std::endl;
	std::getline(std::cin, adverb2);
	cout << "Give me a verb(past tense)" << std::endl;
	std::getline(std::cin, verb3);
	cout << "Give me a adj" << std::endl;
	std::getline(std::cin, adj4);

	std::cout << "Today I went to the zoo. I saw a(n) " << adj << std::endl << noun << " jumping up and down in its tree.\nHe " << verb << " " << adverb << "\n through the large tunnel that led to its " << adj2 << std::endl << noun2 << ". I got some peanuts and passed\nthem through the cage to a gigantic gray " << noun3 << std::endl << " towering above my head. Feeding that animal made\nme hungry. I went to get a " << adj3 << " scoop\nof ice cream. It filled my stomach. Afterwards I had to\n" << verb2 << " " << adverb2 << " to catch our bus.\nWhen I got home I " << verb3 << " my\nmom for a " << adj4 << " day at the zoo.";


}


void DoSomething()
{

}